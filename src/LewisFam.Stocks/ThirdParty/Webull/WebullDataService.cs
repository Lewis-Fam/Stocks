using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using LewisFam.Extensions;
using LewisFam.Stocks.Internal.Models;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.z;
using LewisFam.Stocks.ThirdParty.Services;
using LewisFam.Stocks.ThirdParty.Webull.Models;
using LewisFam.Utils.Json;

using Newtonsoft.Json.Linq;

namespace LewisFam.Stocks.ThirdParty.Webull
{
    /// <summary>The webull data service.</summary>
    public sealed partial class WebullDataService : BaseDataService, IWebullDataService
    {
        public IEnumerable<IWebullOptionQuote> AllOptions { get; private set; }

        ///<inheritdoc/>
        public async Task<Stock> FindStockAsync(string symbol)
        {
            Debug.WriteLine($"{nameof(FindStockAsync)} : {nameof(symbol)}={symbol}");
            Uri = Helper.BuildUriSearchSymbol(symbol);
            var jsonString = await Client.GetJsonAsync(Uri, "stockAndEtfs");
            var result = JToken.Parse(jsonString).ToObject<IEnumerable<Stock>>();
            var stock = result?.FirstOrDefault();
            return string.Equals(stock?.Symbol, symbol, StringComparison.CurrentCultureIgnoreCase) ? stock : null;
        }

        ///<inheritdoc/>
        public async Task<long?> FindStockIdAsync(string symbol)
        {
            Debug.WriteLine($"{nameof(FindStockIdAsync)} : {nameof(symbol)}={symbol}");
            var result = await FindStockAsync(symbol);
            return result?.TickerId;
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<IWebullOptionQuote>> GetAllOptionsAsync(long tickerId)
        {
            Debug.WriteLine($"{nameof(GetAllOptionsAsync)} : {nameof(tickerId)}={tickerId}");
            var rtn = new List<Option>();

            foreach (var expireOn in await getExpireOnListAsync(tickerId))
            {
                var data = await GetOptionAsync(tickerId, expireOn.Date);

                if (data.Data != null)
                    foreach (var option in data.Data)
                    {
                        option.SpotPrice = data.Close;
                        rtn.Add(option.Put);
                        rtn.Add(option.Call);
                    }
            }

            AllOptions = rtn;

            return rtn;
        }

        ///<inheritdoc/>
        public async Task<IWebullOptionQuote> GetOptionAsync(long tickerId) => (await Client.GetJsonAsync(Helper.BuildUriGetOptions(tickerId)))?.DeserializeObject<Option>();

        ///<inheritdoc/>
        public async Task<IWebullOptionQuote> GetOptionAsync(string symbol)
        {
            var id = await FindStockIdAsync(symbol);
            return !id.HasValue ? null : (await Client.GetJsonAsync(Helper.BuildUriGetOptions(id.Value)))?.DeserializeObject<Option>();
        }

        ///<inheritdoc/>
        public async Task<IRealTimeStockQuote> GetRealTimeMarketQuoteAsync(long tickerId)
        {
            Debug.WriteLine($"{nameof(GetRealTimeMarketQuoteAsync)} : {nameof(tickerId)}={tickerId}");
            var ids = new List<long>
            {
                tickerId
            };

            Uri = Uri = Helper.BuildUriRealTimeStockQuotes(ids);
            var data = await Client.GetAsync<List<WebullStockQuote>>(Uri);
            return data.FirstOrDefault();
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<IRealTimeStockQuote>> GetRealTimeMarketQuotesAsync(IEnumerable<long> tickerIds, int batchSize = 50)
        {
            Debug.WriteLine($"{nameof(GetRealTimeMarketQuotesAsync)} : {nameof(batchSize)}={batchSize}");
            var rtn = new List<IRealTimeStockQuote>();
            var batches = tickerIds.Batch(batchSize);
            var batchIndex = 0;

            foreach (var b in batches)
            {
                Debug.WriteLine($"BatchIndex={batchIndex}");
                Uri = Helper.BuildUriRealTimeStockQuotes(b.Select(i => i));
                var data = await Client.GetAsync<List<WebullStockQuote>>(Uri);
                rtn.AddRange(data);
                batchIndex++;
            }

            return rtn;
        }

        /// <summary>Gets the stock chart data async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>A list of IChartData.</returns>
        public async Task<IEnumerable<IChartData>> GetStockChartDataAsync(long tickerId)
        {
            Debug.WriteLine($"{nameof(GetRealTimeMarketQuotesAsync)} : {nameof(tickerId)}={tickerId}");
            Uri = Helper.BuildUriStockChartData(tickerId);
            Debug.WriteLine($"Uri={Uri}");
            var data = await Client.GetAsync<List<ChartData>>(Helper.BuildUriStockChartData(tickerId));
            return data;
        }

        public void ProcessOption(ProcessOptionDelegate processOption)
        {
            foreach (var item in AllOptions)
                processOption(item);
        }

        /// <summary>Searches the symbol async.</summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>A list of stocks.</returns>
        public async Task<IEnumerable<Stock>> SearchSymbolAsync(string symbol)
        {
            Debug.WriteLine($"{nameof(WebullDataService)} : {nameof(SearchSymbolAsync)} : {symbol}");
            Uri = Helper.BuildUriSearchSymbol(symbol);
            var jsonString = await Client.GetJsonAsync(Uri, "stockAndEtfs");
            var result = JToken.Parse(jsonString).ToObject<IEnumerable<Stock>>();
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

        // var rtn = new List<OptionData>();
        //    return rtn;
        //}
        /// <summary>Gets the expire on list async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <returns>A Task.</returns>
        private async Task<IEnumerable<ExpireOn>> getExpireOnListAsync(long tickerId)
        {
            var data = await Client.GetJsonAsync(Helper.BuildUriGetOptions(tickerId));
            var option = data.DeserializeObject<Option>().ExpireDateList;
            return option;
        }

        /// <summary>Gets the option async.</summary>
        /// <param name="tickerId">The ticker id.</param>
        /// <param name="expDate"> The exp date.</param>
        /// <returns>A Task.</returns>
        private async Task<IWebullOptionQuote> GetOptionAsync(long tickerId, DateTimeOffset expDate) => (await Client.GetJsonAsync(Helper.BuildUri(tickerId, expDate)))?.DeserializeObject<Option>();

        /// <summary>Gets the option async.</summary>
        /// <param name="stock">  The stock.</param>
        /// <param name="expDate">The exp date.</param>
        /// <returns>A Task.</returns>
        private async Task<IEnumerable<IWebullOptionQuote>> GetOptionAsync(Stock stock, DateTimeOffset expDate) => (await Client.GetJsonAsync(Helper.BuildUri(stock.TickerId, expDate)))?.DeserializeObject<IList<Option>>();

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