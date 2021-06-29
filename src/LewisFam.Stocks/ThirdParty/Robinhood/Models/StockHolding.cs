using LewisFam.Stocks.Models;

namespace LewisFam.Stocks.ThirdParty.Robinhood.Models
{
    /// <summary>
    /// The stock holding.
    /// </summary>
    public class StockHolding : Stock, IStockHolding
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockHolding"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="symbol">The symbol.</param>
        /// <param name="shares">The shares.</param>
        /// <param name="price">The price.</param>
        /// <param name="averageCost">The average cost.</param>
        /// <param name="equity">The equity.</param>
        public StockHolding(string name, string symbol, double shares, double price, double averageCost, double equity) : base(symbol)  //(string symbol, string name, double shares, double averageCost, double totalReturn, double equity) : base(symbol) //: this(symbol)
        {
            Name = name;
            Shares = shares;
            Price = price;
            AverageCost = averageCost;
            Equity = equity;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// Gets the shares.
        /// </summary>
        public virtual double Shares { get; }

        /// <summary>
        /// Gets the price.
        /// </summary>
        public virtual double Price { get; }

        /// <summary>
        /// Gets the average cost.
        /// </summary>
        public virtual double AverageCost { get; }

        /// <summary>
        /// Gets the total return.
        /// </summary>
        public virtual double TotalReturn => (Equity - (Shares * AverageCost));


        /// <summary>
        /// Gets the total return percentage.
        /// </summary>
        //[Display(Name = "TotalReturn%"), DisplayFormat(DataFormatString = "P")]
        public virtual double TotalReturnPercentage => (Price - AverageCost) / AverageCost;  //* 100 without DataFormatString = P

        /// <summary>
        /// Gets the equity.
        /// </summary>
        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public virtual double Equity { get; }
    }
}