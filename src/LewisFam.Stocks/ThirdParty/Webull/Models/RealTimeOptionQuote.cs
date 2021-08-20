using System;
using LewisFam.Stocks.Internal.Models;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{

    [Serializable]
    public class RealTimeOptionQuote : BaseOption, IRealTimeOptionQuote
    {
        public virtual double? Open { get; set; }
        public virtual double? High { get; set; }
        public virtual double? Low { get; set; }
        //public override double? StrikePrice { get; set; }
        public virtual double? PreClose { get; set; }
        public virtual long? OpenInterest { get; set; }
        public virtual long? Volume { get; set; }
        public virtual long? LatestPriceVol { get; set; }
        public virtual double? Delta { get; set; }
        public virtual double? Vega { get; set; }
        public virtual double? ImpVol { get; set; }
        public virtual double? Gamma { get; set; }
        public virtual double? Theta { get; set; }
        public virtual double? Rho { get; set; }
        public virtual double? Close { get; set; }
        public virtual double? Change { get; set; }
        public virtual string ChangeRatio { get; set; }
        //public override DateTime? ExpireDate { get; set; }
        public virtual long? BelongTickerId { get; set; }
        public virtual long? OpenIntChange { get; set; }
        public virtual long? ActiveLevel { get; set; }
        public virtual long? Weekly { get; set; }
        //public virtual CallPut? Direction { get; set; }
        public virtual long? DerivativeStatus { get; set; }
        public virtual long? CurrencyId { get; set; }
        public virtual long? RegionId { get; set; }
        public virtual long? ExchangeId { get; set; }
        public virtual string UnSymbol { get; set; }
        public virtual BidAsk[] AskList { get; set; }
        public virtual BidAsk[] BidList { get; set; }
        public virtual long? QuoteMultiplier { get; set; }
        public virtual long? QuoteLotSize { get; set; }
        public virtual string TradeTime { get; set; }
        public virtual string TradeStatus { get; set; }
        public virtual long? TradeStamp { get; set; }
    }
}