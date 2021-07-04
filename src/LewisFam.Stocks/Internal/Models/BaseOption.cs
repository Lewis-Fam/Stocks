using System;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Internal.Models
{
    /// <summary>
    /// The base stock option.
    /// </summary>
    public abstract class BaseOption : IStock
    {
        public virtual double? StrikePrice { get; set; }
        public virtual DateTime? ExpireDate { get; set; }
        public virtual DirectionType? Direction { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="LewisFam.Stocks.Models.Enums.Slide"/>.
        /// </summary>
        public virtual Slide? Slide { get; set; }

        public virtual double Multiplier => 100.0;

        public long TickerId { get; set; }

        private string _symbol;

        /// <summary>
        /// Gets or sets the symbol.ToUpper()
        /// </summary>
        public string Symbol
        {
            get { return _symbol?.ToUpper(); }
            set { _symbol = value?.ToUpper(); }
        }

        ///<inheritdoc/>
        public override string ToString()
        {
            return $"{Symbol}|{Direction}|{ExpireDate}|{StrikePrice}";
        }
    }
}
