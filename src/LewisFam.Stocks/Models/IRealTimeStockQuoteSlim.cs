using System;

namespace LewisFam.Stocks.Models
{
    public interface IRealTimeStockQuoteSlim : IStockQuote
    {
        long Volume { get; set; }  

        long TickerId { get; set; }
        string Name { get; set; }
        string Symbol { get; set; }
        DateTime TradeTime { get; set; }
        double Close { get; set; }
        double Change { get; set; }
        double ChangeRatio { get; set; }
        double TurnoverRate { get; set; }

        double PreClose { get; set; }
        double Open { get; set; }
        double High { get; set; }
        double Low { get; set; }

        long AvgVol10D { get; set; }
        long AvgVol3M { get; set; }
        double NegMarketValue { get; set; }
        double Pe { get; set; }
        double ForwardPe { get; set; }
        double IndicatedPe { get; set; }
    }
}