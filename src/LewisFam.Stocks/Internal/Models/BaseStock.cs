using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Internal.Models
{
    /// <summary>
    /// The base stock.
    /// </summary>
    public abstract class BaseStock : IStock
    {
        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        public virtual string Symbol { get; set; }

        protected virtual Vendor? Vendor { get; set; }

        public override string ToString()
        {
            return Symbol;
        }
    }
}
