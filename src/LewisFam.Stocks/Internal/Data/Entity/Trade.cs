using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;


//using Action = LewisFam.Stocks.Data.Enums.Action;

namespace LewisFam.Stocks.Data.Entity
{
    public interface ITrade : IStock
    {
        Vendor Broker { get; set; }
        double Commission { get; set; }
        string Date { get; set; }
        BuySell Slide { get; set; }
        Guid Id { get; set; }
        Market Market { get; set; }
        Portfolio Portfolio { get; set; }
        double Price { get; set; }
        double Size { get; set; }
        string Symbol { get; set; }
        long TickerId { get; set; }
        TimeSpan Time { get; set; }
    }

    [Table("Trades", Schema = "trading")]
    public class Trade : ITrade
    {
        [Key]
        public virtual Guid Id { get; set; } = Guid.NewGuid();

        public virtual Portfolio Portfolio { get; set; }

        public virtual DirectionType Direction { get; set; }

        public virtual Vendor Broker { get; set; }
        public virtual Market Market { get; set; }

        public virtual BuySell Slide {get; set;}

        [MaxLength(20)]
        public virtual string Symbol { get; set; }

        public virtual long TickerId { get; set; }

        public virtual DateTimeOffset TradeDateTime { get; set; }

        public virtual string Date { get; set; }
        public virtual TimeSpan Time { get; set; }
        public virtual double Price { get; set; }
        public virtual double Size { get; set; }
        public virtual double Commission { get; set; }


    }
}
