//using LewisFam.Stocks.Models.Enums;
//using LewisFam.Stocks.Webull;

//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Diagnostics;
//using LewisFam.Stocks.Models;

//namespace LewisFam.Stocks.Data.Entity
//{

//    [Table("vOptionPrices", Schema = "trading")]
//    public partial class vOptionPrices 
//    {
//        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
//        public virtual double SpotPrice { get; set; }

//        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
//        public virtual double Close { get; set; }

//        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
//        public virtual double High { get; set; }

//        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
//        public virtual double Low { get; set; }

//        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
//        public virtual double Open { get; set; }

//        //private int _timeTradingDays()
//        //{
//        //    int rtn;

//        //    var d1 = DateTime.Now;
//        //    var d2 = ExpireDate.Date;

//        //    var diff = d2 - d1;
//        //    //var diff = d1 - d2;

//        //    rtn = diff.Days / 2;
//        //    return rtn;
//        //}

//        private double _tradingBusinessDays()
//        {
//            var calendarDays = (ExpireDate.Date - UpdatedOn.Value).TotalDays;
//            var rtn = (calendarDays) / 365;
//            //var businessDays = (ExpireDate.Date.AddBusinessDays(DateTime.Now).Day - calendarDays.Days));

//            return rtn;
//        }

//        private int _tradingBusinessDays1()
//        {
//            var calendarDays = (ExpireDate.Date -  UpdatedOn.Value).Days;

//            var businessDays = (ExpireDate.Date.AddBusinessDays(calendarDays).Date - DateTime.Now);

//            return businessDays.Days;
//        }

//        [NotMapped]
//        public virtual double BlackScholesPrice => Math.Round(BlackScholes.Compute(this.Direction.ToString(),  this.SpotPrice, this.StrikePrice, _tradingBusinessDays(), 0.05, this.ImpVol), 4);

//        [NotMapped]
//        public virtual long UpdatedOnUnixTimeSeconds
//        {
//            get
//            {
//                Debug.Assert(UpdatedOn != null, nameof(UpdatedOn) + " != null");
//                return UpdatedOn.Value.ToUnixTimeSeconds();
//            }
//        }
//    }


//}