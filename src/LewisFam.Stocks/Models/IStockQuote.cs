namespace LewisFam.Stocks.Models
{
    public partial interface IStockQuote : IStock
    {
        double Close { get; set; } 
        double High { get; set; }
        double Low { get; set; }
        double Open { get; set; }
        long Volume { get; set; }        
    }

}