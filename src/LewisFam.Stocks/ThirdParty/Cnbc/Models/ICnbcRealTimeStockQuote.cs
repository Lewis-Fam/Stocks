using System.Collections.Generic;
using LewisFam.Stocks.Models;

namespace LewisFam.Stocks.ThirdParty.Cnbc.Models
{
    public interface ICnbcRealTimeStockQuote : LewisFam.Stocks.Models.IStockQuoteBase
    {  
        double Change { get; set; }

        new double Close { get; set; }        

        double High { get; set; }

        double Last { get; set; }

        double Low { get; set; }

        double Open { get; set; }

        double Price { get; set; }        

        long Volume { get; set; }        

        IList<ICnbcRealTimeStockQuote> Datas { get; set; }
        string AltName { get; set; }

        string AltSymbol { get; set; }

        string AssetSubType { get; set; }

        string AssetType { get; set; }

        string CachedTime { get; set; }

        string CacheServed { get; set; }

        string ChangePct { get; set; }

        string Code { get; set; }

        //string Comments { get; set; }

        string CountryCode { get; set; }

        string Curmktstatus { get; set; }

        string CurrencyCode { get; set; }

        EventData EventData { get; set; }

        //string Exchange { get; set; }

        ExtendedMktQuote ExtendedMktQuote { get; set; }

        string FullVolume { get; set; }

        FundamentalData FundamentalData { get; set; }

        string IssuerId { get; set; }

        string Name { get; set; }

        string OnAirName { get; set; }

        // string Provider { get; set; }

        string RealTime { get; set; }

        string ResponseTime { get; set; }

        string ShortName { get; set; }

        string Source { get; set; }

        string Streamable { get; set; }

        string SymbolType { get; set; }

        string TimeZone { get; set; }

        string PreviousDayClosing { get; set; }

        string PrevPrevClosing { get; set; }
    }
}