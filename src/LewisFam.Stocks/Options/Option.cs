using System;
using LewisFam.Stocks.Internal.Models;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Options
{                                   
    public abstract class Option : BaseOption, IOption
    {
        protected Option()
        {
        }

        protected Option(IOption option)
        {
            StrikePrice = option.StrikePrice;
            ExpireDate = option.ExpireDate;
            Direction = option.Direction;
        }

        public sealed override double? StrikePrice { get;  set; }
        public sealed override DateTime? ExpireDate { get;  set; }
        public sealed override CallPut? Direction { get;  set; }
    }
}