namespace LewisFam.Stocks.ThirdParty.Cnbc.Models
{
    public partial class EventData
    {
        public virtual string AnnounceTime { get; set; }

        public virtual string DivAmount { get; set; }

        public virtual string DivExDate { get; set; }

        public virtual string DivExDateToday { get; set; }

        public virtual string IsHalted { get; set; }

        public virtual string NextEarningsDate { get; set; }

        public virtual string NextEarningsDateToday { get; set; }

        public virtual string Yrhiind { get; set; }

        public virtual string Yrloind { get; set; }

        public override string ToString()
        {
            return $"{Yrhiind}|{Yrloind}|{NextEarningsDateToday}|{NextEarningsDate}";
        }
    }
}