using System;
using System.Collections.Generic;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.ThirdParty.Webull.Models;

namespace LewisFam.Stocks.Internal
{
    internal class StockMonitor
    {
        public StockMonitor(ThingsToMonitor thingsToMonitor)
        {
            ThingsToMonitor = thingsToMonitor;
        }

        public bool Enable { get; set; }
        
        public event EventHandler StockAlert;

        public ThingsToMonitor ThingsToMonitor { get; }

        public void Run()
        {
            if (!Enable)
                return;

            foreach (var stock in ThingsToMonitor.Stocks)
            {
                RaiseStockAlert(stock);
            }
        }

        private void RaiseStockAlert(Stock stock)
        { 
            StockAlert?.Invoke(this, EventArgs.Empty);
        }
    }

    internal class ThingsToMonitor
    {
        public ThingsToMonitor()
        {
            Stocks = new List<Stock>();
            OptionQuotes = new List<WebullOptionQuote>();
        }

        public IList<Stock> Stocks { get; }
        public IList<WebullOptionQuote> OptionQuotes { get; }
    }
}