using System;
using LewisFam.Stocks.Internal;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Options.Models
{                                   
    public abstract class Option : BaseOption
    {
        private DateTime _expireDate;
        protected Option()
        {
        }

        protected Option(IOption option)
        {
            StrikePrice = option.StrikePrice;
            ExpireDate = option.ExpireDate;
            Direction = option.Direction;
        }

        public sealed override double StrikePrice { get; set; }

        public sealed override DateTime ExpireDate
        {
            get => _expireDate.ToUniversalTime();
            set => _expireDate = value.ToUniversalTime();
        }

        public sealed override CallPut Direction { get; set; }
    }
}