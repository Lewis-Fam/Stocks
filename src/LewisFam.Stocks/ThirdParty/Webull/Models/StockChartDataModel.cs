namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    public class StockChartDataModel 
    {
        public long TradeTimeUnix { get; set; }
        public double? Last { get; set; }
        public double? Close { get; set; }
        public double? High { get; set; }
        public double? Low { get; set; }
        public double? Open { get; set; }
        public long? Volume { get; set; }
        public double? DayOpen { get; set; }
    }
}