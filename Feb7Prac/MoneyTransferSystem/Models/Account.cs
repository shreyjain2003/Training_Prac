namespace MoneyTransferSystem.Models
{
    public class Account
    {
        public string AccountNumber { get; }
        public decimal Balance { get; set; }

        public Account(string accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }
    }
}
