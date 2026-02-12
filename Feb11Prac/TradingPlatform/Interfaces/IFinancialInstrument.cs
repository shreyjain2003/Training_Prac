namespace TradingPlatform.Interfaces
{
    /// <summary>
    /// Represents a financial instrument.
    /// </summary>
    public interface IFinancialInstrument
    {
        string Symbol { get; }
        decimal CurrentPrice { get; set; }
        InstrumentType Type { get; }
    }

    public enum InstrumentType
    {
        Stock,
        Bond,
        Option,
        Future
    }
}
