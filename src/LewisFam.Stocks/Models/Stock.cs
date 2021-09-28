using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using LewisFam.Models;

namespace LewisFam.Stocks.Models
{
    /// <summary>A stock class.</summary>
    [Serializable]
    public class Stock : BindableObject, IStock // LewisFam.Stocks.Models.Stock
    {
        public Stock()
        {
            TickerId = -1;
        }

        public Stock(IStock stock)
        {
            Symbol = stock.Symbol;
            TickerId = stock.TickerId;
            Price = stock.Price;
        }

        public Stock(string symbol, long? tickerId = null, double? lastPrice = null)
        {
            Symbol = symbol;
            TickerId = tickerId ?? -1;
            Price = lastPrice;
        }

        public long FindTickerId()
        {
            var stock = StocksUtil.FindStockAsync(Symbol).Result;
            TickerId = stock.TickerId;
            return TickerId;
        }

        public async Task<long> FindTickerIdAsync()
        {
            var stock = await StocksUtil.FindStockAsync(Symbol);
            TickerId = stock.TickerId;
            return TickerId;
        }

        public long TickerId { get; set; }

        public string Name { get; set; }

        public double? Price { get; set; }

        public bool HasTickerId => TickerId > 0;

        ///<inheritdoc/>
        public override string ToString()
        {
            return $"{Symbol}|{TickerId}";
        }

        private string _symbol;

        /// <summary>
        /// Gets or sets the symbol.ToUpper()
        /// </summary>
        [MaxLength(50)]
        public string Symbol
        {
            get => _symbol?.ToUpper();
            set => _symbol = value?.ToUpper();
        }
    }
}