using System;

namespace LewisFam.Stocks.Models
{   
    public interface IRealTimeStockQuote : IStockQuote
    {
        int TickerId { get; set; }
        int ExchangeId { get; set; }
        int Type { get; set; }
        int[] SecType { get; set; }
        int RegionId { get; set; }
        string RegionCode { get; set; }
        int CurrencyId { get; set; }
        string Name { get; set; }
        string Symbol { get; set; }
        string DisSymbol { get; set; }
        string DisExchangeCode { get; set; }
        string ExchangeCode { get; set; }
        int ListStatus { get; set; }
        string Template { get; set; }
        int DerivativeSupport { get; set; }
        DateTime TradeTime { get; set; }
        string Status { get; set; }
        double Close { get; set; }
        double Change { get; set; }
        double ChangeRatio { get; set; }
        double PPrice { get; set; }
        double PChange { get; set; }
        double PChRatio { get; set; }
        double MarketValue { get; set; }
        long Volume { get; set; }
        double TurnoverRate { get; set; }
        string TimeZone { get; set; }
        string TzName { get; set; }
        double PreClose { get; set; }
        double Open { get; set; }
        double High { get; set; }
        double Low { get; set; }
        double VibrateRatio { get; set; }
        long AvgVol10D { get; set; }
        long AvgVol3M { get; set; }
        double NegMarketValue { get; set; }
        double Pe { get; set; }
        double ForwardPe { get; set; }
        double IndicatedPe { get; set; }
        double PeTtm { get; set; }
        double Eps { get; set; }
        double EpsTtm { get; set; }
        double Pb { get; set; }
        long TotalShares { get; set; }
        long OutstandingShares { get; set; }
        double FiftyTwoWkHigh { get; set; }
        double FiftyTwoWkLow { get; set; }
        double Yield { get; set; }
        string CurrencyCode { get; set; }
        int LotSize { get; set; }
        string LatestEarningsDate { get; set; }
        double Ps { get; set; }
        double Bps { get; set; }
        string EstimateEarningsDate { get; set; }
        string TradeStatus { get; set; }
        string LimitUp { get; set; }
        string LimitDown { get; set; }
    }
}