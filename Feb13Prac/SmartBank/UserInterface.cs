using System;

public class UserInterface
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter employment type: ");
            string employmentType = Console.ReadLine();

            Console.Write("Enter monthly income: ");
            double monthlyIncome = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter existing credit dues: ");
            double dues = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter credit score: ");
            int creditScore = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number of loan defaults: ");
            int defaults = Convert.ToInt32(Console.ReadLine());

            // Validation
            CreditRiskProcessor.ValidateCustomerDetails(
                age,
                employmentType,
                monthlyIncome,
                dues,
                creditScore,
                defaults);

            // Calculation
            double creditLimit = CreditRiskProcessor.CalculateCreditLimit(
                monthlyIncome,
                dues,
                creditScore,
                defaults);

            Console.WriteLine($"Customer Name: {name}");
            Console.WriteLine($"Approved Credit Limit: ₹{creditLimit}");
        }
        catch (InvalidCreditDataException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input format");
        }
        
    }
}

