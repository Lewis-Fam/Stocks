using LewisFam.Utils;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LewisFam.Stocks.ThirdParty.Webull.Tests
{
    [TestClass()]
    public class WebullDataServiceTests
    {
        #region Methods

        [TestMethod()]
        public async Task FindStockAsyncTest()
        {
            using var webull = new WebullDataService();
            var stock = await webull.FindStockAsync("spce");
            Assert.IsNotNull(stock, "stock == null");
            Console.WriteLine(stock);
        }

        [TestMethod()]
        public async Task GetAllOptionsAsyncTest()
        {
            using var webull = new WebullDataService();
            var options = await webull.GetAllOptionsAsync(StocksUtil.StockList2021[0].TickerId);
            //File.WriteAllText("allOptions.json", await options.SerializeObjectToJsonAsync());
            Console.WriteLine(await options.Take(5).SerializeObjectToJsonAsync(true));
        }

        [TestMethod()]
        public async Task GetOptionStratListTest()
        {
            using var webull = new WebullDataService();
            var data = await webull.GetOptionStratList(StocksUtil.StockList2021[0].TickerId);
            Console.WriteLine(data);
        }

        [TestMethod()]
        public async Task GetRealTimeMarketQuotesTest()
        {
            using var webull = new WebullDataService();
            var quotes = await webull.GetRealTimeMarketQuotesAsync(StocksUtil.StockList2021.ToTickerIdList());
            Assert.IsTrue(quotes.Any(), "!quotes.Any()");
            Console.WriteLine(await quotes.SerializeObjectToJsonAsync());
        }

        [TestMethod()]
        public async Task GetRealTimeMarketQuoteTest()
        {
            using var webull = new WebullDataService();
            var stock = StocksUtil.StockList2021.GetRandomElements(1).First();
            var quote = await webull.GetRealTimeMarketQuoteAsync(stock.TickerId);
            Console.WriteLine(await quote.SerializeObjectToJsonAsync());
        }

        [TestMethod()]
        public async Task GetRealTimeOptionQuotesAsyncTest()
        {
            using var webull = new WebullDataService();
            var data = await webull.GetRealTimeOptionQuotesAsync(1019075592);
            Console.WriteLine(await data.SerializeObjectToJsonAsync(true));
        }

        [TestMethod()]
        public async Task GetRealTimeOptionQuotesAsyncTest_IncorrectId()
        {
            using var webull = new WebullDataService();
            var data = await webull.GetRealTimeOptionQuotesAsync(StocksUtil.StockList2021[0].TickerId);
            Console.WriteLine(await data.SerializeObjectToJsonAsync(true));
        }

        [TestMethod()]
        public async Task GetStockChartDataAsyncTest()
        {
            using var webull = new WebullDataService();
            var stock = StocksUtil.StockList2021.GetRandomElements(1).First();
            var data = await webull.GetStockChartDataAsync(stock.TickerId);
            Console.WriteLine(await data.SerializeObjectToJsonAsync());
        }

        [TestMethod()]
        public async Task SearchSymbolAsyncTest()
        {
            using var webull = new WebullDataService();
            var stock = await webull.SearchSymbolAsync("spc");
            if (stock != null)
                Console.WriteLine(await stock.SerializeObjectToJsonAsync());
        }

        #endregion Methods
    }
}