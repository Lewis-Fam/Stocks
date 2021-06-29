using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LewisFam.Stocks.Models;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    /// <summary>
    /// The option.
    /// </summary>
    public interface IWebullOptionQuote : IOptionQuote
    {
        public long TickerId { get; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        double? SpotPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        double? AskPrice { get; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        double? BidPrice { get; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        double? Close { get; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        double? High { get; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        double? Low { get; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        double? Open { get; }

        long? Volume { get; }

        long? OpenIntChange { get; }

        long? OpenInterest { get; }

        IEnumerable<WebullOptionQuote> Data { get; }        

        Guid? BatchId { get; set; }

        long? ActiveLevel {get;}

        double? Weekly { get; }
    }
}