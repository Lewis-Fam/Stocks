
using System;
using LewisFam.Stocks.Options.Models;


namespace LewisFam.Stocks.Entity
{
    public interface IOptionPrice : IOption
    {
        long ActiveLevel { get; set; }
        double? AskPrice { get; set; }
        long? AskVolume { get; set; }
        Guid BatchId { get; set; }
        double? BidPrice { get; set; }
        long? BidVolume { get; set; }        
        double Change { get; set; }
        double ChangeRatio { get; set; }
        double Close { get; set; }        
        double Delta { get; set; }
        double Gamma { get; set; }
        double High { get; set; }
        long Id { get; set; }
        double ImpVol { get; set; }
        double Low { get; set; }
        double Open { get; set; }
        long OpenIntChange { get; set; }
        long OpenInterest { get; set; }
        double PreClose { get; set; }        
        double QuoteMultiplier { get; set; }
        double Rho { get; set; }
        double SpotPrice { get; set; }
        string Symbol { get; }
        double Theta { get; set; }
        long TickerId { get; set; }
        string UnSymbol { get; set; }
        DateTimeOffset UpdatedOn { get; set; }
        double Vega { get; set; }
        long Volume { get; set; }
        double Weekly { get; set; }
        DateTimeOffset ExpireDate {get; set;}
    }
}