using System;
using System.Collections.Generic;
using System.Linq;
using TradingPlatform.Interfaces;

namespace TradingPlatform.Services
{
    /// <summary>
    /// Generic portfolio managing financial instruments.
    /// </summary>
    public class Portfolio<T> where T : IFinancialInstrument
    {
        private readonly Dictionary<T, int> _holdings = new();
        private readonly Dictionary<T, decimal> _purchasePrices = new();

        /// <summary>
        /// Buys an instrument.
        /// </summary>
        public void Buy(T instrument, int quantity, decimal price)
        {
            if (quantity <= 0 || price <= 0)
                throw new ArgumentException("Quantity and price must be positive.");

            if (_holdings.ContainsKey(instrument))
                _holdings[instrument] += quantity;
            else
                _holdings[instrument] = quantity;

            _purchasePrices[instrument] = price;
        }

        /// <summary>
        /// Sells an instrument.
        /// </summary>
        public decimal? Sell(T instrument, int quantity, decimal currentPrice)
        {
            if (!_holdings.ContainsKey(instrument) || _holdings[instrument] < quantity)
                throw new InvalidOperationException("Not enough holdings to sell.");

            _holdings[instrument] -= quantity;

            if (_holdings[instrument] == 0)
                _holdings.Remove(instrument);

            return quantity * currentPrice;
        }

        /// <summary>
        /// Calculates total portfolio value.
        /// </summary>
        public decimal CalculateTotalValue()
        {
            return _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
        }

        /// <summary>
        /// Gets top-performing instrument.
        /// </summary>
        public (T instrument, decimal returnPercentage)? GetTopPerformer()
        {
            if (!_holdings.Any())
                return null;

            var performances = _holdings
                .Where(h => _purchasePrices.ContainsKey(h.Key))
                .Select(h =>
                {
                    var purchasePrice = _purchasePrices[h.Key];
                    var currentPrice = h.Key.CurrentPrice;
                    var returnPct = ((currentPrice - purchasePrice) / purchasePrice) * 100;
                    return (instrument: h.Key, returnPct);
                });

            return performances.OrderByDescending(p => p.returnPct).FirstOrDefault();
        }

        public IEnumerable<T> GetInstruments() => _holdings.Keys;
    }
}

