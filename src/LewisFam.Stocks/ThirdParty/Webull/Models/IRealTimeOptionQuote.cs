using System;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;
using LewisFam.Stocks.Options.Models;
using LewisFam.Stocks.ThirdParty.Webull.Models;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    public interface IRealTimeOptionQuote : IOption
    {
        long TickerId { get; set;}
        double StrikePrice { get; set; }
        DateTime ExpireDate { get; set; }
        CallPut Direction { get; set; }
        double? AskPrice { get; }
        long? AskVolume { get; }
        double? BidPrice { get; }
        long? BidVolume { get; }
        double? MarkPrice { get; }
        double? Close { get; set; }
        double? Open { get; set; }
        double? High { get; set; }
        double? Low { get; set; }
        double? PreClose { get; set; }
        long? Volume { get; set; }
        long? OpenInterest { get; set; }
        long? LatestPriceVol { get; set; }
        double? Delta { get; set; }
        double? Vega { get; set; }
        double? ImpVol { get; set; }
        double? Gamma { get; set; }
        double? Theta { get; set; }
        double? Rho { get; set; }
        double? Change { get; set; }
        string ChangeRatio { get; set; }
        long? BelongTickerId { get; set; }
        long? OpenIntChange { get; set; }
        long? ActiveLevel { get; set; }
        long? Weekly { get; set; }
        long? DerivativeStatus { get; set; }
        long? CurrencyId { get; set; }
        long? RegionId { get; set; }
        long? ExchangeId { get; set; }
        string UnSymbol { get; set; }
        BidAsk?[] AskList { get; set; }
        BidAsk?[] BidList { get; set; }
        long? QuoteMultiplier { get; set; }
        long? QuoteLotSize { get; set; }
        string TradeTime { get; set; }
        string TradeStatus { get; set; }
        long? TradeStamp { get; set; }
    }
}