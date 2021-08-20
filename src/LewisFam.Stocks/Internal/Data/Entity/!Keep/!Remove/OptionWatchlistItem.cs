//using LewisFam.Stocks.Models.Enums;
//using LewisFam.Stocks.Interfaces;

//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace LewisFam.Stocks.Data.Entity
//{
//    //public class Watchlist
//    //{
//    //    public IEnumerable<IStock> Stocks { get; set; }
//    //}

//    [Table("OptionWatchlistItems", Schema = "trading")]
//    public class OptionWatchlistItem
//    {
//        //[Key]
//        public virtual long Id { get; set; }
//        public virtual string Symbol { get; set; }
//        public virtual DirectionType Direction { get; set; }
//        public virtual double StrikePrice { get; set; }
//        public virtual DateTimeOffset ExpireDate { get; set; }
//        public virtual long TickerId { get; set; }
//    }
//}