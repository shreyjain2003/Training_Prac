using System;

namespace AdvanceQues5
{
    public class BankAccount
    {
        protected double balance;

        public virtual void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine($"After Depositing: {balance}");
        }

        public virtual void Withdraw(double amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            balance -= amount;
            Console.WriteLine($"After Withdrawal: {balance}");
        }
    }

    // Checking Account (No overdraft allowed)
    public class CheckingAccount : BankAccount
    {
        public override void Withdraw(double amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Checking Account: Insufficient balance.");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"Checking Account Balance: {balance}");
            }
        }
    }

    // Savings Account (Adds interest on deposit)
    public class SavingsAccount : BankAccount
    {
        private double interestRate = 0.05;

        public override void Deposit(double amount)
        {
            double interest = amount * interestRate;
            balance += amount + interest;

            Console.WriteLine($"Savings Account Deposit: {amount}");
            Console.WriteLine($"Interest Added: {interest}");
            Console.WriteLine($"Total Balance: {balance}");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            BankAccount acc1 = new CheckingAccount();
            acc1.Deposit(500);
            acc1.Withdraw(600);

            Console.WriteLine();

            BankAccount acc2 = new SavingsAccount();
            acc2.Deposit(1000);
        }
    }
}
