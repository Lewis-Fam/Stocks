using System;
using LewisFam.Stocks.Models;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    public enum ChartDataType
    {
        m1,
        m5,
        m120,
        m240,
        d1,
    }

    public class StockChartDataModel 
    {
        public long TradeTimeUnix { get; set; }
        public double Last { get; set; }
        public double Close { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public long Volume { get; set; }
    }

    public class ChartData //: IMetaData<object>
        : IChartData
    {
        public long TickerId { get; set; }
        public string TimeZone { get; set; }
        public double PreClose { get; set; }
        public bool HasMore { get; set; }
        public bool ExchangeStatus { get; set; }
        public Date[] Dates { get; set; }
        public long Timestamp { get; set; }
        public object[] Data { get; set; }

        public class Date
        {
            public string Type { get; set; }
            public TimeSpan Start { get; set; }
            public TimeSpan End { get; set; }
            public int AvgShow { get; set; }
        }
    }
}