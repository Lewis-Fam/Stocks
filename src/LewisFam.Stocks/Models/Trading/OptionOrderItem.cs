using System;
using System.ComponentModel.DataAnnotations.Schema;
using LewisFam.Stocks.Models.Enums;
using LewisFam.Stocks.ThirdParty.Webull.Models;
using Microsoft.EntityFrameworkCore;

namespace LewisFam.Stocks.Models.Trading
{
    [Owned]
    [Serializable]
    public class OptionOrderItem 
    {
        protected OptionOrderItem()
        {
        }

        public OptionOrderItem(OpenClose openClose, BuySell buySell, int quantity, double price, long? derivedId = null, IWebullOptionQuote quote = null)
        {
            OpenClose = openClose;
            BuySell = buySell;
            Quantity = quantity;
            Price = price;
            DerivedTickerId = derivedId;
            OptionQuote = quote;
        }
        //[Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public OpenClose OpenClose { get; set; }
        public BuySell BuySell { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTimeOffset TransactionDateTime { get; set; } = DateTimeOffset.Now;

        public double? SellPrice;
        public double? BuyPrice;

        public double? OpenPrice => OpenClose == OpenClose.Open ? (int?)Price : null;
        public int? OpenQuantity => OpenClose == OpenClose.Open ? (int?)Quantity : null;

        public double? ClosePrice => OpenClose == OpenClose.Close ? (double?)Price : null;
        public int? ClosedQuantity => OpenClose == OpenClose.Close  ? (int?)Quantity : null;



        public long? DerivedTickerId { get; set; }
        [NotMapped]
        public IWebullOptionQuote OptionQuote { get; set; }
    }
}