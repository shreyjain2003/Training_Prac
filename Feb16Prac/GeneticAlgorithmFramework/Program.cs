using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GeneticAlgorithmFramework
{
    #region Core Interfaces

    /// <summary>
    /// Represents a chromosome in evolutionary computation.
    /// </summary>
    public interface IChromosome<TGene, TFitness> :
        IComparable<IChromosome<TGene, TFitness>>
        where TFitness : IComparable<TFitness>
    {
        IReadOnlyList<TGene> Genes { get; }
        TFitness Fitness { get; }
        IChromosome<TGene, TFitness> Crossover(IChromosome<TGene, TFitness> other);
        void Mutate(double mutationRate);
        void EvaluateFitness();
    }

    #endregion

    #region Concrete Chromosome

    /// <summary>
    /// Sample chromosome implementation using double genes.
    /// </summary>
    public class NumericChromosome : IChromosome<double, double>
    {
        private static readonly Random _random = new();

        public IReadOnlyList<double> Genes => _genes;
        public double Fitness { get; private set; }

        private double[] _genes;

        public NumericChromosome(int length)
        {
            _genes = new double[length];
            for (int i = 0; i < length; i++)
                _genes[i] = _random.NextDouble();
        }

        public void EvaluateFitness()
        {
            Fitness = _genes.Sum();
        }

        public IChromosome<double, double> Crossover(IChromosome<double, double> other)
        {
            var child = new NumericChromosome(_genes.Length);
            for (int i = 0; i < _genes.Length; i++)
                child._genes[i] = i % 2 == 0 ? _genes[i] : other.Genes[i];

            return child;
        }

        public void Mutate(double mutationRate)
        {
            for (int i = 0; i < _genes.Length; i++)
                if (_random.NextDouble() < mutationRate)
                    _genes[i] = _random.NextDouble();
        }

        public int CompareTo(IChromosome<double, double> other)
        {
            return other.Fitness.CompareTo(Fitness); // Descending
        }
    }

    #endregion

    #region Supporting Models

    /// <summary>
    /// Represents evolutionary metrics per generation.
    /// </summary>
    public record EvolutionMetrics(int Generation, double BestFitness, double AverageFitness);

    /// <summary>
    /// Evolution configuration.
    /// </summary>
    public class EvolutionConfiguration
    {
        public int PopulationSize { get; set; }
        public int Generations { get; set; }
        public double MutationRate { get; set; }
        public int EliteCount { get; set; }
    }

    /// <summary>
    /// Population container.
    /// </summary>
    public class Population<TGene, TFitness, TChromosome>
        where TChromosome : class, IChromosome<TGene, TFitness>
        where TFitness : struct, IComparable<TFitness>
    {
        public List<TChromosome> Chromosomes { get; } = new();
    }

    #endregion

    #region Evolutionary Algorithm

    /// <summary>
    /// Generic evolutionary algorithm engine.
    /// </summary>
    public class EvolutionaryAlgorithm<TGene, TFitness, TChromosome>
        where TChromosome : class, IChromosome<TGene, TFitness>
        where TFitness : struct, IComparable<TFitness>
    {
        private readonly Population<TGene, TFitness, TChromosome> _population;
        private readonly ConcurrentBag<TChromosome> _offspring = new();

        /// <summary>
        /// Covariant selection strategy.
        /// </summary>
        public interface ISelectionStrategy<in TSource, out TResult>
        {
            IEnumerable<TResult> Select(IEnumerable<TSource> population, int count);
        }

        /// <summary>
        /// Contravariant crossover strategy.
        /// </summary>
        public interface ICrossoverStrategy<in TParent, out TChild>
        {
            TChild Crossover(TParent parent1, TParent parent2);
        }

        public EvolutionaryAlgorithm(Population<TGene, TFitness, TChromosome> population)
        {
            _population = population;
        }

        /// <summary>
        /// Executes evolutionary process asynchronously.
        /// </summary>
        public async Task<(TChromosome BestSolution, IEnumerable<EvolutionMetrics> History)>
            EvolveAsync(EvolutionConfiguration config, CancellationToken cancellationToken)
        {
            var history = new List<EvolutionMetrics>();

            for (int generation = 0; generation < config.Generations; generation++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // Evaluate fitness in parallel
                await Parallel.ForEachAsync(_population.Chromosomes, cancellationToken,
                    (chromosome, token) =>
                    {
                        chromosome.EvaluateFitness();
                        return ValueTask.CompletedTask;
                    });

                // Sort by fitness
                var sorted = _population.Chromosomes
                    .OrderByDescending(c => c.Fitness)
                    .ToList();

                // Preserve elites
                var elites = sorted.Take(config.EliteCount).ToList();

                _offspring.Clear();

                // Generate offspring concurrently
                await Task.WhenAll(Enumerable.Range(0, config.PopulationSize)
                    .Select(_ => Task.Run(() =>
                    {
                        var parent1 = sorted[Random.Shared.Next(sorted.Count)];
                        var parent2 = sorted[Random.Shared.Next(sorted.Count)];

                        var child = (TChromosome)parent1.Crossover(parent2);
                        child.Mutate(config.MutationRate);
                        _offspring.Add(child);
                    }, cancellationToken)));

                _population.Chromosomes.Clear();
                _population.Chromosomes.AddRange(elites);
                _population.Chromosomes.AddRange(_offspring);

                double best = Convert.ToDouble(sorted.First().Fitness);
                double avg = sorted.Average(c => Convert.ToDouble(c.Fitness));

                history.Add(new EvolutionMetrics(generation, best, avg));
            }

            var bestSolution = _population.Chromosomes
                .OrderByDescending(c => c.Fitness)
                .First();

            return (bestSolution, history);
        }

        /// <summary>
        /// Parallel statistics using custom PLINQ aggregator.
        /// </summary>
        public (double Max, double Avg) GetStatistics()
        {
            var stats = _population.Chromosomes
                .AsParallel()
                .Aggregate(
                    () => (Max: double.MinValue, Sum: 0.0, Count: 0),
                    (acc, chromosome) =>
                    {
                        double fit = Convert.ToDouble(chromosome.Fitness);
                        return (Math.Max(acc.Max, fit), acc.Sum + fit, acc.Count + 1);
                    },
                    (acc1, acc2) =>
                    (
                        Math.Max(acc1.Max, acc2.Max),
                        acc1.Sum + acc2.Sum,
                        acc1.Count + acc2.Count
                    ),
                    final => (final.Max, final.Sum / final.Count)
                );

            return stats;
        }
    }

    #endregion

    #region Program Entry

    public class Program
    {
        public static async Task Main()
        {
            var population = new Population<double, double, NumericChromosome>();

            for (int i = 0; i < 100; i++)
                population.Chromosomes.Add(new NumericChromosome(10));

            var algorithm = new EvolutionaryAlgorithm<double, double, NumericChromosome>(population);

            var config = new EvolutionConfiguration
            {
                PopulationSize = 100,
                Generations = 50,
                MutationRate = 0.05,
                EliteCount = 5
            };

            var (best, history) = await algorithm.EvolveAsync(config, CancellationToken.None);

            Console.WriteLine($"Best Fitness: {best.Fitness}");

            var stats = algorithm.GetStatistics();
            Console.WriteLine($"Max Fitness: {stats.Max}, Avg Fitness: {stats.Avg}");
        }
    }

    #endregion
}
