using System;

namespace WordWand
{
    public class Program
    {
        public static bool IsEvenLength(string input)
        {
            string[] words =input.Split(" ");
            if(words.Length % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsOddLength(string input)
        {
            string[] words=input.Split(" ");
            if(words.Length % 2 != 0)
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
            Console.WriteLine("Enter the sentence: ");
            string input=Console.ReadLine();

            if(IsEvenLength(input))
            {
                string[] words=input.Split(" ");
                int count =words.Length;
                Console.WriteLine("Word Count: "+count);
                Array.Reverse(words);
                string output=string.Join(" ",words);
                Console.WriteLine("Reversed sentence: ");
                Console.WriteLine(output);
            }
            else if(IsOddLength(input))
            {
                string[] words=input.Split(" ");
                int count=words.Length;
                Console.WriteLine("Word Count: "+count);
                // for( int i=0;i<words.Length;i++)
                // {
                //     string[] wordChar= words[i].Split();
                //     for(int j=words[i];j<wordChar.Length;j++)
                //     {
                //         Array.Reverse(wordChar);
                //         string reversedWord=string.Join("",wordChar);
                //         Console.Write(reversedWord+" ");
                //     }
                // }
                foreach(string word in words)
                {
                    char[] charArr=word.ToCharArray();
                    Array.Reverse(charArr);
                    string reverseWord=new string(charArr);
                    Console.Write(reverseWord+" ");
                }
            }
            
        }
    }
}