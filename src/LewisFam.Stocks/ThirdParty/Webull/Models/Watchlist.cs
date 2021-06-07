using System;
using System.Collections.Generic;
using LewisFam.Stocks.Models;
using LewisFam.Utils.File;
using LewisFam.Utils.Json;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    public class Watchlist
    {
        public Watchlist()
        {
        }

        public virtual Guid? Id { get; set; } = Guid.NewGuid();

        public virtual DateTime? LastUpdated { get; set; } = DateTime.Now;

        public virtual string Name { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

        /// <summary>
        /// Gets a sample mock watchlist.
        /// </summary>
        /// <returns>A Watchlist.</returns>
        [Obsolete("Move to test class")]
        public static Watchlist GetMockWatchlist()
        {
            return new Watchlist
            {
                Name = "Mock Watchlist",
                Stocks = new List<Stock>
                {
                    //new Stock("MSFT", 913323997),
                    //new Stock("SPCE",950052430),
                    //new Stock("NVDA",913257561),
                    //new Stock("AMD",913254235),
                    //new Stock("GE", 913255327),
                    //new Stock("ROKU", 925376726),
                    //new Stock("CMG", 913255105),
                    //new Stock("GD", 913255326),
                    //new Stock("LMT", 913255490),
                    //new Stock("DIS", 913255192),
                    //new Stock("MAXR", 950052426),
                    //new Stock("BA", 913254998)
                }
            };
        }

        /// <summary>
        /// Writes the watchlist as json to file.
        /// </summary>
        /// <param name="watchlist">The watchlist.</param>
        /// <param name="path">The path.</param>
        /// <param name="format">If true, format.</param>
        public static void WriteToFile(Watchlist watchlist, string path, bool format = false)
        {
            FileUtil.WriteAllText(path, watchlist.ToJson(format));
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? base.ToString() : $"{Name}";
        }        
    }
}