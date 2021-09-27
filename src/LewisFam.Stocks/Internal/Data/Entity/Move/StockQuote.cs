using System;
using System.ComponentModel.DataAnnotations.Schema;
using LewisFam.Stocks.Models;

namespace LewisFam.Stocks.Entity
{
    [Table("StockQuotes", Schema = "trading")]
    public class StockQuote : Stock, IStockQuote
    {
        public StockQuote(string symbol)
        {
            Symbol = symbol; 
            //Vendor = Models.Enums.Vendor.Cnbc;
        }

        //[Key]
        public virtual long QuoteId { get; protected set; }
        public virtual double Change { get; set; }
        public virtual double Close { get; set; }
        public virtual double High { get; set; }
        public virtual double Last { get; set; }
        public virtual double Low { get; set; }
        public virtual double Open { get; set; }
        public virtual long Volume { get; set; }
        public virtual double Price { get; set; }
        public virtual long TimeStamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}
