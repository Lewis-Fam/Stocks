using LewisFam.Stocks.Models;
using LewisFam.Stocks.ThirdParty.Cnbc;
using LewisFam.Stocks.ThirdParty.Cnbc.Models;
using LewisFam.Stocks.ThirdParty.Webull;
using LewisFam.Stocks.ThirdParty.Webull.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LewisFam.Stocks.Entity;
using LewisFam.Stocks.Options;
using LewisFam.Stocks.ThirdParty.Services;
using LewisFam.Utils;

namespace LewisFam.Stocks
{
    public static partial class StocksUtil
    {
        /// <summary>
        /// Writes the watchlist as json to file.
        /// </summary>
        /// <param name="watchlist">The watchlist.</param>
        /// <param name="path">The path.</param>
        /// <param name="format">If true, format.</param>
        public static void SaveToFile(this Watchlist watchlist, string path, bool format = false)
        {
            FileUtil.WriteAllText(path, watchlist.SerializeObjectToJson(format));
        }

        //public static string SaveToJsonFile(this IEnumerable<IWebullOptionQuote> optionQuotes, string path = "optionQuotes.json", bool format = false)
        //{
        //    var _path = Path.Combine($"{DateTime.Now:yyyy-MM-dd}_{path}");
        //    Debug.WriteLine(_path);
        //    FileUtil.WriteAllText(_path, optionQuotes.SerializeObjectToJson(format));
        //    //SaveToJsonFile(optionQuotes, _path, format);
        //    return path;
        //}

        public static void SaveToFile<T>(T t, string path = "_path.json", bool format = false, bool addDate = false)
        {
            path = addDate switch
            {
                false => Path.Combine(path),
                true => Path.Combine($"{DateTime.Now:yyyy-MM-dd}_{path}"),
            };
            Debug.WriteLine($"{nameof(path)}={path}");
            Debug.WriteLine($"Saved file to FilePath={Path.GetFullPath(path)}");
            FileUtil.WriteAllText(path, t.SerializeObjectToJson(format)); }

        /// <summary>
        /// ReadFileAsync
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task<T> ReadFileAsync<T>(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException(path);
            var file = await FileUtil.ReadAllTextAsync(path);
            return file.DeserializeObject<T>();
        }
    }

    /// <summary>Stocks</summary>
    public static partial class StocksUtil
    {
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
        #region Methods

        /// <summary>Finds the stock async.</summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>A <see cref="Stock"/>.</returns>
        public static async Task<Stock> FindStockAsync(string symbol)
        {
            Debug.WriteLine($"{nameof(FindStockAsync)} {nameof(symbol)}={symbol}");
            using var wb = new WebullDataService();
            return await wb.FindStockAsync(symbol);
        }

        public static async Task<IEnumerable<Stock>> SearchSymbolAsync(string searchSymbol)
        {
            Debug.WriteLine($"{nameof(SearchSymbolAsync)} {nameof(searchSymbol)}={searchSymbol}");
            using var wb = new WebullDataService();
            return await wb.SearchSymbolAsync(searchSymbol);
        }

