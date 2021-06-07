using System;

namespace LewisFam.Stocks.ThirdParty.Cnbc.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MarketPrice" />
    public class PriceBar : MarketPrice
    {
        private string temp = "Date,Open,High,Low,Close,Volume,Adj Close";

        public virtual double? Adj_Close { get; set; }

        protected virtual string Date => DateTimeOffset.FromUnixTimeMilliseconds(TradeTimeinMills).ToString("G");

        public virtual long TradeTimeinMills { get; set; }
    }
}