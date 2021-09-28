using System;
using System.ComponentModel.DataAnnotations.Schema;
using LewisFam.Models;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;
using LewisFam.Stocks.Options.Models;

namespace LewisFam.Stocks.Internal.Models
{
    /// <summary>
    /// The base stock option.
    /// </summary>
    public abstract class BaseOption : BindableObject, IOption
    {
        protected BaseOption()
        {
        }

        public virtual double StrikePrice { get;  set; }
        public virtual DateTime ExpireDate { get;  set; }
        public virtual CallPut Direction { get;  set; }
        [NotMapped]
        public virtual Stock Stock { get;  protected set; }

        public double Multiplier => 100.0;

        public virtual double? Price { get; set; }

        ///<inheritdoc/>
        public override string ToString()
        {
            return $"{Direction}|{ExpireDate:yyyy/MM/dd}|{StrikePrice}|{Symbol}|{TickerId}";
        }

        public virtual string Symbol { get; set; }
        public virtual long TickerId { get; set;  }
    }
}
