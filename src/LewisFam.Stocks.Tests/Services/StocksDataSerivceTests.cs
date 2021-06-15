using Microsoft.VisualStudio.TestTools.UnitTesting;
using LewisFam.Stocks.Services;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LewisFam.Stocks.ThirdParty.Webull.Models;


namespace LewisFam.Stocks.Services.Tests
{
    [TestClass()]
    public class StocksDataSerivceTests
    {
        [TestMethod()]
        public async Task GetRealTimeMarketQuotesTest()
        {
            //using var webull = new StocksDataSerivce();
            //var quotes = await webull.GetRealTimeMarketQuotes(_stocks.ToTickerIdList());
        }
    }
}