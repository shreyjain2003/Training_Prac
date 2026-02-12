using System;
using RateLimiter.Services;

namespace RateLimiter
{
    public class Program
    {
        public static void Main()
        {
            var limiter = new SlidingWindowRateLimiter();
            string clientId = "ClientA";

            for (int i = 1; i <= 7; i++)
            {
                bool allowed = limiter.AllowRequest(clientId, DateTime.UtcNow);
                Console.WriteLine($"Request {i}: {(allowed ? "Allowed" : "Blocked")}");
            }
        }
    }
}
