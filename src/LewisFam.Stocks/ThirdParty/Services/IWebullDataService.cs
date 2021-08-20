﻿using LewisFam.Interfaces;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.ThirdParty.Webull.Models;

using System.Collections.Generic;
using System.Threading.Tasks;
using LewisFam.Stocks.Options;

namespace LewisFam.Stocks.ThirdParty.Services
{
    public partial interface IWebullDataService : IDataService
    {
        //Task<ICollection<WebullOptionQuote>> GetRealTimeOptionQuotesAsync(long derivedId);

        //Task<ICollection<WebullOptionQuote>> GetRealTimeOptionQuotesAsync(ICollection<long> derivedId);

        //Task<object> GetOptionStratList(long tickerId);

        #region Properties

        ICollection<IWebullOptionQuote> AllOptions { get; }

        #endregion Properties

        #region Methods

        /// <summary>Finds a stock async.</summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>A Task.</returns>
        Task<Stock> FindStockAsync(string symbol);

        /// <summary>Finds the stock id async.</summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>A Task.</returns>
        Task<long?> FindStockIdAsync(string symbol);

        /// <summary>Gets the all options async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>A Task.</returns>
        Task<IEnumerable<IWebullOptionQuote>> GetAllOptionsAsync(long tickerId);

        /// <summary>Gets the all options async.</summary>
        /// <param name="stock">The stock.</param>
        /// <returns>A Task.</returns>
        Task<IEnumerable<IWebullOptionQuote>> GetAllOptionsAsync(Stock stock);

        /// <summary>Gets the expire on list async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>A Task.</returns>
        Task<IEnumerable<ExpireOn>> GetExpireOnListAsync(long tickerId);

        Task<IEnumerable<ExpireOn>> GetExpireOnListAsync(Stock stock);

        /// <summary>Gets the option async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>A Task.</returns>
        Task<IWebullOptionQuote> GetOptionAsync(long tickerId);

        /// <summary>Gets the option async.</summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>A Task.</returns>
        Task<IWebullOptionQuote> GetOptionAsync(string symbol);

        /// <summary>Gets the real time market quote async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>A Task.</returns>
        Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(long tickerId);

        /// <summary>Gets the real time market quote async.</summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>A Task.</returns>
        Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(string symbol);

        /// <summary>Gets the real time market quotes.</summary>
        /// <param name="tickerIds">The ticker ids.</param>
        /// <param name="batchSize">The batch size.</param>
        /// <returns>A list of IStockQuoteDataGrid.</returns>
        Task<IEnumerable<IRealTimeStockQuote>> GetRealTimeStockQuotesAsync(IEnumerable<long> tickerIds, int batchSize = 50);

        /// <summary>Gets the real time market quotes async.</summary>
        /// <param name="stocks">   The stocks.</param>
        /// <param name="batchSize">The batch size.</param>
        /// <returns>A Task.</returns>
        Task<IEnumerable<IRealTimeStockQuote>> GetRealTimeStockQuotesAsync(IEnumerable<Stock> stocks, int batchSize = 50);

        /// <summary>Gets the stock chart data async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <param name="type">    The type.</param>
        /// <param name="count">   The max count.</param>
        /// <returns>A list of IChartData.</returns>
        Task<IEnumerable<IChartData>> GetStockChartDataAsync(long tickerId, ChartDataType type = ChartDataType.d1, int count = 800);

        /// <summary>Gets the stock chart data async.</summary>
        /// <param name="stock"></param>
        /// <param name="type"> </param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<IEnumerable<IChartData>> GetStockChartDataAsync(Stock stock, ChartDataType type = ChartDataType.d1, int count = 800);

        /// <summary>Searches the symbol async.</summary>
        /// <param name="symbolSearch">The symbol search.</param>
        /// <returns>A list of stocks.</returns>
        Task<IEnumerable<Stock>> SearchSymbolAsync(string symbolSearch);

        #endregion Methods
    }
}