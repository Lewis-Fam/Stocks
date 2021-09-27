using System;
using LewisFam.Stocks.Models.Enums;
using LewisFam.Stocks.ThirdParty.Webull.Models;

namespace LewisFam.Stocks.Models.Trading
{
    public class OrderItem
    {
        //[Key]
        public Guid Id { get; set; }
        public int Contracts { get; set; }
        public BuySell BuySell { get; set; }
        public IWebullOptionQuote Option { get; set; }

        public double OpenPrice { get; set; }
        public DateTimeOffset DateTimeOpened { get; set; }
        
        public double ClosePrice { get; set; }
        public DateTimeOffset DateTimeClosed { get; set; }
    }

}