using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LewisFam.Stocks.Internal.Models;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Data.Models
{
    [Table("vOptions", Schema = "trading")]
    public partial class vOptions : BaseOption
    { 
        public virtual long Id { get; set; }

        [Display(Name = "Symbol"), StringLength(20)]
        public virtual string UnSymbol { get; set; }
        public virtual long TickerId { get; set; }
        public override double? StrikePrice { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ExpireDate { get; set; }
        public new DirectionType Direction { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime? FirstSeenOn { get; set; }
        public virtual bool Weekly { get; set; }
        [StringLength(4)]
        public new string Slide { get; set; }
        public virtual int CalendarDaysRemaining { get; set; }
        public virtual int WeeksRemaining { get; set; }

        public override string ToString()
        {
            return $"{UnSymbol}|{Direction}|{ExpireDate:yyyy-MM-dd}|{StrikePrice}";
        }
    }
}