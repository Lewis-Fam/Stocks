using System;

namespace LewisFam.Stocks.Models.Enums
{
    [Serializable]
    public enum Slide
    {
        Call,
        Put
    }

    public enum OptionType
    {

    }

    [Serializable]
    public enum SearchBy
    {
        Strike,
        Close,
        Mid,
        High,
        Low,
        Expiration,
    }

}