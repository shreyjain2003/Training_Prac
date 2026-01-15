using System;
using System.Collections.Generic;
using System.Linq;

namespace jan14Prac4
{
    public class DelegateExamples
    {
        public void Run()
        {
            // ---------------------------------------------------------
            // 1. ACTION<T>
            // Use Case: For methods that return 'void'. 
            // Often used for logging, printing, or updating UI.
            // ---------------------------------------------------------
            Action<string> logger = message =>
            {
                Console.WriteLine($"[LOG]: {message} at {DateTime.Now}");
            };

            logger("Application Started"); // Invoking the Action


            // ---------------------------------------------------------
            // 2. FUNC<T, TResult>
            // Use Case: For methods that return a value. 
            // The LAST parameter in the angle brackets is the return type.
            // ---------------------------------------------------------
            // Takes two ints, returns a string
            Func<int, int, string> multiplyResult = (x, y) =>
            {
                return $"{x} times {y} is {x * y}";
            };

            string resultText = multiplyResult(5, 4); // Returns "5 times 4 is 20"


            // ---------------------------------------------------------
            // 3. PREDICATE<T>.        This is a delegate that returns a bool.
            // Use Case: For methods that test a condition.
            // Always takes one input and returns 'bool'.
            // ---------------------------------------------------------
            Predicate<int> isEven = number => number % 2 == 0;

            bool check = isEven(10); // Returns true


            // ---------------------------------------------------------
            // 4. PUTTING IT ALL TOGETHER
            // Example: Processing a list using all three delegates.
            // ---------------------------------------------------------
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            ProcessData(numbers, isEven, logger);
        }

        // A method that accepts delegates as parameters (Higher-Order Function)
        public void ProcessData(List<int> data, Predicate<int> filter, Action<string> logAction)
        {
            foreach (int item in data)
            {
                if (filter(item)) // Using the Predicate
                {
                    logAction($"Found even number: {item}"); // Using the Action
                }
            }
        }
    }
}