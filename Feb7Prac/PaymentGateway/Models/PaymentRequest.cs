namespace Q03_PaymentGateway.Models
{
    public class PaymentRequest
    {
        public decimal Amount { get; }

        public PaymentRequest(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be positive");

            Amount = amount;
        }
    }
}
