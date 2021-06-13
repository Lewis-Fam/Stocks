using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LewisFam.Stocks.Models;
using LewisFam.Stocks.ThirdParty.Cnbc;
using LewisFam.Stocks.ThirdParty.Cnbc.Models;
using LewisFam.Stocks.ThirdParty.Webull;
using LewisFam.Stocks.ThirdParty.Webull.Models;

namespace LewisFam.Stocks
{
    /// <summary>Stocks</summary>
    public static partial class StocksUtil
    {
        private static readonly WebullDataService _webull = new WebullDataService();
        private static readonly CnbcDataService _cnbc = new CnbcDataService();

        /// <summary>Gets a sample stock list.</summary>
        public static IList<Stock> StockList2021 => new List<Stock>
        {
            new Stock("SPCE", 950052430),
            new Stock("ROKU", 925376726),
            new Stock("MSFT", 913323997),
            new Stock("NVDA", 913257561),
            new Stock("BA", 913254998),

            new Stock("U", 950172451),
            new Stock("RBLX", 950178170),
            new Stock("AEVA", 950157726),
            new Stock("CCIV", 950173643),
            new Stock("FIVE", 913255714),

            new Stock("RIOT", 925163605),
            new Stock("SNOW", 950173560),
            new Stock("CRSP", 913433908),
            new Stock("DIS", 913255192),
            new Stock("WMT", 913324551),

            new Stock("BYND", 950104120),
            new Stock("MGM", 913323750),
            new Stock("LAZR", 950118834),
            new Stock("AMD", 913254235),
            new Stock("TSLA", 913255598),

            new Stock("ATRO", 913255598),
            new Stock("CMG", 913255105),
            new Stock("DRI", 913255208),
            new Stock("HD", 913255369),
            new Stock("AMZN", 913256180),

            new Stock("GOOGL", 913257299),
            new Stock("AAPL", 913256135),
            new Stock("MAXR", 950052426),
            new Stock("SRAC", 950151334),
            new Stock("ANTM", 913324548),
        };

        /// <summary>Gets the real time quote async.</summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>A IRealTimeStockQuote.</returns>
        /// <remarks>
        /// If possible, please use the <seealso cref="GetRealTimeMarketQuoteAsync(long)"/> method to reduce unnecessary http requests.
        /// This method finds the symbol id with an http request before calling the <seealso cref="GetRealTimeMarketQuoteAsync(long)"/> method. 
        /// </remarks>
        public static async Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(string symbol)
        {
            var id = await _webull.FindStockIdAsync(symbol);
            if (id != null) return await GetRealTimeMarketQuoteAsync(id.Value);
            return null;
        }

        /// <summary>Gets the real time quote async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>A IRealTimeStockQuote.</returns>
        public static async Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(long tickerId)
        {
            //using var wbull = new WebullDataService();
            //return await wbull.GetRealTimeMarketQuoteAsync(tickerId);
            return await _webull.GetRealTimeMarketQuoteAsync(tickerId);
        }

        /// <summary>Gets the real time quotes task.</summary>
        /// <param name="tickerIds">The ticker ids.</param>
        /// <returns>A list of IRealTimeStockQuote.</returns>
        public static async Task<IEnumerable<IRealTimeStockQuote>> GetRealTimeMarketQuotesAsync(ICollection<long> tickerIds)
        {
            return await _webull.GetRealTimeMarketQuotesAsync(tickerIds);
        }

        /// <summary>Tos the symbol list.</summary>
        /// <param name="webullStocks">The webull stocks.</param>
        /// <returns>A list of string.</returns>
        public static ICollection<string> ToSymbolList(this IEnumerable<Stock> webullStocks)
        {
            return webullStocks?.Select(s => s?.Symbol).ToList();
        }

        /// <summary>Tos the ticker id list.</summary>
        /// <param name="webullStocks">The webull stocks.</param>
        /// <returns>A list of long.</returns>
        public static ICollection<long> ToTickerIdList(this IEnumerable<Stock> webullStocks)
        {
            return webullStocks?.Select(s => s.TickerId).ToList();
        }

        public static async Task<IEnumerable<IChartData>> GetStockChartDataAsync(long tickerId)
        {
            return await _webull.GetStockChartDataAsync(tickerId);
        }

        public static async Task<ICnbcRealTimeStockQuote> GetTest()
        {
           return  await _cnbc.GetRealTimeMarketQuoteAsync("spce");
        }
    }
}