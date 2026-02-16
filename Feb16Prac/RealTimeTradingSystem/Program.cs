using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RealTimeTradingSystem
{
    /// <summary>
    /// Represents Buy or Sell side.
    /// </summary>
    public enum OrderSide
    {
        Buy,
        Sell
    }

    /// <summary>
    /// Generic order contract.
    /// </summary>
    public interface IOrder<T> where T : IComparable<T>
    {
        string OrderId { get; }
        T Instrument { get; }
        OrderSide Side { get; }
        decimal Price { get; }
        int Quantity { get; set; }
        DateTime Timestamp { get; }
        int Priority { get; }
    }

    /// <summary>
    /// Concrete order implementation.
    /// </summary>
    public class Order<T> : IOrder<T> where T : IComparable<T>
    {
        public required string OrderId { get; init; }
        public required T Instrument { get; init; }
        public OrderSide Side { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; set; }
        public DateTime Timestamp { get; init; }
        public int Priority { get; init; }
    }

    /// <summary>
    /// Represents executed trade match.
    /// </summary>
    public record OrderMatch<T>(
        string BuyOrderId,
        string SellOrderId,
        decimal Price,
        int Quantity,
        DateTime Timestamp
    );

    /// <summary>
    /// Thread-safe priority queue wrapper.
    /// </summary>
    public class ConcurrentPriorityQueue<T>
    {
        private readonly PriorityQueue<T, decimal> _queue = new();
        private readonly object _lock = new();

        public void Enqueue(T item, decimal priority)
        {
            lock (_lock)
                _queue.Enqueue(item, priority);
        }

        public bool TryDequeue(out T item)
        {
            lock (_lock)
            {
                if (_queue.Count > 0)
                {
                    item = _queue.Dequeue();
                    return true;
                }

                item = default!;
                return false;
            }
        }

        public int Count
        {
            get
            {
                lock (_lock)
                    return _queue.Count;
            }
        }
    }

    /// <summary>
    /// High-frequency trading Order Book.
    /// Supports matching engine and VWAP analytics.
    /// </summary>
    public class OrderBook<T> where T : IComparable<T>
    {
        private readonly ConcurrentDictionary<string, IOrder<T>> _allOrders = new();
        private readonly ConcurrentPriorityQueue<IOrder<T>> _buyOrders = new();
        private readonly ConcurrentPriorityQueue<IOrder<T>> _sellOrders = new();
        private readonly ConcurrentBag<OrderMatch<T>> _matchHistory = new();

        private double _totalTradedValue = 0;
        private long _totalTradedVolume = 0;

        /// <summary>
        /// Processes an order asynchronously.
        /// </summary>
        public async Task ProcessOrderAsync(IOrder<T> order)
        {
            _allOrders[order.OrderId] = order;

            if (order.Side == OrderSide.Buy)
                _buyOrders.Enqueue(order, -order.Price); // Higher price priority
            else
                _sellOrders.Enqueue(order, order.Price); // Lower price priority

            await MatchOrdersAsync();
        }

        /// <summary>
        /// Matching engine logic.
        /// Handles partial fills.
        /// </summary>
        private Task MatchOrdersAsync()
        {
            while (_buyOrders.Count > 0 && _sellOrders.Count > 0)
            {
                if (!_buyOrders.TryDequeue(out var buy)) break;
                if (!_sellOrders.TryDequeue(out var sell)) break;

                if (buy.Price < sell.Price)
                {
                    _buyOrders.Enqueue(buy, -buy.Price);
                    _sellOrders.Enqueue(sell, sell.Price);
                    break;
                }

                int matchedQty = Math.Min(buy.Quantity, sell.Quantity);

                buy.Quantity -= matchedQty;
                sell.Quantity -= matchedQty;

                var match = new OrderMatch<T>(
                    buy.OrderId,
                    sell.OrderId,
                    sell.Price,
                    matchedQty,
                    DateTime.UtcNow);

                _matchHistory.Add(match);

                _totalTradedValue += (double)(matchedQty * sell.Price);
                Interlocked.Add(ref _totalTradedVolume, matchedQty);

                if (buy.Quantity > 0)
                    _buyOrders.Enqueue(buy, -buy.Price);

                if (sell.Quantity > 0)
                    _sellOrders.Enqueue(sell, sell.Price);
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Returns recent matches using PLINQ.
        /// </summary>
        public IEnumerable<OrderMatch<T>> GetOrderMatches(int count)
        {
            return _matchHistory
                .AsParallel()
                .OrderByDescending(m => m.Timestamp)
                .Take(count)
                .ToList();
        }

        /// <summary>
        /// Calculates Volume Weighted Average Price.
        /// </summary>
        public double CalculateVWAP()
        {
            if (_totalTradedVolume == 0) return 0;
            return _totalTradedValue / _totalTradedVolume;
        }
    }

    /// <summary>
    /// Entry point.
    /// </summary>
    public class Program
    {
        public static async Task Main()
        {
            var orderBook = new OrderBook<string>();

            var buyOrder = new Order<string>
            {
                OrderId = "B1",
                Instrument = "AAPL",
                Side = OrderSide.Buy,
                Price = 150,
                Quantity = 100,
                Timestamp = DateTime.UtcNow,
                Priority = 1
            };

            var sellOrder = new Order<string>
            {
                OrderId = "S1",
                Instrument = "AAPL",
                Side = OrderSide.Sell,
                Price = 149,
                Quantity = 100,
                Timestamp = DateTime.UtcNow,
                Priority = 1
            };

            await orderBook.ProcessOrderAsync(buyOrder);
            await orderBook.ProcessOrderAsync(sellOrder);

            Console.WriteLine("Recent Matches:");
            foreach (var match in orderBook.GetOrderMatches(5))
            {
                Console.WriteLine($"{match.BuyOrderId} matched with {match.SellOrderId} at {match.Price}");
            }

            Console.WriteLine($"VWAP: {orderBook.CalculateVWAP()}");
        }
    }
}
