//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Diagnostics;
//using System.Text;
//using LewisFam.Stocks.Models.Enums;
//using LewisFam.Stocks.Models;

//namespace LewisFam.Stocks.Data.Entity
//{
//     public partial class vOptionPrices
//    {
//        //[Key]
//        public virtual long Id { get; set; }

//        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
//        public virtual double StrikePrice { get; set; }

//        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
//        public virtual DateTimeOffset ExpireDate { get; set; }
//        public virtual DirectionType Direction { get; set; }
//        public virtual long ActiveLevel { get; set; }

//        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
//        public virtual double? AskPrice { get; set; }
//        public virtual long? AskVolume { get; set; }
//        public virtual Guid BatchId { get; set; }

//        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
//        public virtual double? BidPrice { get; set; }
//        public virtual long? BidVolume { get; set; }
//        public virtual double Change { get; set; }
//        public virtual double ChangeRatio { get; set; }

        
//        public virtual double Delta { get; set; }
//        public virtual double Gamma { get; set; }

      
//        public virtual double ImpVol { get; set; }

       

//        public virtual long OpenIntChange { get; set; }
//        public virtual long OpenInterest { get; set; }

//        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
//        public virtual double PreClose { get; set; }
//        public virtual double QuoteMultiplier { get; set; }
//        public virtual double Rho { get; set; }

        
//        public virtual double Theta { get; set; }
//        public virtual long TickerId { get; set; }
//        [StringLength(20)]
//        public virtual string UnSymbol { get; set; }
//        public virtual DateTimeOffset? UpdatedOn { get; set; }
//        public virtual double Vega { get; set; }
//        public virtual long Volume { get; set; }
//        public virtual double Weekly { get; set; }

//        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
//        [Column(TypeName = "date")]
//        public virtual DateTime? ExpireDateShort { get; set; }
//        [Column(TypeName = "date")]
//        public virtual DateTime? UpdatedOnShort { get; set; }
        
//        [StringLength(4)]
//        public virtual string Slide { get; set; }
//    }
//}
