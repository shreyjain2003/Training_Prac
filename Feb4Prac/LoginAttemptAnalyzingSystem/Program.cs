using System;
namespace LoginAttemptAnalyzingSystem
{
    public class LimitExceededException : Exception
    {
        public LimitExceededException(string message) : base(message)
        {

        }
    }
    public class LoginSystem
    {
        public static void Main(string[] args)
        {
            int attempts;
            string UserName = "Admin@123";
            string Password = "Pass@123";
            for (attempts = 1; attempts <= 4; attempts++)
            {
                try
                {
                    Console.WriteLine("Enter username :");
                    string? username = Console.ReadLine();

                    Console.WriteLine("Enter password: ");
                    string? pass = Console.ReadLine();
                    if(attempts < 4)
                    {

                    if (username.Equals(UserName) && pass.Equals(Password))
                    {
                        Console.WriteLine("Login successfull!");
                        break;
                    }
                    else
                    {
                        attempts++;
                        Console.WriteLine($"Login attempt {attempts} failed.");
                    }
                    }
                    else
                    {
                        Console.WriteLine("Maximum login attempts exceeded. Account locked.");
                    }
                }
                catch (LimitExceededException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occured!");
                }
                finally
                {
                    Console.WriteLine("Login attempt logged!");
                }
            }
        }
    }
}