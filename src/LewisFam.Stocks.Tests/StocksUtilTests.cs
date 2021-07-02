using Microsoft.VisualStudio.TestTools.UnitTesting;
using LewisFam.Stocks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.ThirdParty.Webull.Models;
using LewisFam.Utils;

namespace LewisFam.Stocks.Tests
{
    [TestClass()]
    public class StocksUtilTests
    {
        private IEnumerable<IChartData> _chartDataItems;
        private const long InvalidTickerId = 9500524;
        private Stock _stock;

        [TestMethod()]
        public async Task GetRealTimeQuoteAsync_InvalidSymbol_Test()
        {
            //var quote = await StocksUtil.GetRealTimeMarketQuoteAsync(InvalidTickerId);
            //Assert.IsNull(quote, "quote != null");
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

            //Console.WriteLine("{" + $"\"QuotesJson\" : {await quotes.SerializeObjectToJsonAsync()}" + "}");
            Console.WriteLine($"{await quotes?.Take(5)?.SerializeObjectToJsonAsync(true)}");
            Assert.IsTrue(quotes?.Count() == 29, "quotes.Count() == 29");
        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_ChartTypeM1_Test()
        {
            _stock = StocksUtil.StockList2021.GetRandomElements(1).First();
            Console.WriteLine(_stock);
            _chartDataItems = await StocksUtil.GetStockChartDataAsync(_stock.TickerId, ChartDataType.m1);
            Assert.IsNotNull(_chartDataItems, "_chartDatas == null");
            Console.WriteLine(await _chartDataItems.SerializeObjectToJsonAsync());
        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_ChartTypeM120_Test()
        {
            _stock = StocksUtil.StockList2021.GetRandomElements(1).First();
            Console.WriteLine(_stock);
            _chartDataItems = await StocksUtil.GetStockChartDataAsync(_stock.TickerId, ChartDataType.m120);
            Assert.IsNotNull(_chartDataItems, "_chartDatas == null");
        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_ChartTypeM240_Test()
        {
            _stock = StocksUtil.StockList2021.GetRandomElements(1).First();
            Console.WriteLine(_stock);
            _chartDataItems = await StocksUtil.GetStockChartDataAsync(_stock.TickerId, ChartDataType.m240);
            Assert.IsNotNull(_chartDataItems, "_chartDatas == null");

        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_ChartTypeM5_Test()
        {
            _stock = StocksUtil.StockList2021.GetRandomElements(1).First();
            Console.WriteLine(_stock);
            _chartDataItems = await StocksUtil.GetStockChartDataAsync(_stock.TickerId, ChartDataType.m5);
            Assert.IsNotNull(_chartDataItems, "_chartDatas == null");

        }

        [TestMethod()]
        public async Task GetStockChartDataAsync_Invalid_TickerId_Test()
        {
            _chartDataItems = await StocksUtil.GetStockChartDataAsync(InvalidTickerId, ChartDataType.m120);
            Assert.IsNotNull(_chartDataItems, "_chartDatas == null");
            Assert.IsTrue(!_chartDataItems.Any(), "_chartDatas.Any() is not true.");
        }

        [TestMethod()]
        public async Task GetAllStockOptionsTest()
        {
            _stock = StocksUtil.StockList2021.GetRandomElements(1).First();
            Console.WriteLine(_stock);
            var options = (await StocksUtil.GetAllStockOptionsAsync(_stock.TickerId));
            //Assert.IsNotNull(options, "options == null");
            Console.WriteLine(await options.Take(2).SerializeObjectToJsonAsync());
        }

        [TestMethod()]
        public async Task FindStockAsync_Null_Test()
        {
            var stock = await StocksUtil.FindStockAsync("spc");
            Assert.IsNull(stock);
        }

        [TestMethod()]
        public async Task FindStockAsync_NotNull_Test()
        {
            var stock = await StocksUtil.FindStockAsync("spce");
            Assert.IsNotNull(stock);
            Console.WriteLine(stock);
        }

        [TestMethod()]
        public async Task GetCnbcStockQuotesAsyncTest()
        {
            var quotes = await StocksUtil.GetCnbcStockQuotesAsync(StocksUtil.StockList2021.ToSymbolList());
            Console.WriteLine(await quotes.SerializeObjectToJsonAsync());
        }
    }
}