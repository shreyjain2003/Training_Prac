using System;
using System.Linq;

namespace FlipKey
{
    class Program
    {
        /// <summary>
        /// Cleanses and inverts the given string based on ASCII rules.
        /// </summary>
        public string CleanseAndInvert(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 6)
                return string.Empty;

            if (!input.All(char.IsLetter))
                return string.Empty;

            var filtered = input
                .ToLower()
                .Where(c => ((int)c) % 2 != 0)
                .Reverse()
                .ToArray();

            for (int i = 0; i < filtered.Length; i++)
            {
                if (i % 2 == 0)
                    filtered[i] = char.ToUpper(filtered[i]);
            }

            return new string(filtered);
        }

        static void Main()
        {
            Program p = new Program();

            Console.WriteLine("Enter the word");
            string input = Console.ReadLine();

            string result = p.CleanseAndInvert(input);

            if (string.IsNullOrEmpty(result))
                Console.WriteLine("Invalid Input");
            else
                Console.WriteLine($"The generated key is - {result}");
        }
    }
}
