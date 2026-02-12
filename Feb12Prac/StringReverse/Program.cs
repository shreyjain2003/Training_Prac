using System;

namespace StringReverse
{
    public class Program
    {

        public static string ReverseString(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return input;
            }
            char[] charArray = input.ToCharArray();
            char[] resultArray = new char[charArray.Length];
            for(int i=charArray.Length-1;i>=0;i--)
            {
                resultArray[charArray.Length-1-i] = charArray[i];
            }
            return new string(resultArray);
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to reverse: ");
            string input = Console.ReadLine();
            string reversed = ReverseString(input);
            Console.WriteLine("Reversed string :"+reversed);
        }
    }
}