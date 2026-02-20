using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegexPrac
{
    public class Program
    {
        public static string RemoveSpecialCharacters(string input)
        {
            return new string(input.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
        }
        public static void Main(string[] args)
        {
            string input = "Shrey@Jain#2026!!!   .NET";
            Console.WriteLine(RemoveSpecialCharacters(input));

            Console.WriteLine("Now using Regex");
            Console.WriteLine(Regex.Replace(input,@"[^\w\s]",""));


        }
    }
}