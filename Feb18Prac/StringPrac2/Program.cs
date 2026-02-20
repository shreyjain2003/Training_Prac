using System;
using System.Collections.Generic;
using System.Linq;
namespace StringPrac2
{

    public class Program
    {
        public static void GetVowels(string str)
        {
            List<char> VowelArr = new List<char>();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            foreach (char ch in str)
            {
                // if(Array.Exists(vowels,v => v == ch))
                // {
                //     VowelArr.Add(ch);
                // }
                if (vowels.Contains(ch))
                {
                    VowelArr.Add(ch);
                }
            }
            Console.WriteLine("Vowels: ");
            foreach (var v in VowelArr)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();
        }
        public static void GetConsonants(string str)
        {
            string res = new string(str.Where(c => c!= ' ').ToArray());
            Console.WriteLine("Consonants: ");
            foreach(char ch in res)
            {
                if(!"aeiouAEIOU".Contains(ch))
                {
                    Console.Write(ch + " ");
                }
            }
        }
        public static void Main(string[] args)
        {
            string str = "Shreyans jain";
            GetVowels(str);
            GetConsonants(str);
        }
    }
}