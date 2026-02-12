using System;
using MoneyTransferSystem.Services;
using MoneyTransferSystem.Exceptions;

namespace MoneyTransferSystem
{
    class Program
    {
        static void Main()
        {
            var bank = new BankService();

            try
            {
                var result1 = bank.Transfer("A1", "B1", 6000);
                Console.WriteLine(result1.Message);

                var result2 = bank.Transfer("A1", "B1", 9000);
                Console.WriteLine(result2.Message);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Transfer failed: {ex.Message}");
            }
            catch (InvalidTransferException ex)
            {
                Console.WriteLine($"Invalid transfer: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
