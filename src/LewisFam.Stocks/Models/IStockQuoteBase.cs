namespace LewisFam.Stocks.Models
{
    public partial interface IStockQuoteBase : IStock
    {
        string Symbol { get; set; }
        double Change { get; set; }
        double Close { get; set; } 
        double High { get; set; }
        double Low { get; set; }
        double Open { get; set; }
        long Volume { get; set; }        
    }

}