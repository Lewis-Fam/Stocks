using System.Reflection;
using LewisFam.Stocks.Internal.Models;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    /// <summary>A stock class.</summary>
    public class Stock : BaseStock // LewisFam.Stocks.Models.Stock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class.
        /// </summary>
        protected Stock()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="tickerId"></param>
        public Stock(string symbol, long tickerId)
        {
            Symbol = symbol;
            TickerId = tickerId;            
        }

        ///<inheritdoc/>
        public override string ToString()
        {
            return $"{Symbol},{TickerId}";
        }

        private string _symbol;

        /// <summary>
        /// Gets or sets the symbol.ToUpper()
        /// </summary>
        public sealed override string Symbol
        {
            get { return _symbol.ToUpper(); }
            set { _symbol = value.ToUpper(); }
        }

        /// <summary>
        /// Gets or sets the ticker id.
        /// </summary>
        public long TickerId { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public virtual decimal Price { get; set; }

        /////// <summary>
        /////// Gets the vendor.
        /////// </summary>
        //protected override Vendor? Vendor => Stocks.Data.Enums.Vendor.Webull;
    }
}