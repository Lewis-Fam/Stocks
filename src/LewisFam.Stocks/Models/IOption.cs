using System;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Models
{
    public partial interface IOption : IStock
    {
        string Symbol { get; }
        double? StrikePrice { get;  }
        DateTime? ExpireDate { get;  }
        DirectionType? Direction { get;  }
        Slide? Slide { get; }
    }

}