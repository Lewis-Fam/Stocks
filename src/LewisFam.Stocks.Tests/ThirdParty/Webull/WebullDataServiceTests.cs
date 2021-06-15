using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LewisFam.Utils.Json;

namespace LewisFam.Stocks.ThirdParty.Webull.Tests
{
    [TestClass()]
    public class WebullDataServiceTests
    {
        [TestMethod()]
        public async Task FindStockAsyncTest()
        {
            using var webull = new WebullDataService();
            var stock = await webull.FindStockAsync("spce");
            if (stock != null)
                Console.WriteLine(await stock.ToJsonAsync()); //Debug.WriteLine($"{stock.Symbol},{stock.TickerId}");
        }

        [TestMethod()]
        public async Task GetAllOptionsAsyncTest()
        {
            using var webull = new WebullDataService();
            var options = await webull.GetAllOptionsAsync(950052430);
            Console.WriteLine(await options.Take(5).SerializeObjectToJsonAsync());
        }

        [TestMethod()]
        public async Task SearchSymbolAsyncTest()
        {
            using var webull = new WebullDataService();
            var stock = await webull.SearchSymbolAsync("spc");
            if (stock != null)
                Console.WriteLine(await stock.SerializeObjectToJsonAsync());
        }

        [TestMethod()]
        public async Task GetRealTimeMarketQuoteTest()
        {
            using var webull = new WebullDataService();
            var quote = await webull.GetRealTimeMarketQuoteAsync(StocksUtil.StockList2021[0].TickerId);
            Console.WriteLine(quote.Symbol);
        }


        [TestMethod()]
        public async Task GetRealTimeMarketQuotesTest()
        {
            using var webull = new WebullDataService();
            var quotes = await webull.GetRealTimeMarketQuotesAsync(StocksUtil.StockList2021.ToTickerIdList());
        }

        [TestMethod()]
        public async Task GetStockChartDataAsyncTest()
        {
           using var webull = new WebullDataService(); 
           var data = await webull.GetStockChartDataAsync(StocksUtil.StockList2021[0].TickerId);
           Console.WriteLine(await data.SerializeObjectToJsonAsync());
        }
    }
}