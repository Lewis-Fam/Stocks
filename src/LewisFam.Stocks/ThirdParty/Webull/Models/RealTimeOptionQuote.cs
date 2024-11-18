using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using LewisFam.Stocks.Models.Enums;
using LewisFam.Stocks.Options.Models;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    [Serializable]
    public class RealTimeOptionQuote : Option, IRealTimeOptionQuote
    {
        public RealTimeOptionQuote()
        {
        }

        public virtual long? ActiveLevel { get; set; }

        [NotMapped]
        public virtual List<BidAsk> AskList { get; set; } = new List<BidAsk>();

        public virtual double? AskPrice
        {
            get
            {
                if (AskList.Any())
                    return AskList[0].Price;
                return null;
            }
        }

        public virtual long? AskVolume
        {
            get
            {
                if (AskList.Any())
                    return AskList[0]?.Volume;

                return null;
            }
        }

        public virtual long? BelongTickerId { get; set; }

        [NotMapped]
        public virtual List<BidAsk> BidList { get; set; } = new List<BidAsk>(); 

        public virtual double? BidPrice
        {
            get
            {
                if (BidList.Any())
                    return BidList[0]?.Price;

                return null;
            }
        }

        public virtual long? BidVolume
        {
            get
            {
                if (BidList.Any())
                    return BidList[0]?.Volume;

                return null;
            }
        }

        public virtual double? Change { get; set; }

        public virtual string ChangeRatio { get; set; }

        public virtual double? Close { get; set; }

        public virtual long? CurrencyId { get; set; }

        public virtual double? Delta { get; set; }

        public virtual long? DerivativeStatus { get; set; }

        public virtual long? ExchangeId { get; set; }

        public virtual double? Gamma { get; set; }

        public virtual double? High { get; set; }

        public virtual double? ImpVol { get; set; }

        public virtual double? IntrinsicValue => calculateIntrinsicValue();

        public virtual bool? ITM => IntrinsicValue > 0;

        public virtual long? LatestPriceVol { get; set; }

        public virtual double? Low { get; set; }

        public virtual double? MarkPrice => calculateMarkPrice();

        public virtual double? Open { get; set; }

        public virtual long? OpenIntChange { get; set; }

        public virtual long? OpenInterest { get; set; }

        public virtual double? PreClose { get; set; }
        
        public virtual long? QuoteLotSize { get; set; }

        public virtual long? QuoteMultiplier { get; set; }

        public virtual long? RegionId { get; set; }

        public virtual double? Rho { get; set; }

        public virtual double? SpotPrice { get; set; }

        public virtual double? Theta { get; set; }

        public virtual long? TradeStamp { get; set; }

        public virtual string TradeStatus { get; set; }

        public virtual string TradeTime { get; set; }

        public virtual string UnSymbol { get; set; }

        public virtual double? Vega { get; set; }

        public virtual long? Volume { get; set; }
        
        public virtual long? Weekly { get; set; }
        
        private double? calculateIntrinsicValue()
        {
            if (SpotPrice > 0)
            {
                if (Direction == CallPut.Call)
                {
                    return (SpotPrice - StrikePrice);
                }
                if (Direction == CallPut.Put)
                {
                    return (StrikePrice - SpotPrice);
                }
            }
            return null;
        }

        private double? calculateMarkPrice()
        {
            double?[] numbers =
            {
                BidPrice, AskPrice
            };

            return numbers.Average();
        }
    }
}