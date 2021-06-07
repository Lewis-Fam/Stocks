using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LewisFam.Stocks.ThirdParty.Cnbc.Models;
using LewisFam.Well_Known.Enums;


namespace LewisFam.Stocks.ThirdParty.Services
{
    
    public interface ICnbcDataService : IDisposable
    {
        /// <summary>Get a realtime CNBC market quote async.</summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns><see cref="IStockQuote"/></returns>
        Task<Cnbc.Models.IStockQuote> GetRealTimeMarketQuoteAsync(string symbol);

        /// <summary>Gets realtime CNBC market quotes async.</summary>
        /// <param name="symbols">  The symbols.</param>
        /// <param name="batchSize">The batch size.</param>
        /// <returns><see cref="IStockQuote"/></returns>
        Task<IEnumerable<Cnbc.Models.IStockQuote>> GetRealTimeMarketQuotesAsync(ICollection<string> symbols, int batchSize = 20);                                                              

        /// <summary>Gets Price bars.</summary>
        /// <param name="symbol">       The symbol.</param>
        /// <param name="durationGroup">The duration group.</param>
        /// <param name="start">        The start.</param>
        /// <param name="end">          The end.</param>
        /// <returns><see cref="PriceBar"/></returns>
        [Obsolete("Fix this method.")]
        Task<IEnumerable<PriceBar>> GetPriceBarsAsync(string symbol, TimeUnit durationGroup, string start, string end);

        Task<IEnumerable<PriceBar>> GetPriceBarsAsync(string symbol);
    }
}