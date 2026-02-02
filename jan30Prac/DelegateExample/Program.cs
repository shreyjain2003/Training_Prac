using System;
using System.Collections.Generic;

namespace DelegateExample
{
    class Program
    {
        /// <summary>
        /// This program demonstrates the use of Predicate, Func, and Action delegates in C#.
        /// It filters a list of numbers to find those greater than 20, computes their squares,
        /// and prints the results to the console.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Sample data
            List<int> numbers = new List<int> { 10, 15, 20, 25, 30 };

            // Predicate: checks condition (returns bool)
            Predicate<int> isGreaterThan20 = n => n > 20;

            // Func: performs calculation (returns value)
            Func<int, int> squareNumber = n => n * n;

            // Action: performs action (returns nothing)
            Action<int> printResult = result =>
            {
                Console.WriteLine("Result: " + result);
            };

            Console.WriteLine("Numbers greater than 20 and their squares:\n");

            foreach (int number in numbers)
            {
                if (isGreaterThan20(number))
                {
                    int squaredValue = squareNumber(number);
                    printResult(squaredValue);
                }
            }

            Console.WriteLine("\nProgram completed.");
        }
    }
}
