namespace MoneyTransferSystem.Models
{
    public class TransferResult
    {
        public bool Success { get; }
        public string Message { get; }

        public TransferResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
