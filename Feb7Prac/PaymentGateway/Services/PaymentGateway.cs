using System;
using System.Threading;
using System.Threading.Tasks;
using Q03_PaymentGateway.Models;

namespace Q03_PaymentGateway.Services
{
    public class PaymentGateway
    {
        private int _failureCount = 0;
        private DateTime _firstFailureTime = DateTime.MinValue;
        private DateTime _circuitOpenUntil = DateTime.MinValue;

        public async Task<PaymentResult> ProcessPaymentAsync(
            PaymentRequest request,
            CancellationToken token)
        {
            // Circuit is open → fail fast
            if (DateTime.UtcNow < _circuitOpenUntil)
            {
                return new PaymentResult(false, "Circuit is open. Try later.");
            }

            for (int attempt = 1; attempt <= 3; attempt++)
            {
                try
                {
                    token.ThrowIfCancellationRequested();

                    // Simulate external call
                    await Task.Delay(500, token);

                    // Random timeout simulation
                    if (Random.Shared.Next(2) == 0)
                        throw new TimeoutException();

                    // Success
                    ResetFailures();
                    return new PaymentResult(true, "Payment successful");
                }
                catch (TimeoutException)
                {
                    RegisterFailure();
                }
            }

            return new PaymentResult(false, "Payment failed after retries");
        }

        private void RegisterFailure()
        {
            var now = DateTime.UtcNow;

            if (_failureCount == 0)
                _firstFailureTime = now;

            _failureCount++;

            if (_failureCount >= 5 &&
                now - _firstFailureTime <= TimeSpan.FromMinutes(1))
            {
                _circuitOpenUntil = now.AddSeconds(30);
                _failureCount = 0;
            }
        }

        private void ResetFailures()
        {
            _failureCount = 0;
            _firstFailureTime = DateTime.MinValue;
        }
    }
}
