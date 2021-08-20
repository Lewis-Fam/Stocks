using System;
using System.ComponentModel.DataAnnotations;

namespace LewisFam.Stocks.Options
{
    public class ExpireOn
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "yyyy-MM-dd")]
        public virtual DateTimeOffset Date { get; set; }
        public virtual long Days { get; set; }
        public virtual long Weekly { get; set; }
        public override string ToString()
        {
            return $"{Date} ({Days})";
        }
    }
}