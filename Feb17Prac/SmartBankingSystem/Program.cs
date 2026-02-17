using System;
using System.Collections.Generic;
using System.Linq;
namespace SmartBankingSystem
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {

        }
    }
    public class MinimumBalanceException : Exception
    {
        public MinimumBalanceException(string message) : base(message)
        {

        }
    }
    public class InvalidTransactionException : Exception
    {
        public InvalidTransactionException(string message) : base(message)
        {

        }
    }
    public abstract class BankAccount
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal Balance { get; set; }
        public List<string> TransactionHistory { get; set; } = new List<string>();
        protected BankAccount(int accNo, string custName, decimal balance)
        {
            AccountNumber = accNo;
            CustomerName = custName;
            Balance = balance;
        }
        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidTransactionException("Deposite Amount must be positive!");
            }
            else
            {
                Balance += amount;
                TransactionHistory.Add($"Deposited {amount}");
            }
        }
        public virtual void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InsufficientBalanceException("Insufficient Balance!");
            }
            else
            {
                Balance -= amount;
                TransactionHistory.Add($"{amount} Withdrawn");
            }
        }
        public abstract decimal CalculateInterest();
        public override string ToString()
        {
            return $"{AccountNumber} | {CustomerName} | {Balance}";
        }
    }

    public class SavingsAccount : BankAccount
    {
        private const decimal MinimumBalance = 1000;
        private const decimal InterestRate = 0.04m;
        public SavingsAccount(int accNo, string custName, decimal balance)
            : base(accNo, custName, balance)
        {

        }
        public override void Withdraw(decimal amount)
        {
            if (Balance - amount < MinimumBalance)
            {
                throw new MinimumBalanceException("Minimum Balance must be maintained!");
            }
            else
            {
                base.Withdraw(amount);
            }
        }
        public override decimal CalculateInterest()
        {
            return Balance * InterestRate;
        }
    }
    public class CurrentAccount : BankAccount
    {
        private const decimal Overdraft = 20000;
        public CurrentAccount(int accNo, string custName, decimal balance)
            : base(accNo, custName, balance)
        {
        }
        public override void Withdraw(decimal amount)
        {
            if (amount > Balance + Overdraft)
            {
                throw new InsufficientBalanceException("Draft limit exceeded.");
            }
            else
            {
                Balance -= amount;
                TransactionHistory.Add($"{amount} Withdrawn.");
            }
        }
        public override decimal CalculateInterest()
        {
            return 0;
        }

    }
    public class LoanAccount : BankAccount
    {
        private const decimal InterestRate = 0.1m;
        public LoanAccount(int accNo, string custName, decimal balance)
            : base(accNo, custName, balance)
        {

        }
        public override void Deposit(decimal amount)
        {
            throw new InvalidTransactionException("Cannot deposit in Loan account.");
        }
        public override decimal CalculateInterest()
        {
            return Balance * InterestRate;
        }
    }
    public class BankService
    {
        public List<BankAccount> accounts = new List<BankAccount>();
        public void Transfer(int fromAcc, int toAcc, decimal amount)
        {
            var sender = accounts.FirstOrDefault(a => a.AccountNumber == fromAcc);
            var receiver = accounts.FirstOrDefault(a => a.AccountNumber == toAcc);
            if (sender == null || receiver == null)
            {
                throw new InvalidTransactionException("Account not found.");
            }
            else
            {
                sender.Withdraw(amount);
                receiver.Deposit(amount);
            }
        }
        public void RunLinqQueries()
        {
            Console.WriteLine("\nAccounts with balance > 50000: ");
            var highBalance = accounts.Where(a => a.Balance > 50000);
            foreach (var acc in highBalance)
            {
                Console.WriteLine(acc);
            }

            Console.WriteLine("\nTotal Bank Balance: ");
            var totalBalance = accounts.Sum(a => a.Balance);
            Console.WriteLine(totalBalance);

            Console.WriteLine("\nTop 3 highest balance accounts: ");
            var highestBalanceAccounts = accounts.OrderByDescending(a => a.Balance).Take(3);
            foreach (var acc in highestBalanceAccounts)
            {
                Console.WriteLine(acc);
            }

            Console.WriteLine("\nAccount with their types: ");
            var grouped = accounts.GroupBy(a => a.GetType().Name);
            foreach (var group in grouped)
            {
                Console.WriteLine(group.Key);
                foreach (var acc in group)
                {
                    Console.WriteLine(acc);
                }
            }

            Console.WriteLine("\nCustomers starting with R: ");
            var customers = accounts.Where(a => a.CustomerName.StartsWith("R"));
            foreach (var acc in customers)
            {
                Console.WriteLine(acc);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            BankService bank = new BankService();

            // Sample Data
            bank.accounts.Add(new SavingsAccount(1, "Rahul", 60000));
            bank.accounts.Add(new CurrentAccount(2, "Riya", 30000));
            bank.accounts.Add(new LoanAccount(3, "Amit", 500000));
            bank.accounts.Add(new SavingsAccount(4, "Rohan", 80000));

            while (true)
            {
                Console.WriteLine("\n===== SMART BANKING SYSTEM =====");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Calculate Interest");
                Console.WriteLine("5. Run LINQ Queries");
                Console.WriteLine("6. Show Transaction History");
                Console.WriteLine("0. Exit");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Account No: ");
                            int acc = int.Parse(Console.ReadLine());
                            Console.Write("Amount: ");
                            decimal amt = decimal.Parse(Console.ReadLine());
                            bank.accounts.Find(a => a.AccountNumber == acc)?.Deposit(amt);
                            break;

                        case 2:
                            Console.Write("Account No: ");
                            acc = int.Parse(Console.ReadLine());
                            Console.Write("Amount: ");
                            amt = decimal.Parse(Console.ReadLine());
                            bank.accounts.Find(a => a.AccountNumber == acc)?.Withdraw(amt);
                            break;

                        case 3:
                            Console.Write("From Account: ");
                            int from = int.Parse(Console.ReadLine());
                            Console.Write("To Account: ");
                            int to = int.Parse(Console.ReadLine());
                            Console.Write("Amount: ");
                            amt = decimal.Parse(Console.ReadLine());
                            bank.Transfer(from, to, amt);
                            break;

                        case 4:
                            foreach (var account in bank.accounts)
                                Console.WriteLine($"{account.CustomerName} Interest: {account.CalculateInterest()}");
                            break;

                        case 5:
                            bank.RunLinqQueries();
                            break;

                        case 6:
                            Console.Write("Account No: ");
                            acc = int.Parse(Console.ReadLine());
                            var accountHistory = bank.accounts.FirstOrDefault(a => a.AccountNumber == acc);
                            if (accountHistory != null)
                            {
                                foreach (var t in accountHistory.TransactionHistory)
                                    Console.WriteLine(t);
                            }
                            break;

                        case 0:
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

    }
}
