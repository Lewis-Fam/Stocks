using Microsoft.VisualStudio.TestTools.UnitTesting;
using LewisFam.Stocks.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LewisFam.Utils;

namespace LewisFam.Stocks.Models.Tests
{
    [TestClass()]
    public class StockOptionTests
    {
        [TestMethod()]
        public async Task GetOptionDataTest()
        {
            var so = new StockOption(StocksUtil.StockList2021[0], null);
            var data = await so.GetAllStockOptionsAsync();

            //var json = await data.SerializeObjectToJsonAsync(true);
            //FileUtil.WriteAllText("alloptions.json", json);
            //Console.WriteLine(d.Count);
            Assert.Fail();
        }
    }
}