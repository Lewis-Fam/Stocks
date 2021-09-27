using Microsoft.VisualStudio.TestTools.UnitTesting;
using LewisFam.Stocks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LewisFam.Stocks.Models;
using LewisFam.Utils;

namespace LewisFam.Stocks.Tests
{
    [TestClass()]
    public class StocksUtilTests
    {
        private Stock _sampleStock_MSFT = StocksUtil.StockList2021[2];

        [TestMethod()]
        public async Task FindStockAsync_Test()
        {
            var stock = await StocksUtil.FindStockAsync("MSFT");

            var expectedTickerId = _sampleStock_MSFT.TickerId;

            Assert.AreEqual(expectedTickerId, stock.TickerId, "expectedTickerId is not equal to stock.TickerId");
        }

        [TestMethod()]
        public async Task GetAllOptionsAsync_Test()
        {
            var options = await _sampleStock_MSFT.GetAllOptionsAsync();
            Assert.IsNotNull(options, "options == null");
            Console.WriteLine(await options.Take(3).SerializeObjectToJsonAsync());
        }

        [TestMethod()]
        public void GetRealTimeOptionQuotesAsync_Test()
        {

        }
    }
}