using System;
using System.Text.RegularExpressions;

namespace MailValidationSystem
{
    public class Program
    {
        public static bool IsValidGmail(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                return false;
            }
            string pattern = @"^[a-zA-Z0-9]+@gmail\.com$";
            return Regex.IsMatch(email,pattern);
        }
        public static bool IsValidYahoo(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            else if(email.Contains(" "))
            {
                return false;
            }
            else if(!email.EndsWith("@yahoo.com"))
            {
                return false;
            }
            string[] parts = email.Split('@');
            if(parts.Length != 2)
            {
                return false;
            }
            string localPart = parts[0];
            if(string.IsNullOrEmpty(localPart))
            {
                return false;
            }
            return true;

        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your email address: ");
            string email = Console.ReadLine();
            if(IsValidGmail(email))
            {
                Console.WriteLine("Valid Gmail Address.");
            }
            else if(IsValidYahoo(email))
            {
                Console.WriteLine("Valid Yahoo Address.");
            }
            else
            {
                Console.WriteLine("Invalid Email Address.");
            }
        }
    }
}