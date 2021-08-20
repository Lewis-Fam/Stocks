namespace LewisFam.Stocks.Models
{
    public interface IStock
    {
        public string Symbol { get; }
        public long TickerId { get; }
    }
}