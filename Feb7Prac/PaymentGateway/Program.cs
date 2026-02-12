using System;
using System.Threading;
using System.Threading.Tasks;
using Q03_PaymentGateway.Models;
using Q03_PaymentGateway.Services;

namespace Q03_PaymentGateway
{
    class Program
    {
        static async Task Main()
        {
            var gateway = new PaymentGateway();
            var request = new PaymentRequest(2500);

            using var cts = new CancellationTokenSource();

            var result = await gateway.ProcessPaymentAsync(request, cts.Token);
            Console.WriteLine(result.Message);
        }
    }
}
