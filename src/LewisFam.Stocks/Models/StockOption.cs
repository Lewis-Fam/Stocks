using System.Collections.Generic;
using System.Threading.Tasks;
using LewisFam.Stocks.ThirdParty.Webull.Models;

namespace LewisFam.Stocks.Models
{
    public class StockOption : Stock
    {
        private Stock _stock;
        private long _someId;
        private IWebullOptionQuote _option;

        //private Task<IEnumerable<IWebullOptionQuote>> _options;

        public StockOption(Stock stock, IWebullOptionQuote option) : base(stock)
        {
            _stock = stock;
            _option = option;
        }

        //public StockOption(string symbol, long tickerId) : base(symbol, tickerId)
        //{
        //    _stock = new Stock(symbol, tickerId);
        //}

        public Task<IEnumerable<IWebullOptionQuote>> GetAllStockOptionsAsync()
        {
            return StocksUtil.GetAllStockOptionsAsync(_stock);
        }

        
    }
}