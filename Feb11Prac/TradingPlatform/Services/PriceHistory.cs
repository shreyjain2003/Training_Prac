using System;
using System.Collections.Generic;
using System.Linq;
using TradingPlatform.Interfaces;

namespace TradingPlatform.Services
{
    public enum Trend { Upward, Downward, Sideways }

    /// <summary>
    /// Tracks historical price data.
    /// </summary>
    public class PriceHistory<T> where T : IFinancialInstrument
    {
        private readonly Dictionary<T, List<(DateTime Date, decimal Price)>> _history = new();

        public void AddPrice(T instrument, DateTime timestamp, decimal price)
        {
            if (!_history.ContainsKey(instrument))
                _history[instrument] = new();

            _history[instrument].Add((timestamp, price));
        }

        public decimal? GetMovingAverage(T instrument, int days)
        {
            if (!_history.ContainsKey(instrument))
                return null;

            var recent = _history[instrument]
                .OrderByDescending(p => p.Date)
                .Take(days)
                .Select(p => p.Price);

            if (!recent.Any())
                return null;

            return Math.Round(recent.Average(), 2);
        }

        public Trend DetectTrend(T instrument, int period)
        {
            if (!_history.ContainsKey(instrument) ||
                _history[instrument].Count < period)
                return Trend.Sideways;

            var recent = _history[instrument]
                .OrderByDescending(p => p.Date)
                .Take(period)
                .Select(p => p.Price)
                .ToList();

            if (recent.First() > recent.Last())
                return Trend.Upward;
            if (recent.First() < recent.Last())
                return Trend.Downward;

            return Trend.Sideways;
        }
    }
}

