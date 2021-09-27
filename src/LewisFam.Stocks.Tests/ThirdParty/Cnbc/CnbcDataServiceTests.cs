//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Threading.Tasks;
//using System.Diagnostics;
////using LewisFam.Utils;

//namespace LewisFam.Stocks.ThirdParty.Cnbc.Tests
//{
//    [TestClass()]
//    public class CnbcDataServiceTests
//    {
//        private string _symbol = "spce";

//        private string[] _symbols = 
//        {
//            " spce", "msft"
//        };

//        [TestMethod()]
//        public async Task GetRealTimeMarketQuoteAsyncTest()
//        {
//            using var cnbc = new CnbcDataService();
//            var quote = await cnbc.GetRealTimeMarketQuoteAsync(_symbol);
//            Debug.WriteLine("Quote: " + quote.ToJson());
//            Assert.IsNotNull(quote, "The quote is null");
//        }

//        [TestMethod()]
//        public async Task GetRealTimeMarketQuotesAsyncTest()
//        {
//            using var cnbc = new CnbcDataService();
//            var quotes = await cnbc.GetRealTimeMarketQuotesAsync(_symbols);
//            Debug.WriteLine("Quote: " + quotes.ToJson());
//            Assert.IsNotNull(quotes, "The quote is null");
//        }
//    }
//}