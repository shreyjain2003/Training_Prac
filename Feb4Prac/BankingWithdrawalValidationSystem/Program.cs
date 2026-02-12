using System;

namespace BankingWithdrawalValidationSystem
{
    public class BankAccount
    {
        public static void Main(string[] args)
        {
            int balance=1000;
            Console.WriteLine("Enter the amount to withdraw: ");
            int amount=int.Parse(Console.ReadLine());
            try
            {
            if(amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            else if(amount > balance)
            {
                throw new InvalidOperationException("Insufficient Funds.");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"Withdrawal successful! New balance: {balance}");
            }
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine("Error: "+ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An unexpected error occured!");
            }
            finally
            {
                Console.WriteLine("Transaction attempt logged!");
            }



        }
    }
}