using System;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{

    public class ChartData //: IMetaData<object>
        : IChartData
    {
        public virtual long TickerId { get; set; }
        public virtual string TimeZone { get; set; }
        public virtual double PreClose { get; set; }
        public virtual bool HasMore { get; set; }
        public virtual bool ExchangeStatus { get; set; }
        public virtual ChartDate[] Dates { get; set; }
        public virtual long Timestamp { get; set; }
        public virtual object[] Data { get; set; }

        public class ChartDate
        {
            public virtual string Type { get; set; }
            public virtual TimeSpan Start { get; set; }
            public virtual TimeSpan End { get; set; }
            public virtual int AvgShow { get; set; }
        }
    }
}