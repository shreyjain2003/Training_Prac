using System;
using System.Collections.Generic;
using System.Linq;

namespace StringPrac3
{
    public class StringOperations
    {
        public static void RemoveDuplicate(string str)
        {
            string res = new string(str.Where(c => c != ' ').ToArray());

            HashSet<char> seen = new HashSet<char>();

            foreach (char ch in res)
            {
                if (!seen.Contains(ch))
                {
                    seen.Add(ch);
                    Console.Write(ch + " ");
                }
            }
            Console.WriteLine();
        }
        public static void CountFrequency(string str)
        {
            string res = new string(str.Where(c => c != ' ').ToArray());
            Dictionary<char, int> freq = new Dictionary<char, int>();
            foreach (var ch in res)
            {
                if (freq.ContainsKey(ch))
                {
                    freq[ch]++;
                }
                else
                {
                    freq[ch] = 1;
                }
            }
            foreach (var pair in freq)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }
        }
        public static void FirstNonRepeatingCharacter(string str)
        {
            string res = new string(str.Where(c => c != ' ').ToArray());
            Dictionary<char, int> freq = new Dictionary<char, int>();
            foreach (char ch in res)
            {
                if (freq.ContainsKey(ch))
                {
                    freq[ch]++;
                }
                else
                {
                    freq[ch] = 1;
                }
            }
            foreach (var pairs in freq)
            {
                if (pairs.Value == 1)
                {
                    Console.WriteLine("First non repeating character: " + pairs.Key);
                    return;
                }
            }
        }
        public static bool IsAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }
            Dictionary<char, int> freq = new Dictionary<char, int>();
            foreach (var ch in str1)
            {
                if (freq.ContainsKey(ch))
                {
                    freq[ch]++;
                }
                else
                {
                    freq[ch] = 1;
                }
            }
            foreach (var ch in str1)
            {
                if (!freq.ContainsKey(ch))
                {
                    return false;
                }
                else
                {
                    freq[ch]--;
                }
                if (freq[ch] < 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static string RemoveSpaces(string str)
        {
            return string.Join(" ",str.Trim().Split(' ',StringSplitOptions.RemoveEmptyEntries));
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string str = Console.ReadLine();

            StringOperations.RemoveDuplicate(str);

            StringOperations.CountFrequency(str);
            StringOperations.FirstNonRepeatingCharacter(str);
            string str1 = "listen";
            string str2 = "silent";
            Console.WriteLine(str1+ " & "+ str2);

            if (StringOperations.IsAnagram(str1, str2))
            {
                Console.WriteLine("These strings are Anagram.");
            }
            else
            {
                Console.WriteLine("These are not Anagram.");
            }
            string input = " Shrey jain C# ";
            Console.WriteLine(StringOperations.RemoveSpaces(input));
        }
    }
}