using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Options.Models;

namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    /// <summary>
    /// The option.
    /// </summary>
    [Serializable]
    public sealed class WebullOptionQuote : RealTimeOptionQuote, IWebullOptionQuote
    {
        public WebullOptionQuote()
        {
        }

        public WebullOptionQuote(Stock stock)
        {
            Stock = stock;
        }
        
        public long Id { get; set; }
        public Guid? BatchId { get; set; }

        [NotMapped]
        public IEnumerable<WebullOptionQuote> Data { get; set; }
        [NotMapped]
        public IEnumerable<ExpireOn> ExpireDateList { get; set; }
        [NotMapped]
        public WebullOptionQuote Call { get; set; }
        [NotMapped]
        public WebullOptionQuote Put { get; set; }

        public DateTimeOffset UpdatedOn { get; private set; } = DateTime.UtcNow;
    }
}
