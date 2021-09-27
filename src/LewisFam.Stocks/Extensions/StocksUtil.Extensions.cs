﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Options.Models;
using LewisFam.Stocks.ThirdParty.Services;
using LewisFam.Stocks.ThirdParty.Webull;
using LewisFam.Stocks.ThirdParty.Webull.Models;

namespace LewisFam.Stocks
{
    /// <summary>A Stocks and Options Utility</summary>
    public static partial class StocksExtensions
    {
        /// <summary>Gets the all stock options.</summary>
        /// <param name="stock">The stock.</param>
        /// <returns>An IEnumerable of <see cref="IWebullOptionQuote"/>.</returns>
        public static async Task<IEnumerable<IWebullOptionQuote>> GetAllOptionsAsync(this Stock stock)
        {
            try
            {
                using IWebullDataService wb = new WebullDataService();
                if (stock.HasTickerId)
                    return await wb.GetAllOptionsAsync(stock.TickerId);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                Console.WriteLine(e);
                return null;
            }

            return null;
        }  
        
        /// <summary>
        /// Gets the expire on list async.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>A Task.</returns>
        public static Task<IEnumerable<ExpireOn>> GetExpireOnListAsync(this Stock stock)
        {
            using IWebullDataService wb = new WebullDataService();
            return wb.GetExpireOnListAsync(stock);
        }

        /// <summary>
        /// Gets the financials simple async.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>A Task.</returns>
        public static async Task<object> GetFinancialsSimpleAsync(this Stock stock)
        {
            using IWebullDataService wb = new WebullDataService();
            return stock.HasTickerId ? await wb.GetFinancialsSimpleAsync(stock.TickerId) : null;
        }

        /// <summary>
        /// Gets the last close price.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>A double.</returns>
        public static async Task<double> GetLastClosePrice(this IStock stock)
        {
            using IWebullDataService wb = new WebullDataService();
            stock.Price = (await wb.GetRealTimeMarketQuoteAsync(stock.TickerId)).Close;
            return stock.Price.Value;
        }

        /// <summary>
        /// Gets the option chart data async.
        /// </summary>
        /// <param name="optionQuote">The option quote.</param>
        /// <returns>A Task.</returns>
        public static async Task<object> GetOptionChartDataAsync(this IOption optionQuote)
        {
            using IWebullDataService wb = new WebullDataService();
            return await wb.GetOptionChartDataAsync(optionQuote.TickerId);
        }

        /// <summary>
        /// Gets the option strat list async.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>A Task.</returns>
        public static async Task<object> GetOptionStratListAsync(this Stock stock)
        {
            using IWebullDataService wb = new WebullDataService();
            return await wb.GetOptionStratAsync(stock.TickerId);
        }

        /// <summary>Extension Method. Gets random elements of T.</summary>
        /// <param name="items">        The items.</param>
        /// <param name="elementsCount">The elements count.</param>
        /// <returns>A random list of T.</returns>
        public static IEnumerable<T> GetRandomElements<T>(this IEnumerable<T> items, int elementsCount = int.MaxValue)
        {
            return items.OrderBy(x => Guid.NewGuid()).Take(elementsCount);
        }

        /// <summary>
        /// Gets the real time market quote async.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>A Task.</returns>
        public static async Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(this Stock stock)
        {
            if (!stock.HasTickerId) return null;

            using IWebullDataService wb = new WebullDataService();
            return await wb.GetRealTimeMarketQuoteAsync(stock.TickerId);
            //return stock.HasTickerId ? await GetRealTimeMarketQuoteAsync(stock.TickerId) : null;
        }

        /// <summary>
        /// Gets the real time market quotes async.
        /// </summary>
        /// <param name="stocks">The stocks.</param>
        /// <param name="batchSize">The batch size.</param>
        /// <returns>A Task.</returns>
        public static async Task<IEnumerable<IRealTimeStockQuote>> GetRealTimeMarketQuotesAsync(this IEnumerable<Stock> stocks, int batchSize = 50)
        {
            using IWebullDataService wb = new WebullDataService();
            return await wb.GetRealTimeStockQuotesAsync(stocks.ToTickerIdList(), batchSize);
        }

        /// <summary>
        /// Gets the real time option quote async.
        /// </summary>
        /// <param name="optionQuote">The option quote.</param>
        /// <returns>A Task.</returns>
        public static async Task<IEnumerable<WebullOptionQuote>> GetRealTimeOptionQuoteAsync(this IOption optionQuote)
        {
            using IWebullDataService wb = new WebullDataService();
            return await wb.GetRealTimeOptionQuoteAsync((IWebullOptionQuote)optionQuote);
        }

        /// <summary>
        /// Gets the real time option quotes async.
        /// </summary>
        /// <param name="optionQuotes">The option quotes.</param>
        /// <returns>A Task.</returns>
        public static async Task<IEnumerable<IWebullOptionQuote>> GetRealTimeOptionQuotesAsync(this IEnumerable<IOption> optionQuotes)
        {
            using IWebullDataService wb = new WebullDataService();
            return await wb.GetRealTimeOptionQuotesAsync(optionQuotes.ToDerivedTickerIdList());
        }

        /// <summary>
        /// Gets the stock chart data async.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <param name="type">The type.</param>
        /// <param name="count">The count.</param>
        /// <returns>A Task.</returns>
        public static async Task<IEnumerable<IChartData>> GetStockChartDataAsync(this Stock stock, ChartDataType type = ChartDataType.d1, int count = 800)
        {
            if (stock.HasTickerId)
            {
                using IWebullDataService wb = new WebullDataService();
                return await wb.GetStockChartDataAsync(stock.TickerId, type, count);
            }

            return null;
        }

        /// <summary>Extension method. IWebullOptionQuote to derivedTickerId list.</summary>
        /// <param name="optionQuotes"></param>
        /// <returns></returns>
        public static IEnumerable<long> ToDerivedTickerIdList(this IEnumerable<IOption> optionQuotes)
        {
            return optionQuotes.Select(s => s.TickerId);
        }

        /// <summary>Extension method. Stocks to symbol list.</summary>
        /// <param name="webullStocks">The webull stocks.</param>
        /// <returns>A list of symbols.</returns>
        public static IEnumerable<string> ToSymbolList(this IEnumerable<Stock> webullStocks)
        {
            return webullStocks?.Select(s => s?.Symbol);
        }

        /// <summary>Extension method. Stocks to tickerId list.</summary>
        /// <param name="webullStocks">The webull stocks.</param>
        /// <returns>A list of tickerIds.</returns>
        public static IEnumerable<long> ToTickerIdList(this IEnumerable<Stock> webullStocks)
        {
            return webullStocks?.Select(s => s.TickerId);
        }
    }
}