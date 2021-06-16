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
        private IEnumerable<IChartData> _chartDatas;
        private long _invalidTickerId = 9500524;

        [TestMethod()]
        public async Task GetRealTimeQuoteAsync_InvalidSymbol_Test()
        {
            var quote = await StocksUtil.GetRealTimeMarketQuoteAsync(_invalidTickerId);
            Assert.IsNull(quote, "quote != null");
        }

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
            Console.WriteLine("{" + $"\"QuotesJson\" : {await quotes.SerializeObjectToJsonAsync()}" + "}");
        }

        [TestMethod()]
        public async Task GetRealTimeQuotesAsyncTest2()
        {
            var quotes = await StocksUtil.GetRealTimeMarketQuotesAsync(StocksUtil.StockList2021.Take(4).ToTickerIdList());
            Assert.IsTrue(quotes.Count() == 4);
            Console.WriteLine("{" + $"\"QuotesJson\" : {await quotes.SerializeObjectToJsonAsync()}" + "}");
        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_ChartTypeM1_Test()
        {
            _chartDatas = await StocksUtil.GetStockChartDataAsync(StocksUtil.StockList2021[0].TickerId, ChartDataType.m1);
            Assert.IsNotNull(_chartDatas, "_chartDatas == null");
        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_ChartTypeM120_Test()
        {
            _chartDatas = await StocksUtil.GetStockChartDataAsync(StocksUtil.StockList2021[0].TickerId, ChartDataType.m120);
            Assert.IsNotNull(_chartDatas, "_chartDatas == null");
        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_ChartTypeM240_Test()
        {
            _chartDatas = await StocksUtil.GetStockChartDataAsync(StocksUtil.StockList2021[0].TickerId, ChartDataType.m240);
            Assert.IsNotNull(_chartDatas, "_chartDatas == null");
        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_ChartTypeM5_Test()
        {
            _chartDatas = await StocksUtil.GetStockChartDataAsync(StocksUtil.StockList2021[0].TickerId, ChartDataType.m5);
            Assert.IsNotNull(_chartDatas, "_chartDatas == null");
        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_Invalid_TickerId_Test()
        {
            _chartDatas = await StocksUtil.GetStockChartDataAsync(_invalidTickerId, ChartDataType.m120);
            Assert.IsNotNull(_chartDatas, "_chartDatas == null");
            Assert.IsTrue(!_chartDatas.Any(), "_chartDatas.Any() is not true.");
        }
    }
}