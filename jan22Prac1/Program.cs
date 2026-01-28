using System;

namespace jan22Prac1
{
    /// <summary>
    /// A simple calculator class demonstrating the use of the Obsolete attribute.
    /// </summary>
    public class Calculator
    {
        // This method is marked as obsolete
        [Obsolete("Use the Add(int,int) method instead")]
        public int OldAdd(int a,int b)
        {
            return a+b; 
        }
        public int Add(int a, int b)
        {
            return a+b;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            int sum = calc.Add(5, 10);
            int oldSum = calc.OldAdd(3, 7); // This will show a warning
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Old Sum: " + oldSum); // This will show a warning
        }
    }
}