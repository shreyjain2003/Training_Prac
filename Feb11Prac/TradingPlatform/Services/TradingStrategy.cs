using System;
using TradingPlatform.Interfaces;

namespace TradingPlatform.Services
{
    /// <summary>
    /// Generic trading strategy using lambda conditions.
    /// </summary>
    public class TradingStrategy<T> where T : IFinancialInstrument
    {
        public void Execute(
            Portfolio<T> portfolio,
            Func<T, bool> buyCondition,
            Func<T, bool> sellCondition)
        {
            foreach (var instrument in portfolio.GetInstruments())
            {
                if (sellCondition(instrument))
                {
                    Console.WriteLine($"Selling {instrument.Symbol}");
                }
                else if (buyCondition(instrument))
                {
                    Console.WriteLine($"Buying more of {instrument.Symbol}");
                }
            }
        }
    }
}

