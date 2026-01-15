using System;

namespace UserVerificationApp
{
    /// <summary>
    /// Custom exception class for invalid phone numbers
    /// </summary>
    public class InvalidPhoneNumberException : Exception
    {
        public InvalidPhoneNumberException(string message) : base(message)
        {

        }
    }
    public class Program
    {
        /// <summary>
        /// Validates the phone number and returns a User object if valid
        /// </summary>
        public User ValidatePhoneNumber(string name, string phoneNumber)
        {
            if(phoneNumber.Length !=10)
            {
                throw new InvalidPhoneNumberException("Invalid phone number");
            }

            return new User
            {
                Name=name,
                PhoneNumber=phoneNumber
            };
        }
        /// <summary>
        /// Entry point of the program
        /// </summary>
        public static void Main(string[] args)
        {
            Program p=new Program();

            try
            {
                User u=p.ValidatePhoneNumber("shrey","7983290365");
                Console.WriteLine("Name: "+u.Name);
                Console.WriteLine("Phone number: "+u.PhoneNumber);
                Console.WriteLine("User phone number is valid");
            }
            catch(InvalidPhoneNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}