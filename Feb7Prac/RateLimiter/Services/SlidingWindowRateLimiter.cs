using System;
namespace RateLimiter.Services
{
    public class SlidingWindowRateLimiter
    {
        private readonly Dictionary<string, Queue<DateTime>> _clientRequests = new();
        private const int MAX_REQUESTS = 5;
        private static readonly TimeSpan WINDOW = TimeSpan.FromSeconds(10);

        public bool AllowRequest(string clientId, DateTime now)
        {
            if (!_clientRequests.ContainsKey(clientId))
            {
                _clientRequests[clientId] = new Queue<DateTime>();
            }

            var queue = _clientRequests[clientId];

            lock (queue) // thread safety per client
            {
                // Remove old requests outside sliding window
                while (queue.Count > 0 && now - queue.Peek() > WINDOW)
                {
                    queue.Dequeue();
                }

                if (queue.Count >= MAX_REQUESTS)
                {
                    return false; // rate limit exceeded
                }

                queue.Enqueue(now);
                return true;
            }
        }
    }
}