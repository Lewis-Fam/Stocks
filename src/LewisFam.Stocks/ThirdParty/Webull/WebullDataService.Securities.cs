using LewisFam.Stocks.Models;
using LewisFam.Stocks.ThirdParty.Webull.Models;
using LewisFam.Utils;
using LewisFam.Well_Known;

using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LewisFam.Stocks.Options.Models;

namespace LewisFam.Stocks.ThirdParty.Services
{
    public partial interface IWebullDataService
    {
        Task<object> GetFinancialsSimpleAsync(long tickerId);

        Task<object> GetFinancialsSimpleAsync(Stock stock);

        Task<string> GetOptionChartDataAsync(long derivedId);

        Task<object> GetOptionChartDataAsync(IOption optionQuote);

        Task<object> GetOptionStratAsync(long tickerId);

        Task<string> GetRealTimeOptionQuoteDetailsAsync(IEnumerable<long> derivedIds, long tickerId);

        Task<IEnumerable<WebullOptionQuote>> GetRealTimeOptionQuoteAsync(long derivedId);

        Task<IEnumerable<WebullOptionQuote>> GetRealTimeOptionQuoteAsync(IOption optionQuote);

        Task<IEnumerable<WebullOptionQuote>> GetRealTimeOptionQuotesAsync(IEnumerable<long> derivedIds, int batchSize = 50);
    }
}

namespace LewisFam.Stocks.ThirdParty.Webull
{
    public partial class WebullDataService
    {
        private class WebullOptionStratRequestBody
        {
            /// <summary>Initializes a new instance of the <see cref="WebullOptionStratRequestBody"/> class.</summary>
            /// <param name="tickerId">The ticker id.</param>
            public WebullOptionStratRequestBody(long tickerId)
            {
                count = 100;
                direction = "all";
                expireCycle = new[]
                {
                    2, 3, 4
                };
                queryFirst = true;
                this.tickerId = tickerId.ToString();
                type = 0;
            }

            public int count { get; }

            public string direction { get; }

            public int[] expireCycle { get; }

            public bool queryFirst { get; }

            public string tickerId { get; }

            public int type { get; }
        }


        public async Task<object> GetFinancialsSimpleAsync(long tickerId)
        {
            Debug.WriteLine($"{nameof(GetFinancialsSimpleAsync)} called with {nameof(tickerId)}={tickerId}");
            Uri = Helper.BuildUriFinancialSimple(tickerId);
            return await Client.GetJsonAsync(Uri);
        }

        public async Task<object> GetFinancialsSimpleAsync(Stock stock)
        {
            return await GetFinancialsSimpleAsync(stock.TickerId);
        }

        public async Task<object> GetOptionChartDataAsync(IOption optionQuote)
        {
            return await GetOptionChartDataAsync(optionQuote.TickerId);
        }

        public async Task<string> GetOptionChartDataAsync(long derivedId)
        {
            Debug.WriteLine($"{nameof(GetOptionChartDataAsync)} called with {nameof(derivedId)}={derivedId}");
            Uri = Helper.BuildUriOptionChartData(derivedId);
            return await Client.GetJsonAsync(Uri);
        }

        public async Task<object> GetOptionStratAsync(Stock stock)
        {
            return await GetOptionStratAsync(stock.TickerId);
        }

        public async Task<string> GetRealTimeOptionQuoteDetailsAsync(IEnumerable<long> derivedIds, long tickerId)
        {
            Uri = Helper.BuildUriOptionQuoteDetail(derivedIds, tickerId);
            return await Client.GetJsonAsync(Uri);
        }

        public async Task<object> GetOptionStratAsync(long tickerId)
        {
            Uri = Helper.BuildUriOptionStratList();
            Debug.WriteLine($"{nameof(GetOptionStratAsync)} called with {nameof(tickerId)}={tickerId}");
            var payLoad = new WebullOptionStratRequestBody(tickerId);
            var json = await payLoad.SerializeObjectToJsonAsync();
            var response = await Client.PostAsync(Uri, new StringContent(json, Encoding.UTF8, MIME.Application.Json));
            var jsonResponse = await response.Content.ReadAsStringAsync();
            OnDataReceived?.Invoke(this, jsonResponse);
            //var rtn = await jsonResponse.DeserializeObjectAsync<object>();
            //Debug.WriteLine($"{jsonResponse}");
            return jsonResponse;
        }

        public async Task<IEnumerable<WebullOptionQuote>> GetRealTimeOptionQuoteAsync(long derivedId)
        {
            Uri = Helper.BuilUriOptionQuote(derivedId);
            Debug.WriteLine($"{nameof(GetRealTimeOptionQuoteAsync)} called. ");
            return await Client.GetJsonAsync<List<WebullOptionQuote>>(Uri);
        }

        public async Task<IEnumerable<WebullOptionQuote>> GetRealTimeOptionQuoteAsync(IOption optionQuote)
        {
            Debug.Assert(optionQuote.TickerId != null, "optionQuote.TickerId != null");
            return await GetRealTimeOptionQuoteAsync(optionQuote.TickerId);
        }

        public async Task<IEnumerable<WebullOptionQuote>> GetRealTimeOptionQuotesAsync(IEnumerable<long> derivedIds, int batchSize = 50)
        {
            Uri = Helper.BuilUriOptionQuotes(derivedIds);
            Debug.WriteLine($"{nameof(GetRealTimeOptionQuotesAsync)} called. {nameof(Uri)}={Uri}");
            return await Client.GetJsonAsync<List<WebullOptionQuote>>(Uri);
        }
    }
}