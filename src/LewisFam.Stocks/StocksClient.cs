using System.Collections.Generic;
using System.Threading.Tasks;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.ThirdParty.Services;
using LewisFam.Stocks.ThirdParty.Webull;

namespace LewisFam.Stocks
{
    public class StocksContext
    {
        public IEnumerable<Stock> Stocks { get; set; }
    }

    public partial class StocksClient
    {
        public static StocksClient Create()
        {
            return new StocksClient();
        }

        private StocksClient()
        {
            WebullDataService = new WebullDataService();
        }

        public StocksClient(IWebullDataService webullDataService)
        {
            WebullDataService = webullDataService;
        }

        public IWebullDataService WebullDataService { get; }
        
        public Task<IEnumerable<IRealTimeStockQuote>> GetRealTimeStockQuotesAsync(IEnumerable<Stock> stocks)
        {
            return WebullDataService?.GetRealTimeStockQuotesAsync(stocks);
        }
    }
}