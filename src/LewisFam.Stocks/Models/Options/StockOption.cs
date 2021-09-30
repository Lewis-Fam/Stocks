using LewisFam.Stocks.Internal;
using LewisFam.Stocks.ThirdParty.Webull.Models;

namespace LewisFam.Stocks.Models
{

    public class StockOption : BaseOption
    {


        private Stock _stock;
        private long _someId;
        private IWebullOptionQuote _option;

        //private Task<IEnumerable<IWebullOptionQuote>> _options;

        public StockOption(Stock stock, IWebullOptionQuote option)
        {
            _stock = stock;
            _option = option;
        }

        public StockOption(Stock stock)
        {
            _stock = stock;
        }

        public int Id { get; set; }

        //public async Task<IEnumerable<IWebullOptionQuote>> GetAllStockOptionsAsync()
        //{
        //    //return await StocksUtil.GetAllStockOptionsAsync(_stock);
        //}
    }
}