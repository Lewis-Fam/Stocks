using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        #region Properties

        /// <summary>Gets a sample stock list.</summary>
        public static IReadOnlyList<Stock> StockList2021 => new List<Stock>
        {
            new Stock(symbol: "SPCE", tickerId: 950052430),
            new Stock(symbol: "ROKU", tickerId: 925376726),
            new Stock(symbol: "MSFT", tickerId: 913323997),
            new Stock(symbol: "NVDA", tickerId: 913257561),
            new Stock(symbol: "BA", tickerId: 913254998),

            new Stock(symbol: "U", tickerId: 950172451),
            new Stock(symbol: "RBLX", tickerId: 950178170),
            new Stock(symbol: "AEVA", tickerId: 950157726),
            new Stock(symbol: "CCIV", tickerId: 950173643),
            new Stock(symbol: "FIVE", tickerId: 913255714),

            new Stock(symbol: "RIOT", tickerId: 925163605),
            new Stock(symbol: "SNOW", tickerId: 950173560),
            new Stock(symbol: "CRSP", tickerId: 913433908),
            new Stock(symbol: "DIS", tickerId: 913255192),
            new Stock(symbol: "WMT", tickerId: 913324551),

            new Stock(symbol: "BYND", tickerId: 950104120),
            new Stock(symbol: "MGM", tickerId: 913323750),
            new Stock(symbol: "LAZR", tickerId: 950118834),
            new Stock(symbol: "AMD", tickerId: 913254235),
            new Stock(symbol: "TSLA", tickerId: 913255598),

            new Stock(symbol: "ATRO", tickerId: 913255598),
            new Stock(symbol: "CMG", tickerId: 913255105),
            new Stock(symbol: "DRI", tickerId: 913255208),
            new Stock(symbol: "HD", tickerId: 913255369),
            new Stock(symbol: "AMZN", tickerId: 913256180),

            new Stock(symbol: "GOOGL", tickerId: 913257299),
            new Stock(symbol: "AAPL", tickerId: 913256135),
            new Stock(symbol: "MAXR", tickerId: 950052426),
            new Stock(symbol: "SRAC", tickerId: 950151334),
            new Stock(symbol: "ANTM", tickerId: 913324548),
        };

        #endregion Properties

        #region Methods

        /// <summary>Finds the stock async.</summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>A <see cref="Stock"/>.</returns>
        public static async Task<Stock> FindStockAsync(string symbol)
        {
            using var wb = new WebullDataService();
            return await wb.FindStockAsync(symbol: symbol);
        }

        /// <summary>Gets the all stock options.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>An IEnumerable of <inheritdoc cref="IWebullOptionQuote"/>.</returns>
        public static async Task<IEnumerable<IWebullOptionQuote>> GetAllStockOptionsAsync(long tickerId)
        {
            try
            {
                using var wb = new WebullDataService();
                return await wb.GetAllOptionsAsync(tickerId: tickerId);
            }
            catch (Exception e)
            {
                Console.WriteLine(value: e);
            }

            return null;
        }

        /// <summary>Gets the all stock options.</summary>
        /// <param name="stock">The stock.</param>
        /// <returns>An IEnumerable of <inheritdoc cref="IWebullOptionQuote"/>.</returns>
        public static async Task<IEnumerable<IWebullOptionQuote>> GetAllStockOptionsAsync(Stock stock)
        {
            try
            {
                using var wb = new WebullDataService();
                return await wb.GetAllOptionsAsync(tickerId: stock.TickerId);
            }
            catch (Exception e)
            {
                Console.WriteLine(value: e);
            }

            return null;
        }

        /// <summary>Gets the cnbc stock quotes async.</summary>
        /// <param name="symbols">The symbols.</param>
        /// <returns>A Task.</returns>
        public static async Task<IEnumerable<ICnbcRealTimeStockQuote>> GetCnbcStockQuotesAsync(ICollection<string> symbols)
        {
            using var nbc = new CnbcDataService();
            return await nbc.GetRealTimeMarketQuotesAsync(symbols: symbols);
        }

        /// <summary>Extension Method. Gets random elements of T.</summary>
        /// <param name="items">        The items.</param>
        /// <param name="elementsCount">The elements count.</param>
        /// <returns>A random list of T.</returns>
        public static IEnumerable<T> GetRandomElements<T>(this IEnumerable<T> items, int elementsCount = int.MaxValue)
        {
            return items.OrderBy(keySelector: x => Guid.NewGuid()).Take(count: elementsCount).ToList();
        }

        /// <summary>Gets the real time quote async.</summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>A IRealTimeStockQuote.</returns>
        /// <remarks>
        /// If possible, please use the <seealso cref="GetRealTimeMarketQuoteAsync(long)"/> method to reduce unnecessary http requests. This method finds the symbol id with an
        /// http request before calling the <seealso cref="GetRealTimeMarketQuoteAsync(long)"/> method.
        /// </remarks>
        public static async Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(string symbol)
        {
            using var wb = new WebullDataService();
            var id = await wb.FindStockIdAsync(symbol: symbol);
            if (id != null) return await GetRealTimeMarketQuoteAsync(tickerId: id.Value);
            return null;
        }

        /// <summary>Gets the real time quote async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>A IRealTimeStockQuote.</returns>
        public static async Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(long tickerId)
        {
            using var wb = new WebullDataService();
            return await wb.GetRealTimeMarketQuoteAsync(tickerId: tickerId);
        }

        /// <summary>Gets the real time quotes task.</summary>
        /// <param name="tickerIds">The ticker ids.</param>
        /// <returns>A list of IRealTimeStockQuote.</returns>
        public static async Task<IEnumerable<IRealTimeStockQuote>> GetRealTimeMarketQuotesAsync(ICollection<long> tickerIds)
        {
            using var wb = new WebullDataService();
            return await wb.GetRealTimeMarketQuotesAsync(tickerIds: tickerIds);
        }

        /// <summary>Gets the stock chart data async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <param name="type">    The type.</param>
        /// <param name="count">   The count.</param>
        /// <returns>A list of <see cref="IChartData"/>.</returns>
        public static async Task<IEnumerable<IChartData>> GetStockChartDataAsync(long tickerId, ChartDataType type = ChartDataType.d1, int count = 800)
        {
            try
            {
                using var wb = new WebullDataService();
                return await wb.GetStockChartDataAsync(tickerId: tickerId, type: type, count: count);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Debug.WriteLine(value: e);
            }

            return null;
        }

        /// <summary>Extension method. Stocks to symbol list.</summary>
        /// <param name="webullStocks">The webull stocks.</param>
        /// <returns>A list of symbols.</returns>
        public static ICollection<string> ToSymbolList(this IEnumerable<Stock> webullStocks)
        {
            return webullStocks?.Select(selector: s => s?.Symbol).ToList();
        }

        /// <summary>Extension method. Stocks to tickerId list.</summary>
        /// <param name="webullStocks">The webull stocks.</param>
        /// <returns>A list of tickerIds.</returns>
        public static ICollection<long> ToTickerIdList(this IEnumerable<Stock> webullStocks)
        {
            return webullStocks.Select(selector: s => s.TickerId).ToList();
        }

        #endregion Methods

        //static async Task<ICnbcRealTimeStockQuote> GetTest()
        //{
        //   return  await _cnbc.GetRealTimeMarketQuoteAsync("spce");
        //}
    }
}