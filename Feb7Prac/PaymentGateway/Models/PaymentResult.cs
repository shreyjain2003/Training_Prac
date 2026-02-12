namespace Q03_PaymentGateway.Models
{
    public class PaymentResult
    {
        public bool Success { get; }
        public string Message { get; }

        public PaymentResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
