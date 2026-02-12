// Implement a `BankAccount` class with `Deposit()` and 
//`Withdraw()`. Extend it to `SavingsAccount` with interest
// calculation.

using System;
namespace InheritancePrac5
{
    public class BankAccount
    {
        protected double balance; 
        public virtual void Deposit(double amount)
        {
            balance+=amount;
            Console.WriteLine($"Deposited: {amount}");
        }
        public virtual void Withdraw(double amount)
        {
            balance-=amount;
            Console.WriteLine("Balance after Withdraw: "+balance);
        }
    }
    public class SavingsAccount : BankAccount
    {
        private double interest = 0.05;
        public override void Deposit(double amount)
        {
            balance += amount + (amount * interest);
            Console.WriteLine($"Deposited with interest: {amount * interest}");
            Console.WriteLine("Balance After Deposit with interest: "+balance);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            SavingsAccount account = new SavingsAccount();
            account.Deposit(500);
            account.Withdraw(200);
        }
    }
}