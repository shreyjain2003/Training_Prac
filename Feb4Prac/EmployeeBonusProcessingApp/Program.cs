using System;

namespace EmployeeBonusProcessingApp
{
    public class BonusCalculator
    {
        public static void Main(string[] args)
        {
            int[] salaries = {5000, 0, 7000};
            int bonus=500;
            int result=0;
            for(int i=0;i<salaries.Length;i++)
            {
                try
                {
                    result = bonus / salaries[i];
                    Console.WriteLine($"Employee {i+1}: Bonus calculated successfully: {result}");
                }
                catch(DivideByZeroException)
                {
                    Console.WriteLine($"Error: Cannot calculate bonus for Employee {i+1} due to zero salary.");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Employee {i+1}: Unexpected error - {ex.Message}");
                }
                finally
                {
                    Console.WriteLine($"Bonus calculation attempt completed for Employee {i+1}.\n");
                }
            }
        }
    }
}