        /// <summary>Gets the all stock options.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>An IEnumerable of <inheritdoc cref="IWebullOptionQuote"/>.</returns>
        public static async Task<IEnumerable<IWebullOptionQuote>> GetAllStockOptionsAsync(long tickerId)
        {
            try
            {
                using var wb = new WebullDataService();
                return await wb.GetAllOptionsAsync(tickerId);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return null;
        }

        /// <summary>Gets the all stock options.</summary>
        /// <param name="stock">The stock.</param>
        /// <returns>An IEnumerable of <inheritdoc cref="IWebullOptionQuote"/>.</returns>
        public static async Task<IEnumerable<IWebullOptionQuote>> GetAllStockOptionsAsync(this Stock stock)
        {
            try
            {
                using var wb = new WebullDataService();
                return await wb.GetAllOptionsAsync(stock.TickerId);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                Console.WriteLine(e);
            }

            return null;
        }

        /// <summary>Gets the cnbc stock quotes async.</summary>
        /// <param name="symbols">The symbols.</param>
        /// <returns>A Task.</returns>
        public static async Task<IEnumerable<ICnbcRealTimeStockQuote>> GetCnbcStockQuotesAsync(ICollection<string> symbols)
        {
            using var cnbc = new CnbcDataService();
            return await cnbc.GetRealTimeMarketQuotesAsync(symbols);
        }

        /// <summary>Extension Method. Gets random elements of T.</summary>
        /// <param name="items">        The items.</param>
        /// <param name="elementsCount">The elements count.</param>
        /// <returns>A random list of T.</returns>
        public static IEnumerable<T> GetRandomElements<T>(this IEnumerable<T> items, int elementsCount = int.MaxValue)
        {
            return items.OrderBy(x => Guid.NewGuid()).Take(elementsCount).ToList();
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
            var id = await wb.FindStockIdAsync(symbol);
            if (id != null) return await GetRealTimeMarketQuoteAsync(id.Value);
            return null;
        }

        public static Task<IEnumerable<ExpireOn>> GetExpireOnListAsync(this Stock stock)
        {
            using var wb = new WebullDataService();
            return wb.GetExpireOnListAsync(stock);
        }

        public static void Get(this Stock stock)
        {
            //stock.GetFinancialsSimpleAsync()
        }
            

        /// <summary>Gets the real time quote async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>A IRealTimeStockQuote.</returns>
        public static async Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(long tickerId)
        {
            using var wb = new WebullDataService();
            return await wb.GetRealTimeMarketQuoteAsync(tickerId);
        }

        /// <summary>Gets the real time quotes task.</summary>
        /// <param name="tickerIds">The ticker ids.</param>
        /// <param name="batchSize">The batch size.</param>
        /// <returns>A list of IRealTimeStockQuote.</returns>
        public static async Task<IEnumerable<IRealTimeStockQuote>> GetRealTimeMarketQuotesAsync(ICollection<long> tickerIds, int batchSize = 50)
        {
            using var wb = new WebullDataService();
            return await wb.GetRealTimeStockQuotesAsync(tickerIds, batchSize);
        }

        public static async Task<IEnumerable<IRealTimeStockQuote>> GetRealTimeMarketQuotesAsync(this IEnumerable<Stock> stocks, int batchSize = 50)
        {
            using var wb = new WebullDataService();
            return await wb.GetRealTimeStockQuotesAsync(stocks.ToTickerIdList(), batchSize);
        }

        public static async Task<IEnumerable<IWebullOptionQuote>> GetRealTimeOptionQuotesAsync(IEnumerable<long> derivedIds)
        {
            //using var wb = new WebullDataService();
            return await new WebullDataService().GetRealTimeOptionQuotesAsync(derivedIds);
        }

        public static async Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(this Stock stock)
        {
            return await GetRealTimeMarketQuoteAsync(stock.TickerId);
        }

        public static async Task<IEnumerable<IChartData>> GetChartDataAsync(this Stock stock, ChartDataType type = ChartDataType.d1, int count = 800)
        {
            return await GetChartDataAsync(stock.TickerId, type, count);
        }

        /// <summary>Gets the stock chart data async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <param name="type">    The type.</param>
        /// <param name="count">   The count.</param>
        /// <returns>A list of <see cref="IChartData"/>.</returns>
        public static async Task<IEnumerable<IChartData>> GetChartDataAsync(long tickerId, ChartDataType type = ChartDataType.d1, int count = 800)
        {
            try
            {
                using var wb = new WebullDataService();
                return await wb.GetStockChartDataAsync(tickerId, type, count);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Debug.WriteLine(e);
            }

            return null;
        }

        /// <summary>Extension method. IWebullOptionQuote to derivedTickerId list.</summary>
        /// <param name="optionQuotes"></param>
        /// <returns></returns>
        public static ICollection<long> ToDerivedTickerIdList(this IEnumerable<IWebullOptionQuote> optionQuotes)
        {
            return optionQuotes.Select(s => s.TickerId).ToList();
        }

        /// <summary>Extension method. Stocks to symbol list.</summary>
        /// <param name="webullStocks">The webull stocks.</param>
        /// <returns>A list of symbols.</returns>
        public static IReadOnlyCollection<string> ToSymbolList(this IEnumerable<Stock> webullStocks)
        {
            return webullStocks?.Select(s => s?.Symbol).ToList();
        }

        /// <summary>Extension method. Stocks to tickerId list.</summary>
        /// <param name="webullStocks">The webull stocks.</param>
        /// <returns>A list of tickerIds.</returns>
        public static IReadOnlyCollection<long> ToTickerIdList(this IEnumerable<Stock> webullStocks)
        {
            return webullStocks.Select(s => s.TickerId).ToList();
        }

        #endregion Methods

        public static async Task<object> GetFinancialsSimpleAsync(this Stock stock)
        {
            using var wb = new WebullDataService();
            return await wb.GetFinancialsSimpleAsync(stock.TickerId);
        }

        public static Task<object> GetOptionChartDataAsync(long derivedId)
        {
            using var wb = new WebullDataService();
            return wb.GetOptionChartDataAsync(derivedId);
        }

        public static async Task<object> GetOptionQuoteChartDataAsync(this IWebullOptionQuote optionQuote)
        {
            using var wb = new WebullDataService();
            return await wb.GetOptionChartDataAsync(optionQuote.TickerId);
        }

        public static async Task<IEnumerable<WebullOptionQuote>> GetRealTimeOptionQuoteAsync(this IWebullOptionQuote optionQuote)
        {
            using var wb = new WebullDataService();
            return await wb.GetRealTimeOptionQuoteAsync(optionQuote);
        }

        public static async Task<IEnumerable<WebullOptionQuote>> GetRealTimeOptionQuoteAsync(long derivedId)
        {
            using var wb = new WebullDataService();
            return await wb.GetRealTimeOptionQuoteAsync(derivedId);
        }

        public static async Task<IEnumerable<IWebullOptionQuote>> GetRealTimeOptionQuotesAsync(this IEnumerable<IWebullOptionQuote> optionQuotes)
        {
            using var wb = new WebullDataService();
            return await wb.GetRealTimeOptionQuotesAsync(optionQuotes.ToDerivedTickerIdList());
        }

        public static async Task<object> GetOptionStratListAsync(long tickerId)
        {
            using var wb = new WebullDataService();
            return await wb.GetOptionStratAsync(tickerId);
        }

        public static async Task<object> GetOptionStratListAsync(this Stock stock)
        {
            using var wb = new WebullDataService();
            return await wb.GetOptionStratAsync(stock);
        }
    }
}