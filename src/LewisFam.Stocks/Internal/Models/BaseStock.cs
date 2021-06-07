using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Internal.Models
{
    /// <summary>
    /// The base stock.
    /// </summary>
    public abstract class BaseStock : IStock
    {
        //[NotMapped]
        public virtual string Symbol { get; set; }

        protected virtual Vendor? Vendor { get; set; }

        public override string ToString()
        {
            return Symbol;
        }
    }
}
