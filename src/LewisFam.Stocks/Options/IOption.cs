using System;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Options
{
    public partial interface IOption : IStock
    {
        string Symbol { get; }
        double? StrikePrice { get;  }
        DateTime? ExpireDate { get;  }
        CallPut? Direction { get;  }
    }

}