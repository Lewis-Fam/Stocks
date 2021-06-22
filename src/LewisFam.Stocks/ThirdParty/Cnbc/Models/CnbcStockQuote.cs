using System.Collections.Generic;
using LewisFam.Stocks.Models;

namespace LewisFam.Stocks.ThirdParty.Cnbc.Models
{
    public partial class CnbcStockQuote  : Stock, ICnbcRealTimeStockQuote
    {
        public CnbcStockQuote()
        {
        }

        public virtual string AltName { get; set; }

        public virtual string AltSymbol { get; set; }

        public virtual string AssetSubType { get; set; }

        public virtual string AssetType { get; set; }

        public virtual string CachedTime { get; set; }

        public virtual string CacheServed { get; set; }

        public virtual double Change { get; set; }

        public virtual string ChangePct { get; set; }

        public virtual string Code { get; set; }

        public virtual string CountryCode { get; set; }

        public virtual string Curmktstatus { get; set; }

        public virtual string CurrencyCode { get; set; }

        public virtual EventData EventData { get; set; }

        public virtual ExtendedMktQuote ExtendedMktQuote { get; set; }

        public virtual string FullVolume { get; set; }

        public virtual FundamentalData FundamentalData { get; set; }

        public virtual double Close {get; set;}
        public virtual double High { get; set; }

        public virtual string IssueId { get; set; }

        public virtual string IssuerId { get; set; }

        public virtual double Last { get; set; }

        public virtual string LastTimeMsec { get; set; }

        public virtual double Low { get; set; }

        public virtual string Name { get; set; }

        public virtual string OnAirName { get; set; }

        public virtual double Open { get; set; }

        public virtual string PreviousDayClosing { get; set; }

        public virtual string PrevPrevClosing { get; set; }

        public virtual string RealTime { get; set; }

        public virtual string ResponseTime { get; set; }

        public virtual string ShortName { get; set; }

        public virtual string Source { get; set; }

        public virtual string Streamable { get; set; }

        public virtual string Symbol { get; set; }

        public virtual string SymbolType { get; set; }

        public virtual string TimeZone { get; set; }

        public virtual long Volume { get; set; }

        public virtual string StockName { get; set; }
        public virtual IList<ICnbcRealTimeStockQuote> Datas { get; set; }

        public virtual double Price {get; set;}

        public virtual double? PricePrevious {get; set;}

        public override string ToString()
        {
            return Symbol;
        }
    }
}