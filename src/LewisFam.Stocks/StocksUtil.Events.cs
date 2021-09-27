using System;
using System.Collections.Generic;
using LewisFam.Stocks.ThirdParty.Webull.Models;

namespace LewisFam.Stocks
{
    public class OptionQuotesArgs : EventArgs
    {
        public OptionQuotesArgs(string id, IEnumerable<IRealTimeOptionQuote> quotes)
        {
            Id = id;
            Quotes = quotes;
        }

        protected string Id { get; }
        public IEnumerable<IRealTimeOptionQuote> Quotes { get; }
    }

    public static partial class StocksUtil
    {
    }
}
