using System;

namespace MoneyTransferSystem.Models
{
    public class AuditEntry
    {
        public DateTime Timestamp { get; } = DateTime.UtcNow;
        public string Message { get; }

        public AuditEntry(string message)
        {
            Message = message;
        }
    }
}
