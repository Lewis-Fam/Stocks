using System.Collections.Generic;
using System.Threading.Tasks;
using LewisFam.Interfaces;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.ThirdParty.Webull.Models;


namespace LewisFam.Stocks.ThirdParty.Services
{
    public interface IWebullDataService : IDataService
    {
        Task<object> GetOptionStratList(long tickerId);

        ICollection<IWebullOptionQuote> AllOptions { get; }

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

        /// <summary>Gets the real time market quotes.</summary>
        /// <param name="tickerIds">The ticker ids.</param>
        /// <param name="batchSize">The batch size.</param>
        /// <returns>A list of IStockQuoteDataGrid.</returns>
        Task<IList<IRealTimeStockQuote>> GetRealTimeMarketQuotesAsync(ICollection<long> tickerIds, int batchSize = 50);

        /// <summary>
        /// Gets the stock chart data async.
        /// </summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <param name="type">The type.</param>
        /// <param name="count">The max count.</param>
        /// <returns>A list of IChartData.</returns>
        Task<IEnumerable<IChartData>> GetStockChartDataAsync(long tickerId, ChartDataType type = ChartDataType.d1, int count = 800);

        /// <summary>Searches the symbol async.</summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>A list of stocks.</returns>
        Task<IEnumerable<Stock>> SearchSymbolAsync(string symbol);

        /// <summary>Gets the expire on list async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>A Task.</returns>
        Task<IEnumerable<ExpireOn>> GetExpireOnListAsync(long tickerId);
    }
}