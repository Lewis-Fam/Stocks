namespace LewisFam.Stocks.ThirdParty.Cnbc.Models
{
    public abstract class MarketPrice
    {
        public virtual double? Close { get; set; }

        public virtual double? High { get; set; }

        public virtual double? Last { get; set; }

        public virtual double? Low { get; set; }

        public virtual double? Open { get; set; }

        public virtual long? Volume { get; set; }
    }
}