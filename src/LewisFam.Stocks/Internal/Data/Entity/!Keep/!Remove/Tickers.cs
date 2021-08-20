//using LewisFam.Stocks.Base;
//using LewisFam.Stocks.Webull;

//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace LewisFam.Stocks.Data.Entity
//{
//    [Table("Tickers", Schema = "trading")]
//    public partial class Ticker : StockBase
//    {
//        public Ticker()
//        {
//        }

//        public Ticker(string symbol, long tickerId)
//        {
//            Symbol = symbol;
//            TickerId = tickerId;
//        }

//        //[Key]
//        public virtual long Id { get; set; }

//        [StringLength(255)]
//        public virtual string Name { get; set; }

//        [Required, StringLength(10)]
//        public override string Symbol { get; set; }

//        public virtual long TickerId { get; set; }        
//    }
//}