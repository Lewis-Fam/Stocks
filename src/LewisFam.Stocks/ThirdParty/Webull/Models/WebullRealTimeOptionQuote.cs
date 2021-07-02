using System;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    [Serializable]
    public partial class WebullRealTimeOptionQuote
    {
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public long StrikePrice { get; set; }
        public string PreClose { get; set; }
        public long OpenInterest { get; set; }
        public long Volume { get; set; }
        public long LatestPriceVol { get; set; }
        public string Delta { get; set; }
        public string Vega { get; set; }
        public string ImpVol { get; set; }
        public string Gamma { get; set; }
        public string Theta { get; set; }
        public string Rho { get; set; }
        public string Close { get; set; }
        public string Change { get; set; }
        public string ChangeRatio { get; set; }
        public string ExpireDate { get; set; }
        public long TickerId { get; set; }
        public long BelongTickerId { get; set; }
        public long OpenIntChange { get; set; }
        public long ActiveLevel { get; set; }
        public long Weekly { get; set; }
        public string Direction { get; set; }
        public long DerivativeStatus { get; set; }
        public long CurrencyId { get; set; }
        public long RegionId { get; set; }
        public long ExchangeId { get; set; }
        public string Symbol { get; set; }
        public string UnSymbol { get; set; }
        public BidAsk[] AskList { get; set; }
        public BidAsk[] BidList { get; set; }
        public long QuoteMultiplier { get; set; }
        public long QuoteLotSize { get; set; }
        public string TradeTime { get; set; }
        public string TradeStatus { get; set; }
        public long TradeStamp { get; set; }
    }
}