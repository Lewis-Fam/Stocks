using LewisFam.Stocks.Options.Models;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    public interface IRealTimeOptionQuote : IOption
    {
        double? Open { get; set; }
        double? High { get; set; }
        double? Low { get; set; }
        //double? StrikePrice { get; set; }
        double? PreClose { get; set; }
        long? OpenInterest { get; set; }
        long? Volume { get; set; }
        long? LatestPriceVol { get; set; }
        double? Delta { get; set; }
        double? Vega { get; set; }
        double? ImpVol { get; set; }
        double? Gamma { get; set; }
        double? Theta { get; set; }
        double? Rho { get; set; }
        double? Close { get; set; }
        double? Change { get; set; }
        string ChangeRatio { get; set; }
        //long TickerId { get; set;}
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
        double Multiplier { get; }
    }
}