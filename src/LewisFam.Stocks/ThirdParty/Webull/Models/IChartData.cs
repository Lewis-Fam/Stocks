namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    public interface IChartData
    {
        long TickerId { get; set; }
        string TimeZone { get; set; }
        double PreClose { get; set; }
        bool HasMore { get; set; }
        bool ExchangeStatus { get; set; }
        ChartData.Date[] Dates { get; set; }
        long Timestamp { get; set; }
        object[] Data { get; set; }
    }
}