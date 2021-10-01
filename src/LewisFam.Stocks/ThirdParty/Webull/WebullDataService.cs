using LewisFam.Extensions;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.ThirdParty.Services;
using LewisFam.Stocks.ThirdParty.Webull.Models;
using LewisFam.Utils;

using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LewisFam.Stocks.Internal;
using LewisFam.Stocks.Options.Models;

//https://quotes-gw.webullfintech.com/api/quotes/ticker/batchTickerRealTime?includeQuote=1&includeSecu=1&more=1&tickerIds=913243104%2C913243133%2C913243139%2C913243191%2C913243249%2C913243251%2C913243546%2C913243555%2C913244089%2C913244454%2C913244515%2C913244578%2C913244652%2C913244796%2C913246743%2C913247002%2C913247103%2C913247207%2C913247368%2C913247588%2C913286798%2C913419147%2C913419148%2C913419149%2C913419150%2C913419151%2C913424717%2C913732468%2C925179279%2C925412021%2C950097340%2C950116648%2C950121347%2C950176466
namespace LewisFam.Stocks.ThirdParty.Webull
{
    public class MarketAlertArgs : EventArgs
    {
        public MarketAlertArgs(Stock stock, IWebullOptionQuote quote)
        {
            Stock = stock;
            OptionQuote = quote;
            AlertCreatedOn = DateTime.Now;
            var last = stock.GetLastClosePrice();
        }

        public IWebullOptionQuote OptionQuote { get; }
        public IStock Stock { get;  }
        public DateTime AlertCreatedOn { get; }
    }

    /// <summary>The webull data service.</summary>
    public sealed partial class WebullDataService : BaseDataService, IWebullDataService
    {
        public ICollection<IWebullOptionQuote> AllOptions { get; private set; } = new List<IWebullOptionQuote>();

        public ICollection<Stock> StockCollection { get; private set; } = new List<Stock>();

        public event EventHandler<MarketAlertArgs> OnMarketAlert;

        public event EventHandler<object> OnDataReceived;

