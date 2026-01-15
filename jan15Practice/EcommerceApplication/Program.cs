using System;

namespace EcommerceApplication
{
    /// <summary>
    /// Custom exception to indicate insufficient wallet balance.
    /// </summary>
    public class InsufficientWalletBalanceException : Exception 
    {
            public InsufficientWalletBalanceException(string message):base(message)
            {
            }
    }
    class Program
    {
        /// <summary>
        /// Processes payment for an e-commerce shop user.
        /// Throws InsufficientWalletBalanceException if balance is insufficient.
        /// </summary>
        public EcommerceShop MakePayment(string name,double balance,double amount)
        {
            if (balance < amount)
            {
                throw new InsufficientWalletBalanceException
                ("Insufficient balance in your digital wallet");
            }

            return new EcommerceShop()
            {
                UserName = name,
                WalletBalance = balance,
                TotalPurchaseAmount = amount
            };
        }

        public static void Main(string[] args)
        {
            Program p=new Program();
            try
            {
                EcommerceShop shop=p.MakePayment("Shrey",5000,2000);
                Console.WriteLine("Payment Successfull!");
            }
            catch(InsufficientWalletBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}