using System;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.ThirdParty.Robinhood
{
    public interface IOptionHolding : IStock
    {
        CallPut Slide { get; }

        DateTime ExpireDate { get; }

        double LastPrice { get; }

        BuySell BuySell { get; }

        int Qty { get; }

        double StrikePrice { get; }

        double StrikePrice1 { get; }

        string Symbol { get; }

        double TodayReturnPerc { get; }
    }
}