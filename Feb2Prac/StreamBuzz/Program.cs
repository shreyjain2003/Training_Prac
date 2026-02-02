using System;
using System.Collections.Generic;
using System.Linq;

namespace StreamBuzz
{
    class Program
    {
        /// <summary>
        /// Registers a creator record.
        /// </summary>
        public void RegisterCreator(CreatorStats record)
        {
            CreatorStats.EngagementBoard.Add(record);
        }

        /// <summary>
        /// Returns count of weeks where likes >= threshold.
        /// </summary>
        public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var creator in records)
            {
                int count = creator.WeeklyLikes.Count(l => l >= likeThreshold);
                if (count > 0)
                    result.Add(creator.CreatorName, count);
            }

            return result;
        }

        /// <summary>
        /// Calculates overall average likes.
        /// </summary>
        public double CalculateAverageLikes()
        {
            return CreatorStats.EngagementBoard
                .SelectMany(c => c.WeeklyLikes)
                .Average();
        }

        static void Main()
        {
            Program p = new Program();

            while (true)
            {
                Console.WriteLine("\n1. Register Creator\n2. Show Top Posts\n3. Calculate Average Likes\n4. Exit");
                Console.WriteLine("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    CreatorStats c = new CreatorStats();
                    Console.WriteLine("Enter Creator Name:");
                    c.CreatorName = Console.ReadLine();

                    c.WeeklyLikes = new double[4];
                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                    for (int i = 0; i < 4; i++)
                        c.WeeklyLikes[i] = double.Parse(Console.ReadLine());

                    p.RegisterCreator(c);
                    Console.WriteLine("Creator registered successfully");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter like threshold:");
                    double threshold = double.Parse(Console.ReadLine());

                    var result = p.GetTopPostCounts(CreatorStats.EngagementBoard, threshold);

                    if (result.Count == 0)
                        Console.WriteLine("No top-performing posts this week");
                    else
                        foreach (var r in result)
                            Console.WriteLine($"{r.Key} - {r.Value}");
                }
                else if (choice == 3)
                {
                    Console.WriteLine($"Overall average weekly likes: {p.CalculateAverageLikes()}");
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    break;
                }
            }
        }
    }
}
