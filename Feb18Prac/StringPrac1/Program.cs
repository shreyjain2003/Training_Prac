using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
namespace StringPrac1
{
    public class Program
    {
        public static void StringAsArray(string str)
        {
            string result = "";
            // for(int i=0;i<result.Length;i++)
            // {
            //     if(result[i].Equals(" "))
            //     {
            //         break;
            //     }
            //     else
            //         Console.Write(result[i]+" ");
            // }

            result = new string(str.Where(c => c != ' ').ToArray());
            foreach(var c in result)
            {
                Console.Write(c+" ");
            }
            Console.WriteLine();

            string reverseArr = new string(result.Reverse().ToArray());
            foreach(var c in reverseArr)
            {
                Console.Write(c+" ");
            }
            Console.WriteLine();
        }
        public static bool IsPalindrome(string str)
        {
            str = str.ToLower();
            string reverse = new string(str.ToLower().Reverse().ToArray());
            if(str.Equals(reverse))
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
            // string teststr = "THis is tHe FBI CallInG";
            // string result = "";
            // //result = teststr.ToLower();
            // TextInfo textConverter = CultureInfo.CurrentCulture.TextInfo;
            // result = textConverter.ToTitleCase(teststr);
            // Console.WriteLine(result);
            //string str = "Shreyansh jain";
            string str="Madam";

            StringAsArray(str);
            if(IsPalindrome(str))
            {
                Console.WriteLine("This string is Palindrome!");
            }
            else
            {
                Console.WriteLine("This string is not a Palindrome!");
            }
            //Console.WriteLine(IsPalindrome(str));
        }
    }

}