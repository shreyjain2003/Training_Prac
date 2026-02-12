using System.Collections.Generic;
using MoneyTransferSystem.Models;
using MoneyTransferSystem.Exceptions;

namespace MoneyTransferSystem.Services
{
    public class BankService
    {
        private readonly Dictionary<string, Account> _accounts = new();
        private readonly List<AuditEntry> _auditLogs = new();
        private readonly object _lock = new();

        public BankService()
        {
            _accounts["A1"] = new Account("A1", 10000);
            _accounts["B1"] = new Account("B1", 5000);
        }

        public TransferResult Transfer(string fromAcc, string toAcc, decimal amount)
        {
            if (amount <= 0)
                throw new InvalidTransferException("Amount must be positive");

            if (!_accounts.ContainsKey(fromAcc) || !_accounts.ContainsKey(toAcc))
                throw new InvalidTransferException("Invalid account number");

            lock (_lock) // atomic section
            {
                var from = _accounts[fromAcc];
                var to = _accounts[toAcc];

                if (from.Balance < amount)
                    throw new InsufficientBalanceException("Insufficient balance");

                decimal originalFromBalance = from.Balance;
                decimal originalToBalance = to.Balance;

                try
                {
                    // Debit
                    from.Balance -= amount;

                    // Simulate credit failure
                    if (amount > 7000)
                        throw new Exception("Credit failed");

                    // Credit
                    to.Balance += amount;

                    _auditLogs.Add(
                        new AuditEntry($"Transfer SUCCESS: {amount} from {fromAcc} to {toAcc}")
                    );

                    return new TransferResult(true, "Transfer successful");
                }
                catch
                {
                    // Rollback
                    from.Balance = originalFromBalance;
                    to.Balance = originalToBalance;

                    _auditLogs.Add(
                        new AuditEntry($"Transfer FAILED: {amount} from {fromAcc} to {toAcc}")
                    );

                    return new TransferResult(false, "Transfer failed and rolled back");
                }
            }
        }
    }
}
