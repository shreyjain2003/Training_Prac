using System;

namespace UserAuthenticationApp
{
    /// <summary>
    /// Custom exception class for password mismatch
    /// </summary>
    public class PasswordMismatchException : Exception
    {
        public PasswordMismatchException(string message) : base(message)
        {

        }
    }
    public class Program
    {
        /// <summary>
        /// Validates if the password and confirmation password match
        /// </summary>
        /// <param name="name">User's name</param>
        /// <param name="password">User's password</param>
        /// <param name="confirmationPassword">User's confirmation password</param>
        /// <returns>User object if passwords match</returns>
        public User ValidatePassword(string name, string password, string confirmationPassword)
        {
            if(!password.Equals(confirmationPassword))
            {
                throw new PasswordMismatchException("Password entered does not match");
            }
            return new User
            {
                Name=name,
                Password=password,
                ConfirmationPassword=confirmationPassword
            };
        }
        public static void Main(string[] args)
        {
            Program p =new Program();

            try
            {
                User user=p.ValidatePassword("Shreyansh","Sjain","sjainn");
                Console.WriteLine("User Created Successfully!");
            }
            catch(PasswordMismatchException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}