using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LewisFam.Stocks.Internal.Models;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Options;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    /// <summary>
    /// The option.
    /// </summary>
    [Serializable]
    public sealed class WebullOptionQuote : RealTimeOptionQuote, IWebullOptionQuote
    {
        public WebullOptionQuote()
        {
        }

        [NotMapped]
        public override Stock Stock { get; set; }

        public WebullOptionQuote(Stock stock)
        {
            Stock = stock;
        }
        
        public long Id { get; set; }

        //public long TickerId { get; set; }

        /////<inheritdoc cref="BaseOption.Slide"/>
        //public override Slide? Slide { get; set; }

        //public override DateTime? ExpireDate { get; set; }

        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        //public override double? StrikePrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double? AskPrice
        {
            get
            {
                return AskList?[0].Price;
            }
        }

        public long? AskVolume
        {
            get
            {
                return AskList?[0].Volume;
            }
        }

        public double? BidPrice
        {
            get
            {
                return BidList?[0].Price;
            }
        }

        public long? BidVolume
        {
            get
            {
                return BidList?[0].Volume;
            }
        }

        public double? Last => Close;
        //public double? Change { get; set; }
        //public double? ChangeRatio { get; set; }
        public long? Volume { get; set; }
        public override double? Close { get; set; }
        public double? High { get; set; }
        public double? Low { get; set; }
        public double? Open { get; set; }
        public double? PreClose { get; set; }
        public long? OpenIntChange { get; set; }
        public long? OpenInterest { get; set; }
        public long QuoteMultiplier { get; set; }
        public string UnSymbol { get; set; }
        public double? ImpVol { get; set; }
        public double? Theta { get; set; }
        public double? Rho { get; set; }
        public double? Delta { get; set; }
        public double? Gamma { get; set; }
        public double? Vega { get; set; }        
        public double? SpotPrice { get; set; }
        public long? ActiveLevel { get; set; }
        public double? Weekly { get; set; }
        public Guid? BatchId { get; set; }
        private IList<BidAsk> AskList { get; set; }
        private IList<BidAsk> BidList { get; set; }
        [NotMapped]
        public IEnumerable<WebullOptionQuote> Data { get; set; }
        [NotMapped]
        public IEnumerable<ExpireOn> ExpireDateList { get; set; }
        [NotMapped]
        public WebullOptionQuote Call { get; set; }
        [NotMapped]
        public WebullOptionQuote Put { get; set; }
        public DateTimeOffset UpdatedOn { get; private set; } = DateTime.UtcNow;
        //protected override IGreeks Greeks { get; set; }        
        public override string ToString()
        {
            return $"{Direction}|{TickerId}|{ExpireDate:yyyy-MM-dd}|{StrikePrice:C}|{UnSymbol}";
        }
    }
}
