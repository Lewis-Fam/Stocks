namespace LewisFam.Stocks.Models
{
    //public class Stock : BaseStock
    //{
    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="Stock"/> class.
    //    /// </summary>
    //    public Stock()
    //    {
    //    }

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="Stock"/> class.
    //    /// </summary>
    //    /// <param name="symbol"></param>
    //    /// <param name="tickerId"></param>
    //    public Stock(string symbol, long tickerId)
    //    {
    //        Symbol = symbol;
    //        TickerId = tickerId;            
    //    }

    //    ///<inheritdoc/>
    //    public override string ToString()
    //    {
    //        return $"{Symbol},{TickerId}";
    //    }

    //    private string _symbol;

    //    /// <summary>
    //    /// Gets or sets the symbol.ToUpper()
    //    /// </summary>
    //    public sealed override string Symbol
    //    {
    //        get { return _symbol.ToUpper(); }
    //        set { _symbol = value.ToUpper(); }
    //    }

    //    /// <summary>
    //    /// Gets or sets the ticker id.
    //    /// </summary>
    //    public long TickerId { get; set; }

    //    /////// <summary>
    //    /////// Gets the vendor.
    //    /////// </summary>
    //    //protected override Vendor? Vendor => Stocks.Data.Enums.Vendor.Webull;
    //}

    public interface IStock
    {
        public string Symbol { get; }
        public long TickerId { get; }
    }
}