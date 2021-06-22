using LewisFam.Models;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Internal.Models
{
    /// <summary>
    /// The base stock.
    /// </summary>
    public abstract class BaseStock : BindableObject, IStock
    {
        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        public virtual string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the ticker id.
        /// </summary>
        public virtual long TickerId { get; set; }


        /// <summary>
        /// Gets or sets the <see cref="Stocks.Models.Enums.Vendor"/>.
        /// </summary>
        protected virtual Vendor? Vendor { get; set; }

        public override string ToString()
        {
            return Symbol;
        }
    }
}
