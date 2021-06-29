using System;

namespace LewisFam.Stocks.Entity
{
    public class StockQuoteSR : StockQuote
    {
        public StockQuoteSR(string symbol) : base(symbol)
        {
        }

        public StockQuoteSR(string symbol, double dayHigh, double dayLow, double dayOpen, double price) : base(symbol)
        {
            DayHigh = dayHigh;
            DayLow = dayLow;
            DayOpen = dayOpen;            
            Price = price;
        }

        public virtual double DayHigh { get; private set; }

        public virtual double DayLow { get; private set; }

        public virtual double DayOpen { get; private set; }

        public virtual double LastChange { get; private set; }

        public override double Change { get { return (double) Math.Round(Price - DayOpen, 4); } }

        public virtual double PercentChange
        {
            get
            {
                return (double)Math.Round(Change / Price, 4);
            }
        }

        public override double Price
        {
            get
            {
                return _price;
            }

            set
            {
                if (_price == value)
                {
                    return;
                }

                LastChange = value - _price;                
                _price = value;

                if (DayOpen == 0)
                {
                    DayOpen = _price;
                }
                if (_price < DayLow || DayLow == 0)
                {
                    DayLow = _price;
                }
                if (_price > DayHigh)
                {
                    DayHigh = _price;
                }                
            }
        }

        private double _price;

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void notifyPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}