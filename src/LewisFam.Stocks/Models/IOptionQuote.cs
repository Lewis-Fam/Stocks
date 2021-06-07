using System;
using System.ComponentModel.DataAnnotations;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Models
{
    public partial interface IOptionQuote : IOption
    {
        double? StrikePrice { get;  }
        DateTime? ExpireDate { get;  }
        DirectionType? Direction { get;  }
        Slide? Slide { get; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double? Close { get; }
    }
}