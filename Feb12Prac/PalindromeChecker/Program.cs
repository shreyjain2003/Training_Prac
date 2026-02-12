using System;

namespace PalindromeChecker
{
    public class Program
    {
        public static bool IsPalindrome(string input)
        {
            char[] charArray = input.ToCharArray();
            char[] resultArr = new char[charArray.Length];
            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                resultArr[charArray.Length - 1 - i] = charArray[i];
            }

            string res = new string(resultArr);

            if (res.Equals(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("'Enter the string: ");
            string input = Console.ReadLine();
            if (IsPalindrome(input))
            {
                Console.WriteLine("The given string is Palindrome!");
            }
            else
            {
                Console.WriteLine("The given string is not a Palindrome!");
            }
        }
    }
}