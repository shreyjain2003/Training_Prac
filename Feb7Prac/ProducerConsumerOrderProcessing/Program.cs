using System;
using System.Threading.Tasks;
using Q04_ProducerConsumer.Services;

namespace Q04_ProducerConsumer
{
    class Program
    {
        static async Task Main()
        {
            var processor = new OrderProcessor();

            // Start 3 consumers
            Task c1 = processor.StartConsumerAsync(1);
            Task c2 = processor.StartConsumerAsync(2);
            Task c3 = processor.StartConsumerAsync(3);

            // Producer
            processor.ProduceOrders(10);

            // Wait for all consumers to finish
            await Task.WhenAll(c1, c2, c3);

            Console.WriteLine(
                $"Total orders processed: {processor.GetProcessedCount()}");
        }
    }
}

