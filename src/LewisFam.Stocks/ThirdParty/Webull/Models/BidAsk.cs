namespace LewisFam.Stocks.ThirdParty.Webull.Models
{
    public class BidAsk
    {
        public virtual double? Price { get; set; }

        public virtual long? Volume { get; set; }

        public override string ToString()
        {
            return Price != null ? base.ToString() : $"{Price}";
        }
    }
}