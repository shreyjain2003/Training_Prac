using System;

namespace GoAirSecurity
{
    /// <summary>
    /// Class to handle entry utility
    /// </summary>
    public class EntryUtility
    {
        public bool validateEmployeeId(string employeeId) // Method to validate employee ID
        {
            string prefix="GOAIR/";
            string[] parts=employeeId.Split('/');

            if(employeeId.StartsWith(prefix)&& employeeId.Length==10)
            {
                return true;
            }
            else
            {
                throw new InvalidCastException("Invalid entry detals");
            }
        }

        public bool validateDuration(int duration)
        {
            if(duration > 0 && duration <= 5)
            {
                return true;
            }
            else
            {
                throw new InvalidCastException("Invalid entry detals");
            }
        }

    } 

    public class InvalidEntryException : Exception
    {
        public InvalidEntryException(string message) : base(message)
        {
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            EntryUtility entryutility=new EntryUtility();
            Console.WriteLine("Enter the number of Entries: ");
            int number =int.Parse(Console.ReadLine());
            if(number <= 0)
            {
                Console.WriteLine("No Entries Found!");
                return;
            }
            else
            {
                for(int i = 0; i < number; i++)
                {
                    try
                    {
                        Console.WriteLine("Enter the Employee ID,Entry type and Duration (colon separated) ");
                        Console.WriteLine($"Entry {i+1}:");
                        string input=Console.ReadLine();

                        string[] details=input.Split(":");
                        string employeeId=details[0];
                        string entryType=details[1];
                        int duration=int.Parse(details[2]);
                    
                    
                        bool isValidId=entryutility.validateEmployeeId(employeeId);
                        bool isValidDuration=entryutility.validateDuration(duration);
                        if(isValidId && isValidDuration)
                        {
                            Console.WriteLine("Valid entry details");
                        }
                    }
                    catch(InvalidEntryException ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            
        }
    }
}