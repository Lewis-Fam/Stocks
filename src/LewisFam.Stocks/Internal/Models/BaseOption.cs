using System;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Internal.Models
{
    /// <summary>
    /// The base stock option.
    /// </summary>
    public abstract class BaseOption : BaseStock
    {
        public virtual double? StrikePrice { get; set; }
        public virtual DateTime? ExpireDate { get; set; }
        public virtual DirectionType? Direction { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="LewisFam.Stocks.Models.Enums.Slide"/>.
        /// </summary>
        public virtual Slide? Slide { get; set; }

        public virtual double Multiplier => 100.0;
        
        ///<inheritdoc cref="IGreeks"/>
        public virtual IGreeks Greeks { get; set; }

        ///<inheritdoc/>
        public override string ToString()
        {
            return $"{Symbol}|{Slide}|{ExpireDate}|{StrikePrice}";
        }
    }
}
