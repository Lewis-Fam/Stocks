using LewisFam.Stocks.Models;
using LewisFam.Stocks.ThirdParty.Cnbc;
using LewisFam.Stocks.ThirdParty.Cnbc.Models;
using LewisFam.Stocks.ThirdParty.Services;
using LewisFam.Stocks.ThirdParty.Webull;
using LewisFam.Stocks.ThirdParty.Webull.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LewisFam.Stocks
{
    public static partial class StocksUtil
    {
        /// <summary>Gets a sample stocks list.</summary>
        public static IReadOnlyList<Stock> StockList2021 => new List<Stock>
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

        /// <summary>Finds the stock async.</summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>A <see cref="Stock"/>.</returns>
        public static async Task<Stock> FindStockAsync(string symbol)
        {
            Debug.WriteLine($"{nameof(FindStockAsync)} {nameof(symbol)}={symbol}");
            using IWebullDataService wb = new WebullDataService();
            return await wb.FindStockAsync(symbol);
        }

        /// <summary>Gets the all stock options.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>An IEnumerable of <see cref="IRealTimeOptionQuote"/>.</returns>
        /// <exception cref="ApplicationException">Ignore.</exception>
        public static async Task<IEnumerable<IRealTimeOptionQuote>> GetAllOptionsAsync(long tickerId)
        {
            try
            {
                using IWebullDataService wb = new WebullDataService();
                return await wb.GetAllOptionsAsync(tickerId);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw new ApplicationException($"{nameof(GetAllOptionsAsync)} {tickerId}", e);
            }
        }

        /// <summary>Gets the cnbc stock quotes async.</summary>
        /// <param name="symbols">The symbols.</param>
        /// <returns>A Task.</returns>
        public static async Task<IEnumerable<ICnbcRealTimeStockQuote>> GetCnbcStockQuotesAsync(ICollection<string> symbols)
        {
            using var cnbc = new CnbcDataService();
            return await cnbc.GetRealTimeMarketQuotesAsync(symbols);
        }

        /// <summary>Gets the option chart data async.</summary>
        /// <param name="derivedId">The derived id.</param>
        /// <returns>A Task.</returns>
        public static Task<string> GetOptionChartDataAsync(long derivedId)
        {
            using IWebullDataService wb = new WebullDataService();
            return wb.GetOptionChartDataAsync(derivedId);
        }

        /// <summary>Gets the option quote details.</summary>
        /// <param name="derivedIds">The derived ids.</param>
        /// <param name="tickerId">  The ticker id.</param>
        /// <returns>A Task.</returns>
        public static async Task<string> GetOptionQuoteDetails(IEnumerable<long> derivedIds, long tickerId)
        {
            using IWebullDataService wb = new WebullDataService();
            return await wb.GetRealTimeOptionQuoteDetailsAsync(derivedIds, tickerId);
        }

        /// <summary>Gets the option strat async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>A Task.</returns>
        public static async Task<object> GetOptionStratAsync(long tickerId)
        {
            using IWebullDataService wb = new WebullDataService();
            return await wb.GetOptionStrategyAsync(tickerId);
        }

        /// <summary>Gets the real time quote async.</summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>A IRealTimeStockQuote.</returns>
        /// <remarks>
        /// If possible, please use the <seealso cref="GetRealTimeMarketQuoteAsync(long)"/> method to reduce unnecessary http requests. This method finds the symbol id with an
        /// http request before calling the <seealso cref="GetRealTimeMarketQuoteAsync(long)"/> method.
        /// </remarks>
        [Obsolete("If possible, please use the GetRealTimeMarketQuoteAsync(long) method to reduce unnecessary http requests")]
        public static async Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(string symbol)
        {
            using IWebullDataService wb = new WebullDataService();
            var id = await wb.FindStockIdAsync(symbol);
            if (id != null) return await wb.GetRealTimeMarketQuoteAsync(id.Value);
            return null;
        }

        /// <summary>Gets the real time quote async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>A IRealTimeStockQuote.</returns>
        public static async Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(long tickerId)
        {
            using IWebullDataService wb = new WebullDataService();
            return await wb.GetRealTimeMarketQuoteAsync(tickerId);
        }

        /// <summary>Gets the real time quotes task.</summary>
        /// <param name="tickerIds">The ticker ids.</param>
        /// <param name="batchSize">The batch size.</param>
        /// <returns>A list of IRealTimeStockQuote.</returns>
        public static async Task<IEnumerable<IRealTimeStockQuote>> GetRealTimeMarketQuotesAsync(IEnumerable<long> tickerIds, int batchSize = 50)
        {
            using IWebullDataService wb = new WebullDataService();
            return await wb.GetRealTimeStockQuotesAsync(tickerIds, batchSize);
        }

        /// <summary>Gets the real time option quote async.</summary>
        /// <param name="derivedId">The derived id.</param>
        /// <returns>A Task.</returns>
        public static async Task<IEnumerable<WebullOptionQuote>> GetRealTimeOptionQuoteAsync(long derivedId)
        {
            using IWebullDataService wb = new WebullDataService();
            return await wb.GetRealTimeOptionQuoteAsync(derivedId);
        }

        /// <summary>Gets the real time option quotes async.</summary>
        /// <param name="derivedIds">The derived ids.</param>
        /// <returns>A Task.</returns>
        public static async Task<IEnumerable<IWebullOptionQuote>> GetRealTimeOptionQuotesAsync(IEnumerable<long> derivedIds)
        {
            using IWebullDataService wb = new WebullDataService();
            return await wb.GetRealTimeOptionQuotesAsync(derivedIds);
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
                using IWebullDataService wb = new WebullDataService();
                return await wb.GetStockChartDataAsync(tickerId, type, count);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Debug.WriteLine(e);
            }

            return null;
        }

        /// <summary>Searches the symbol async.</summary>
        /// <param name="searchSymbol">The search symbol.</param>
        /// <returns>A Task.</returns>
        public static async Task<IEnumerable<Stock>> SearchSymbolAsync(string searchSymbol)
        {
            Debug.WriteLine($"{nameof(SearchSymbolAsync)} {nameof(searchSymbol)}={searchSymbol}");
            using IWebullDataService wb = new WebullDataService();
            return await wb.SearchSymbolAsync(searchSymbol);
        }
    }
}