using System.Threading.Tasks;

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
    }
}
