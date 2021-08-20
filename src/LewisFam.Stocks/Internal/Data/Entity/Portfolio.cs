using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//using Action = LewisFam.Stocks.Data.Enums.Action;

namespace LewisFam.Stocks.Data.Entity
{
    [Table("Portfolios", Schema = "trading")]
    public class Portfolio
    {
        //[Key]
        public virtual Guid Id {get; set;}   
        public virtual string Name {get; set;}        
        public virtual ICollection<Trade> Trades {get; set; }
    }
}
