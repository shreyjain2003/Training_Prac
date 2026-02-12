using System;
using TradingPlatform.Interfaces;

namespace TradingPlatform.Models
{
    /// <summary>
    /// Represents a bond instrument.
    /// </summary>
    public class Bond : IFinancialInstrument
    {
        public required string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public InstrumentType Type => InstrumentType.Bond;

        public DateTime MaturityDate { get; set; }
        public decimal CouponRate { get; set; }
    }
}

