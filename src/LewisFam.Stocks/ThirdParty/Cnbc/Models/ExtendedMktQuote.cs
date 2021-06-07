namespace LewisFam.Stocks.ThirdParty.Cnbc.Models
{
    public partial class ExtendedMktQuote
    {
        public virtual string Change { get; set; }

        public virtual string ChangePct { get; set; }

        public virtual string Exchange { get; set; }

        public virtual string Fullchange { get; set; }

        public virtual string FullchangePct { get; set; }

        public virtual string Last { get; set; }

        public virtual string LastTimeMsec { get; set; }

        public virtual string Source { get; set; }

        public virtual string TimeZone { get; set; }

        public virtual string Type { get; set; }

        public virtual string Volume { get; set; }

        public override string ToString()
        {
            return $"{Last}|{Change}|{Volume}";
        }
    }
}