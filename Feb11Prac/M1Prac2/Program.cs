using System;

namespace M1Prac2
{
    public class Program
    {
        public static bool IsPalindrome(string str)
        {
            string reversed = new string(str.ToCharArray().Reverse().ToArray());
            if(reversed.Equals(str))
            {
                return true;
            }
            return false;
            
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the String: ");
            string input = Console.ReadLine();
            if(IsPalindrome(input))
            {
                Console.WriteLine("The Given String is a Palindrome!");
            }
            else
            {
                Console.WriteLine("The Given String is not a Palindrome!");
            }
        }
    }
}