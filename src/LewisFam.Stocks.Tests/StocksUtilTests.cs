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
        private Stock _stock;

        [TestMethod()]
        public async Task GetRealTimeQuoteAsync_InvalidSymbol_Test()
        {
            var quote = await StocksUtil.GetRealTimeMarketQuoteAsync(_invalidTickerId);
            Assert.IsNull(quote, "quote != null");
        }

        [TestMethod()]
        public async Task GetRealTimeQuoteAsyncTest()
        {
            _stock = StocksUtil.StockList2021.GetRandomElements(1).First();
            Console.WriteLine(_stock);
            var quote = await StocksUtil.GetRealTimeMarketQuoteAsync(_stock.TickerId);
            Assert.IsTrue(string.Equals(quote.Symbol, _stock.Symbol, StringComparison.CurrentCultureIgnoreCase), "!string.Equals(quote.Symbol, _stock.Symbol, StringComparison.CurrentCultureIgnoreCase)");
        }
        [TestMethod()]
        public async Task GetRealTimeQuotesAsyncTest()
        {
            var quotes = await StocksUtil.GetRealTimeMarketQuotesAsync(StocksUtil.StockList2021.ToTickerIdList());
            Assert.IsTrue(quotes.Count() == 29, "quotes.Count() == 29");
            Console.WriteLine("{" + $"\"QuotesJson\" : {await quotes.SerializeObjectToJsonAsync()}" + "}");
        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_ChartTypeM1_Test()
        {
            _stock = StocksUtil.StockList2021.GetRandomElements(1).First();
            Console.WriteLine(_stock);
            _chartDatas = await StocksUtil.GetStockChartDataAsync(_stock.TickerId, ChartDataType.m1);
            Assert.IsNotNull(_chartDatas, "_chartDatas == null");
        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_ChartTypeM120_Test()
        {
            _stock = StocksUtil.StockList2021.GetRandomElements(1).First();
            Console.WriteLine(_stock);
            _chartDatas = await StocksUtil.GetStockChartDataAsync(_stock.TickerId, ChartDataType.m120);
            Assert.IsNotNull(_chartDatas, "_chartDatas == null");
        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_ChartTypeM240_Test()
        {                                                                     
            _stock = StocksUtil.StockList2021.GetRandomElements(1).First();
            Console.WriteLine(_stock);
            _chartDatas = await StocksUtil.GetStockChartDataAsync(_stock.TickerId, ChartDataType.m240);
            Assert.IsNotNull(_chartDatas, "_chartDatas == null");
            
        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_ChartTypeM5_Test()
        {
            _stock = StocksUtil.StockList2021.GetRandomElements().First();
            Console.WriteLine(_stock);
            _chartDatas = await StocksUtil.GetStockChartDataAsync(_stock.TickerId, ChartDataType.m5);
            Assert.IsNotNull(_chartDatas, "_chartDatas == null");
            
        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_Invalid_TickerId_Test()
        {
            _chartDatas = await StocksUtil.GetStockChartDataAsync(_invalidTickerId, ChartDataType.m120);
            Assert.IsNotNull(_chartDatas, "_chartDatas == null");
            Assert.IsTrue(!_chartDatas.Any(), "_chartDatas.Any() is not true.");
        }

        [TestMethod()]
        public async Task GetAllStockOptionsTest()
        {
            _stock = StocksUtil.StockList2021.GetRandomElements(5).First();
            var options = (await StocksUtil.GetAllStockOptions(_stock.TickerId));
            //Assert.IsNotNull(options, "options == null");
            Console.WriteLine(await options.Take(2).SerializeObjectToJsonAsync());
        }
    }
}