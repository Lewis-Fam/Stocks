using System;
using System.ComponentModel.DataAnnotations.Schema;
using LewisFam.Models;
using LewisFam.Stocks.Models;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.Internal.Models
{
    /// <summary>
    /// The base stock option.
    /// </summary>
    public abstract class BaseOption : BindableObject, IStock
    {
        protected BaseOption()
        {
        }

        public virtual double? StrikePrice { get;  set; }
        public virtual DateTime? ExpireDate { get;  set; }
        public virtual CallPut? Direction { get;  set; }

        [NotMapped]
        public virtual Stock Stock { get;  set; }

        public double Multiplier => 100.0;

        ///<inheritdoc/>
        public override string ToString()
        {
            return $"{Symbol}|{TickerId}|{Direction}|{ExpireDate:yyyy/MM/dd}|{StrikePrice}";
        }

        public virtual string Symbol { get; set; }
        public virtual long TickerId { get; set;  }
    }
}
