using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LewisFam.Extensions;
using LewisFam.Stocks.Internal.Models;
using LewisFam.Stocks.ThirdParty.Cnbc.Models;
using LewisFam.Stocks.ThirdParty.Services;
using LewisFam.Well_Known.Enums;
using Newtonsoft.Json.Linq;

namespace LewisFam.Stocks.ThirdParty.Cnbc
{
    /// <summary>
    /// The cnbc data service.
    /// </summary>
    public sealed partial class CnbcDataService : BaseDataService, ICnbcDataService
    {
        //private IStocksDataService stocksDataService;
        internal event EventHandler<QueryCompletedEventArgs> OnQuote;

        /// <inheritdoc/>
        public async Task<Cnbc.Models.IStockQuote> GetRealTimeMarketQuoteAsync(string symbol)
        {
            if (string.IsNullOrEmpty(symbol)) return null;
                       
            Uri = Helper.BuildUri(symbol);
            var data = await Client.GetAsync<JObject>(Uri);
            var rtn = data.SelectToken(Helper.TokenQuickQuote)?.ToObject<CnbcStockQuote>();
            return rtn?.CachedTime != null ? rtn : null;
        }
     
        /// <inheritdoc/>
        public async Task<IEnumerable<IStockQuote>> GetRealTimeMarketQuotesAsync(ICollection<string> symbols, int batchSize = 20)
        {
            var rtn = new List<IStockQuote>();
            //If symbols.Count == 1 the request fails. Therefore, append a fake or real symbol.
            //or use the GetMarketQuoteAsync(string)
            //var s = symbols;
            if (symbols.Count == 1)
            {
                rtn.Add(await GetRealTimeMarketQuoteAsync(symbols.First()));
                return rtn;
                //s.Add("tdl");;
            }

            //Too many symbols and the request  fails. Therefore, split the request into batches.
            var batches = symbols.Batch(batchSize);

            foreach (var b in batches)
            {
                Uri = Helper.BuildUri(b.Select(symbol => symbol));
                var data = await Client.GetAsync<JObject>(Uri);
                rtn.AddRange(data.SelectToken(Helper.TokenQuickQuote)?.ToObject<IEnumerable<CnbcStockQuote>>() ?? Array.Empty<CnbcStockQuote>());
            }

            return rtn;
        }

        /// <inheritdoc/>
        [Obsolete("Fix this method.")]
        public async Task<IEnumerable<PriceBar>> GetPriceBarsAsync(string symbol, TimeUnit durationGroup, string start, string end)
        {
            string durationString;
            string startDate;
            string endDate;

            //startDate = start.Date.ToString(Helper.DateFormat);
            //endDate = end.Date.ToString(Helper.DateFormat);

            switch (durationGroup)
            {
                case TimeUnit.Intraday:
                    durationString = "1M";
                    break;

                case TimeUnit.Day:
                    durationString = "1H";
                    break;

                default:
                    durationString = "5M";
                    break;
            }

            Uri = new Uri($"{Helper.BaseUriCharts}/{symbol}/{durationString}/{start}/{end}/{Helper.ChartQuery}");
            var data = await Client.GetAsync<JObject>(Uri);

            var s = data.SelectToken(Helper.TokenBarData);

            return s != null && s.HasValues ? s.ToObject<IEnumerable<PriceBar>>() : null;
        }

        [Obsolete("Fix this method.")]
        public async Task<IEnumerable<PriceBar>> GetPriceBarsAsync(string symbol)
        {
            string durationString;
            string startDate;
            string endDate;

            //startDate = start.Date.ToString(Helper.DateFormat);
            //endDate = end.Date.ToString(Helper.DateFormat);

            //switch (durationGroup)
            //{
            //    case Duration.Intraday:
            //        durationString = "1M";
            //        break;

            //    case Duration.Day:
            //        durationString = "1H";
            //        break;

            //    default:
            //        durationString = "5M";
            //        break;
            //}

            //Uri = new Uri($"{Helper.BaseUriCharts}/{symbol}/{durationString}/{start}/{end}/{Helper.ChartQuery}");
            var data = await Client.GetAsync<JObject>(Uri);

            var s = data.SelectToken(Helper.TokenBarData);

            return s != null && s.HasValues ? s.ToObject<PriceBar[]>() : null;
        }

        public async Task<object> RawQuote(string symbol, string token = null)
        {
            if (string.IsNullOrEmpty(symbol)) throw new ArgumentNullException(nameof(symbol));

            Uri = Helper.BuildUri(symbol);
            var data = await Client.GetAsync<JObject>(Uri);
            return token != null ? data.SelectToken(token) : data;
        }
    }
}