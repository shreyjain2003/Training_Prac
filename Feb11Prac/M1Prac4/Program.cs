using System;

namespace M1Prac4
{
    public class Program
    {
        static char FirstNonRepeating(string str)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();

            foreach (char c in str)
            {
                if (freq.ContainsKey(c))
                    freq[c]++;
                else
                    freq[c] = 1;
            }

            foreach (char c in str)
            {
                if (freq[c] == 1)
                    return c;
            }

            return '\0';
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string input = Console.ReadLine();
            char result = FirstNonRepeating(input);
            Console.WriteLine("Result: " + result);
        }
    }
}