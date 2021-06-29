using System;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{

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