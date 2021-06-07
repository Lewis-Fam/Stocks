using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LewisFam.Extensions;
using LewisFam.Stocks.Internal.Models;
using LewisFam.Stocks.ThirdParty.Webull;
using LewisFam.Stocks.ThirdParty.Webull.Models;
using Newtonsoft.Json.Linq;
using IStockQuote = LewisFam.Stocks.Models.IStockQuote;

namespace LewisFam.Stocks.Services
{
    public sealed class StocksDataSerivce : BaseDataService, IStocksDataService
    {
        //public async Task<IEnumerable<IStockQuoteFull>> GetRealTimeMarketQuotesFull(IEnumerable<Stock> stocks)
        //{
        //    using var ds = new WebullDataService();
        //    return await ds.GetRealTimeMarketQuotes(stocks.ToTickerIdList());
        //}

        //public async Task<IEnumerable<IStockQuote>> GetRealTimeMarketQuotes(IEnumerable<Stock> stocks)
        //{
        //    using var ds = new WebullDataService();
        //    return await ds.GetRealTimeMarketQuotes(stocks.ToTickerIdList());
        //}

        /// <summary>Gets the real time market quotes.</summary>
        /// <param name="tickerIds">The ticker ids.</param>
        /// <param name="batchSize">The batch size.</param>
        /// <returns>A list of IStockQuoteDataGrid.</returns>
        public async Task<IEnumerable<IStockQuote>> GetRealTimeMarketQuotes(IEnumerable<long> tickerIds, int batchSize = 50)
        {
            Debug.WriteLine($"{nameof(GetRealTimeMarketQuotes)}|{nameof(batchSize)}={batchSize}");
            var rtn = new List<IStockQuote>();
            var batches = tickerIds.Batch(batchSize);
            var batchIndex = 0;

            foreach (var b in batches)
            {
                Debug.WriteLine($"BatchIndex={batchIndex}");
                Uri = WebullDataService.Helper.BuildUriRealTimeStockQuotes(b.Select(i=>i));
                var data = await Client.GetAsync<List<WebullStockQuote>>(Uri);
                rtn.AddRange(data);
                batchIndex++;
            }

            return rtn;
        }


        public async Task<object> RawQuote(string symbol, string token = null)
        {
            if (string.IsNullOrEmpty(symbol)) throw new ArgumentNullException(nameof(symbol));

            //Uri = CnbcDataService.Helper.BuildUri(symbol);
            var data = await Client.GetAsync<JObject>(Uri);
            if (token != null)
                return data.SelectToken(token);
            return data;
        }

        public async Task<string> TestStringAsync()
        {
            //Uri = CnbcDataService.Helper.BuildUri("spce");
            var json = await Client.GetJsonAsync(Uri);
            
            return json;
        }

        public async Task<object> TestObjectAsync()
        {
            object rtn;
            //Uri = CnbcDataService.Helper.BuildUri("spce");
            rtn = await Client.GetAsync<object>(Uri);                       

            return rtn;
        }
    }
}