using System;
namespace M1Prac3
{
    public class Program
    {
        public static int VowelCount(string str)
        {
            int count = 0;
            string vowels = "aeiouAEIOU";
            foreach(char c in str)
            {
                if(vowels.Contains(c))
                {
                    count++;
                }
            }
            return count;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string input = Console.ReadLine();
            int vowelCount = VowelCount(input);
            Console.WriteLine("Number of vowels in the string: "+vowelCount);
        }
    }
}