        ///<inheritdoc/>
        public async Task<Stock> FindStockAsync(string symbol)
        {
            try
            {
                Debug.WriteLine($"{nameof(FindStockAsync)} : {nameof(symbol)}={symbol}");
                Uri = Helper.BuildUriSearchSymbol(symbol);
                var jsonString = await Client.GetJsonAsync(Uri, "stockAndEtfs");
                OnDataReceived?.Invoke(this, jsonString);
                var result = JToken.Parse(jsonString).ToObject<IEnumerable<Stock>>();
                var stock = result?.FirstOrDefault();
                StockCollection.Add(stock);
                return string.Equals(stock?.Symbol, symbol, StringComparison.CurrentCultureIgnoreCase) ? stock : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        ///<inheritdoc/>
        public async Task<long?> FindStockIdAsync(string symbol)
        {
            Debug.WriteLine($"{nameof(FindStockIdAsync)} : {nameof(symbol)}={symbol}");
            var result = await FindStockAsync(symbol);
            return result?.TickerId;
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<IRealTimeOptionQuote>> GetAllOptionsAsync(long tickerId)
        {
            Debug.WriteLine($"{nameof(GetAllOptionsAsync)} : {nameof(tickerId)}={tickerId}");
            AllOptions?.Clear();

            //var rtn = new List<Option>();

            foreach (var expireOn in await GetExpireOnListAsync(tickerId))
            {
                var data = await GetOptionAsync(tickerId, expireOn.Date);

                if (data.Data != null)
                    foreach (var option in data.Data)
                    {
                        option.SpotPrice = data.Close;
                        AllOptions.Add(option.Put);
                        AllOptions.Add(option.Call);
                    }
            } 
            
            OnDataReceived?.Invoke(this, AllOptions);
            return AllOptions;
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<IRealTimeOptionQuote>> GetAllOptionsAsync(Stock stock)
        {
            return await GetAllOptionsAsync(stock.TickerId);
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<ExpireOn>> GetExpireOnListAsync(long tickerId)
        {
            var data = await Client.GetJsonAsync(Helper.BuildUriGetOptions(tickerId));
            OnDataReceived?.Invoke(this, data);
            var option = data.DeserializeObject<WebullOptionQuote>()?.ExpireDateList;
            return option;
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<ExpireOn>> GetExpireOnListAsync(Stock stock)
        {
            return await GetExpireOnListAsync(stock.TickerId);
        }

        ///<inheritdoc/>
        [Obsolete]
        public async Task<IWebullOptionQuote> GetOptionAsync(long tickerId) => (await Client.GetJsonAsync(Helper.BuildUriGetOptions(tickerId)))?.DeserializeObject<WebullOptionQuote>();

        ///<inheritdoc/>
        [Obsolete]
        public async Task<IWebullOptionQuote> GetOptionAsync(string symbol)
        {
            var id = await FindStockIdAsync(symbol);
            return !id.HasValue ? null : (await Client.GetJsonAsync(Helper.BuildUriGetOptions(id.Value)))?.DeserializeObject<WebullOptionQuote>();
        }

        ///<inheritdoc/>
        public async Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(long tickerId)
        {
            var ids = new List<long>
            {
                tickerId
            };
            Uri = Helper.BuildUriRealTimeStockQuotes(ids);
            Debug.WriteLine($"{nameof(GetRealTimeMarketQuoteAsync)} : {nameof(tickerId)}={tickerId} : {nameof(Uri)}={Uri}");
            var data = await Client.GetJsonAsync<List<WebullStockQuote>>(Uri);
            OnDataReceived?.Invoke(this, data);
            return data?.FirstOrDefault();
        }

        public async Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(string symbol)
        {
            var stock = await FindStockIdAsync(symbol);
            if (stock.HasValue)
                return await GetRealTimeMarketQuoteAsync(stock.Value);

            return null;
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<IRealTimeStockQuote>> GetRealTimeStockQuotesAsync(IEnumerable<long> tickerIds, int batchSize = 50)
        {
            //Debug.WriteLine($"{nameof(GetRealTimeMarketQuotesAsync)} : {nameof(batchSize)}={batchSize} : {nameof(tickerIds)}Count={tickerIds.Count}");
            var rtn = new List<IRealTimeStockQuote>();
            var batches = tickerIds.Batch(batchSize);
            var batchIndex = 0;

            foreach (var b in batches)
            {
                Uri = Helper.BuildUriRealTimeStockQuotes(b.Select(i => i));
                Debug.WriteLine($"{nameof(GetRealTimeStockQuotesAsync)} : {nameof(batchIndex)}={batchIndex} : {nameof(Uri)}={Uri}");
                var data = await Client.GetJsonAsync<List<WebullStockQuote>>(Uri);
                
                rtn.AddRange(data);
                batchIndex++;
            }

            OnDataReceived?.Invoke(this, rtn);
            return rtn;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<IRealTimeStockQuote>> GetRealTimeStockQuotesAsync(IEnumerable<Stock> stocks, int batchSize = 50)
        {
            return await GetRealTimeStockQuotesAsync(stocks.ToTickerIdList(), batchSize);
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<IChartData>> GetStockChartDataAsync(Stock stock, ChartDataType type = ChartDataType.d1, int count = 800)
        {
            return await GetStockChartDataAsync(stock.TickerId, type, count);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<IChartData>> GetStockChartDataAsync(long tickerId, ChartDataType type = ChartDataType.d1, int count = 800)
        {
            var rtn = new List<ChartData>();
            Uri = Helper.BuildUriStockChartData(tickerId, type, count);
            Debug.WriteLine($"{nameof(GetStockChartDataAsync)} : {nameof(tickerId)}={tickerId} : {nameof(type)}={type} : {nameof(count)}={count} : {nameof(Uri)}={Uri}");
            var data = await Client.GetJsonAsync<List<ChartData>>(Uri);
            if (data != null)
                rtn.AddRange(data);
            OnDataReceived?.Invoke(this, rtn);
            return rtn;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Stock>> SearchSymbolAsync(string symbolSearch)
        {
            Uri = Helper.BuildUriSearchSymbol(symbolSearch);
            Debug.WriteLine($"{nameof(WebullDataService)} : {nameof(SearchSymbolAsync)} : {symbolSearch} : {nameof(Uri)}={Uri}");
            var jsonString = await Client.GetJsonAsync(Uri, "stockAndEtfs");
            var result = JToken.Parse(jsonString).ToObject<IEnumerable<Stock>>();
            OnDataReceived?.Invoke(this, result);
            return result;
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            Debug.WriteLine($"{nameof(WebullDataService)} : {nameof(Dispose)} : {disposing}");
            base.Dispose(disposing);
            if (disposing)
            {
                AllOptions = null;
                StockCollection = null;
            }
        }

        // foreach (var expireOn in await GetExpireOnListAsync(tickerId)) { var data = await GetOptionAsync(tickerId, expireOn.Date); if (data.Data != null) foreach (var
        // option in data.Data) { //option.SpotPrice = data.Close; rtn.Add(option); } }
        private async Task<HttpContent> GetDataAsync(string url, string accessToken)
        {
            var _client = new System.Net.Http.HttpClient();

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await _client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return response.Content;
                }
                else
                {
                    // TODO WTS: Please handle other status codes as appropriate to your scenario
                }
            }
            catch (HttpRequestException)
            {
                // TODO WTS: The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout. Please handle
                // this exception as appropriate to your scenario
            }
            catch (Exception)
            {
                // TODO WTS: This call can fail please handle exceptions as appropriate to your scenario
            }

            return null;
        }

        /// <summary>Gets the option async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <param name="expDate"> The exp date.</param>
        /// <returns>A Task.</returns>
        [Obsolete]
        private async Task<IWebullOptionQuote> GetOptionAsync(long tickerId, DateTimeOffset expDate) => (await Client.GetJsonAsync(Helper.BuildUri(tickerId, expDate)))?.DeserializeObject<WebullOptionQuote>();

        /// <summary>Gets the option async.</summary>
        /// <param name="stock">  The stock.</param>
        /// <param name="expDate">The exp date.</param>
        /// <returns>A Task.</returns>
        [Obsolete]
        private async Task<IEnumerable<IWebullOptionQuote>> GetOptionAsync(Stock stock, DateTimeOffset expDate) => (await Client.GetJsonAsync(Helper.BuildUri(stock.TickerId, expDate)))?.DeserializeObject<IList<WebullOptionQuote>>();

        private void ProcessOption(ProcessOptionDelegate processOption)
        {
            foreach (var item in AllOptions)
                processOption(item);
        }

        //Task<IEnumerable<IStockQuoteComplete>> IWebullDataService.GetRealTimeMarketQuotes(IEnumerable<long> tickerIds, int batchSize)
        //{
        //    return null;
        //    //throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<OptionData>> GetAllOptionsAsyc(long tickerId)
        //{
        //    await Task.CompletedTask;
    }

    public delegate void ProcessOptionDelegate(IWebullOptionQuote option);
}