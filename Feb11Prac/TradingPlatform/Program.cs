using System;
using TradingPlatform.Models;
using TradingPlatform.Services;

namespace TradingPlatform
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("===== TRADING PLATFORM SIMULATION =====\n");

            var apple = new Stock
            {
                Symbol = "AAPL",
                CompanyName = "Apple Inc",
                CurrentPrice = 150,
                DividendYield = 1.5m
            };

            var bond = new Bond
            {
                Symbol = "GOV2028",
                CurrentPrice = 100,
                CouponRate = 6.5m,
                MaturityDate = new DateTime(2028, 1, 1)
            };

            var portfolio = new Portfolio<TradingPlatform.Interfaces.IFinancialInstrument>();

            portfolio.Buy(apple, 10, 120);
            portfolio.Buy(bond, 5, 95);

            apple.CurrentPrice = 170;
            bond.CurrentPrice = 102;

            Console.WriteLine($"Portfolio Value: {portfolio.CalculateTotalValue():C}");

            var top = portfolio.GetTopPerformer();
            if (top.HasValue)
                Console.WriteLine($"Top Performer: {top.Value.instrument.Symbol} " +
                                  $"Return: {top.Value.returnPercentage:F2}%");

            var history = new PriceHistory<TradingPlatform.Interfaces.IFinancialInstrument>();
            history.AddPrice(apple, DateTime.Now.AddDays(-3), 140);
            history.AddPrice(apple, DateTime.Now.AddDays(-2), 150);
            history.AddPrice(apple, DateTime.Now.AddDays(-1), 170);

            Console.WriteLine($"Moving Average: {history.GetMovingAverage(apple, 3)}");
            Console.WriteLine($"Trend: {history.DetectTrend(apple, 3)}");

            Console.WriteLine("\n===== SIMULATION COMPLETE =====");
        }
    }
}
