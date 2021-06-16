using Microsoft.VisualStudio.TestTools.UnitTesting;
using LewisFam.Stocks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LewisFam.Stocks.ThirdParty.Webull.Models;
using LewisFam.Utils.Json;

namespace LewisFam.Stocks.Tests
{
    [TestClass()]
    public class StocksUtilTests
    {
        [TestMethod()]
        public async Task GetRealTimeQuoteAsyncTest()
        {
            var quote = await StocksUtil.GetRealTimeMarketQuoteAsync(StocksUtil.StockList2021[0].TickerId);
            Assert.IsTrue(string.Equals(quote.Symbol, "SPCE", StringComparison.CurrentCultureIgnoreCase), "string.Equals(quote.Symbol, 'SPCE', StringComparison.CurrentCultureIgnoreCase)");
        }

        [TestMethod()]
        public async Task GetRealTimeQuotesAsyncTest()
        {
            var quotes = await StocksUtil.GetRealTimeMarketQuotesAsync(StocksUtil.StockList2021.ToTickerIdList());
            Assert.IsTrue(quotes.Count() == 29, "quotes.Count() == 29");
            Console.WriteLine($"Quotes: {await quotes.SerializeObjectToJsonAsync()}");
        }

        [TestMethod()]
        public async Task GetRealTimeQuotesAsyncTest2()
        {
            var quotes = await StocksUtil.GetRealTimeMarketQuotesAsync(StocksUtil.StockList2021.Take(4).ToTickerIdList());
            Assert.IsTrue(quotes.Count() == 4);
            Console.WriteLine($"Quotes: {await quotes.SerializeObjectToJsonAsync()}");
        }

        [TestMethod()]
        public async Task GetStockChartDataAsyncTest()
        {
            var chartDatas = await StocksUtil.GetStockChartDataAsync(StocksUtil.StockList2021[0].TickerId, ChartDataType.m120);
            foreach (var chartData in chartDatas)
            {
                foreach (var o in chartData.Data)
                {
                    var split = o.ToString()?.Split(",");
                    foreach (var s in split)
                    {
                        var shd = new StockChartDataModel();
                        shd.TradeTimeUnix = s[0];
                    }
                }
            }
        }
    }
}