using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LewisFam.Stocks.ThirdParty.Webull.Models;
using LewisFam.Utils;
using LewisFam.Well_Known;

namespace LewisFam.Stocks.ThirdParty.Webull
{
    public partial class WebullDataService
    {
        public async Task<string> GetFinancialsSimple(long tickerId)
        {
            Uri = Helper.BuildUriFinancialSimple(tickerId);
            var json = await Client.GetJsonAsync(Uri);
            return json;
        }

        public async Task<object> GetOptionStratList(long tickerId)
        {
            Uri = Helper.BuildUriOptionStratList();
            var payLoad = new WebullOptionStratRequestBody(tickerId);
            var json = await payLoad.SerializeObjectToJsonAsync();
            var response = await Client.PostAsync(Uri, new StringContent(json, Encoding.UTF8, MIME.Application.Json));
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var rtn = await jsonResponse.DeserializeObjectAsync<object>();
            Debug.WriteLine($"{jsonResponse}");
            return rtn;
        }

        public Task GetOptionChartData(long derivedId)
        {
            Uri = Helper.BuildUriOptionChartData(derivedId);
            var data = Client.GetAsync<object>(Uri);
            return Task.CompletedTask;
        }

        public async Task<ICollection<WebullRealTimeOptionQuote>> GetRealTimeOptionQuotesAsync(long derivedId)
        {
            Uri = Helper.BuilUriOptionQuote(derivedId);
            return await Client.GetAsync<List<WebullRealTimeOptionQuote>>(Uri);
        }
    }


    public class WebullOptionStratRequestBody
    {
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

}
