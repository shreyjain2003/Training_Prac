using System;
using System.Collections.Generic;
using System.Linq;
namespace PracQuestion2
{
    public class Source
    {
        public int Add(int a, int b, int c)
        {
            return a+b+c;
        }
        public double Add(double a, double b, double c)
        {
            return a+b+c;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Source obj = new Source();
            int result1 = obj.Add(1,2,3);
            double result2 = obj.Add(1.2,3.4,5.5);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }
    }
}