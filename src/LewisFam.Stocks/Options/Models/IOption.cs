using System;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Options.Models
{
    public partial interface IOption : IStock
    {
        Stock Stock { get; }
        double StrikePrice { get;  }
        DateTime ExpireDate { get;  }
        CallPut Direction { get;  }
    }

}