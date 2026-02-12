using TradingPlatform.Interfaces;

namespace TradingPlatform.Models
{
    /// <summary>
    /// Represents a stock instrument.
    /// </summary>
    public class Stock : IFinancialInstrument
    {
        public required string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public InstrumentType Type => InstrumentType.Stock;

        public required string CompanyName { get; set; }
        public decimal DividendYield { get; set; }
    }
}

