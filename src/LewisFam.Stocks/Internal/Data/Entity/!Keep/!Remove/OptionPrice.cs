//using LewisFam.Stocks.Base;
//using LewisFam.Stocks.Entity;

//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace LewisFam.Stocks.Data.Entity
//{
//    [Table("OptionPrices", Schema = "trading")]
//    public partial class OptionPrice : OptionBase, Stocks.Entity.IOptionPrice
//    {
//        /// <summary>
//        /// Gets or sets the id.
//        /// </summary>
//        [Key]
//        public virtual long Id { get; set; }

//        /// <summary>
//        /// Gets or sets the active level.
//        /// </summary>
//        public virtual long ActiveLevel { get; set; }

//        /// <summary>
//        /// Gets or sets the ask price.
//        /// </summary>
//        public virtual double? AskPrice { get; set; }

//        /// <summary>
//        /// Gets or sets the ask volume.
//        /// </summary>
//        public virtual long? AskVolume { get; set; }

//        /// <summary>
//        /// Gets or sets the batch id.
//        /// </summary>
//        [MaxLength(128)]
//        public virtual Guid BatchId { get; set; }

//        /// <summary>
//        /// Gets or sets the bid price.
//        /// </summary>
//        public virtual double? BidPrice { get; set; }

//        /// <summary>
//        /// Gets or sets the bid volume.
//        /// </summary>
//        public virtual long? BidVolume { get; set; }

//        /// <summary>
//        /// Gets or sets the change.
//        /// </summary>
//        public virtual double Change { get; set; }

//        /// <summary>
//        /// Gets or sets the change ratio.
//        /// </summary>
//        public virtual double ChangeRatio { get; set; }

//        /// <summary>
//        /// Gets or sets the close.
//        /// </summary>
//        public virtual double Close { get; set; }

//        /// <summary>
//        /// Gets or sets the delta.
//        /// </summary>
//        public virtual double Delta { get; set; }        
                
//        ///// <summary>
//        ///// Gets or sets the expire date.
//        ///// </summary>
//        public virtual DateTimeOffset ExpireDate { get; set; }

//        /// <summary>
//        /// Gets or sets the gamma.
//        /// </summary>
//        public virtual double Gamma { get; set; }

//        /// <summary>
//        /// Gets or sets the high.
//        /// </summary>
//        public virtual double High { get; set; }

//        /// <summary>
//        /// Gets or sets the imp vol.
//        /// </summary>
//        public virtual double ImpVol { get; set; }

//        /// <summary>
//        /// Gets or sets the low.
//        /// </summary>
//        public virtual double Low { get; set; }

//        /// <summary>
//        /// Gets or sets the open.
//        /// </summary>
//        public virtual double Open { get; set; }

//        //public virtual double OpenIntChange { get; set; }
//        /// <summary>
//        /// Gets or sets the open int change.
//        /// </summary>
//        public virtual long OpenIntChange { get; set; }

//        //public virtual double OpenInterest { get; set; }
//        /// <summary>
//        /// Gets or sets the open interest.
//        /// </summary>
//        public virtual long OpenInterest { get; set; }

//        /// <summary>
//        /// Gets or sets the pre-close.
//        /// </summary>
//        public virtual double PreClose { get; set; }

//        /// <summary>
//        /// Gets or sets the quote multiplier.
//        /// </summary>
//        public virtual double QuoteMultiplier { get; set; }

//        /// <summary>
//        /// Gets or sets the rho.
//        /// </summary>
//        public virtual double Rho { get; set; }
//        //public virtual double? SpotPrice { get; set; }
//        /// <summary>
//        /// Gets or sets the spot price.
//        /// </summary>
//        public virtual double SpotPrice { get; set; }

//        ///// <summary>
//        ///// Gets or sets the strike price.
//        ///// </summary>
//        //public new virtual double StrikePrice { get; set; }

//        /// <summary>
//        /// Gets or sets the theta.
//        /// </summary>
//        public virtual double Theta { get; set; }

//        //public virtual double TickerId { get; set; }
//        /// <summary>
//        /// Gets or sets the ticker id.
//        /// </summary>
//        public virtual long TickerId { get; set; }                                   

//        /// <summary>
//        /// Gets or sets the symbol.
//        /// </summary>
//        [MaxLength(20)]
//        public virtual string UnSymbol { get; set; }

//        /// <summary>
//        /// Gets or sets the updated on.
//        /// </summary>        
//        public virtual DateTimeOffset UpdatedOn { get; set; }
//        //public virtual string UpdatedOn { get; set; }

//        /// <summary>
//        /// Gets or sets the vega.
//        /// </summary>
//        public virtual double Vega { get; set; }

//        //public virtual double Volume { get; set; }
//        /// <summary>
//        /// Gets or sets the volume.
//        /// </summary>
//        public virtual long Volume { get; set; }

//        /// <summary>
//        /// Gets or sets the weekly.
//        /// </summary>
//        public virtual double Weekly { get; set; }

//        [NotMapped]
//        public override string Symbol {get; set;}
//    }
//}