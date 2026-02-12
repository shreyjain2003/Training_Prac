using System;
namespace M1Prac1
{
    public class Program
    {
        public static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static void Main(string[] args)
        {

            Console.WriteLine("Enter a string to reverse: ");
            string input = Console.ReadLine();
            Console.WriteLine("Original string: " + input);
            string reversed = ReverseString(input);
            Console.WriteLine("Reversed string: " + reversed);
        }
    }
}