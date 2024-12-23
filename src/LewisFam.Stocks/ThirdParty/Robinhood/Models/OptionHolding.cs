﻿using System;
using LewisFam.Stocks.Internal;
using LewisFam.Stocks.Models.Enums;

namespace LewisFam.Stocks.ThirdParty.Robinhood.Models
{
    public class OptionHolding : BaseOption, IOptionHolding
    {
        public OptionHolding(string symbol, CallPut slide, BuySell buySell, int qty, DateTime expireDate, double lastPrice, double strikePrice0, double strikePrice1 = -1)
        {
            Symbol = symbol;
            Slide = slide;
            BuySell = buySell;
            Qty = qty;
            ExpireDate = expireDate;
            StrikePrice = strikePrice0;
            StrikePrice1 = strikePrice1;
            LastPrice = lastPrice;
            //TodayReturnPerc = todayReturnPerc;
        }

        public string Symbol { get; set; }

        public double StrikePrice { get; set; }

        public DateTime ExpireDate { get; set; }

        public CallPut Slide { get; set; }

        public virtual BuySell BuySell { get; }

        public virtual int Qty { get; }

        public virtual double StrikePrice1 { get; }

        public virtual double LastPrice { get; }

        public virtual double TodayReturnPerc { get; }

        protected Vendor? Vendor => LewisFam.Stocks.Models.Enums.Vendor.Robinhood;

        //public override Greeks Greeks { get; set; }
    }
}