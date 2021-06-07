using System;

namespace LewisFam.Stocks.ThirdParty.Cnbc.Models
{
    internal class QueryCompletedEventArgs : EventArgs
    {
        public QueryCompletedEventArgs(string results)
        {
            Results = results ?? throw new ArgumentNullException(nameof(results));
            Stamp = DateTime.Now;
        }

        public string Results { get; }

        public DateTimeOffset Stamp { get; }
    }
}