using System;

namespace LewisFam.Stocks.Models.Enums
{
    [Serializable]
    public enum MarketState
    {
        Unknown,
        Closed,
        Open,
        PreMarket,
        PostMarket,
    }
}