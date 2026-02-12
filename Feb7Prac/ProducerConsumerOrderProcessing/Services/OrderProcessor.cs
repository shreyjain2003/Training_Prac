using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Q04_ProducerConsumer.Models;

namespace Q04_ProducerConsumer.Services
{
    public class OrderProcessor
    {
        private readonly BlockingCollection<Order> _queue =
            new BlockingCollection<Order>();

        private int _processedCount = 0;

        public void ProduceOrders(int totalOrders)
        {
            for (int i = 1; i <= totalOrders; i++)
            {
                _queue.Add(new Order(i));
            }

            // Signal: no more orders will be added
            _queue.CompleteAdding();
        }

        public Task StartConsumerAsync(int consumerId)
        {
            return Task.Run(async () =>
            {
                foreach (var order in _queue.GetConsumingEnumerable())
                {
                    // Simulate processing time
                    await Task.Delay(500);

                    Interlocked.Increment(ref _processedCount);
                }
            });
        }

        public int GetProcessedCount() => _processedCount;
    }
}
