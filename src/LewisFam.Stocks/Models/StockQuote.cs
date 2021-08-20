namespace LewisFam.Stocks.Models
{
    public abstract class StockQuote : Stock, IStockQuote
    {
        protected StockQuote()
        {
        }

        protected StockQuote(IStock stock) : base(stock)
        {
        }

        protected StockQuote(string symbol, long? tickerId) : base(symbol, tickerId)
        {
        }

        #region Properties

        public virtual double Close { get; set; }

        public virtual double High { get; set; }

        public virtual double Low { get; set; }

        public virtual double Open { get; set; }

        public virtual string Symbol { get; set; }

        public virtual long Volume { get; set; }

        #endregion Properties
    }
}