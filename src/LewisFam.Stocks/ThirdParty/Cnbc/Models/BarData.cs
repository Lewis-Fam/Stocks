using Newtonsoft.Json;

namespace LewisFam.Stocks.ThirdParty.Cnbc.Models
{
    public partial class ResponseDetails
    {
        [JsonProperty("requestTrackingNumber", NullValueHandling = NullValueHandling.Ignore)]
        public long? RequestTrackingNumber { get; set; }

        [JsonProperty("processTime", NullValueHandling = NullValueHandling.Ignore)]
        public string ProcessTime { get; set; }
    }

    public partial class RequestDetails
    {
        [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
        public string Symbol { get; set; }

        [JsonProperty("startTime", NullValueHandling = NullValueHandling.Ignore)]
        public string StartTime { get; set; }

        [JsonProperty("endTime", NullValueHandling = NullValueHandling.Ignore)]
        public string EndTime { get; set; }

        [JsonProperty("adjusted")]
        public object Adjusted { get; set; }

        [JsonProperty("ouputFields")]
        public object OuputFields { get; set; }

        [JsonProperty("source")]
        public object Source { get; set; }

        [JsonProperty("session", NullValueHandling = NullValueHandling.Ignore)]
        public string Session { get; set; }
    }

    public partial class ResponseErrorMessage
    {
        [JsonProperty("responseCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ResponseCode { get; set; }

        [JsonProperty("responseMessage", NullValueHandling = NullValueHandling.Ignore)]
        public string ResponseMessage { get; set; }
    }

    public partial class ChartData
    {
        [JsonProperty("barData", NullValueHandling = NullValueHandling.Ignore)]
        public BarData BarData { get; set; }

        [JsonProperty("requestDetails", NullValueHandling = NullValueHandling.Ignore)]
        public RequestDetails RequestDetails { get; set; }

        [JsonProperty("responseDetails", NullValueHandling = NullValueHandling.Ignore)]
        public ResponseDetails ResponseDetails { get; set; }

        [JsonProperty("responseErrorMessages", NullValueHandling = NullValueHandling.Ignore)]
        public ResponseErrorMessage[] ResponseErrorMessages { get; set; }
    }



    public partial class BarData
    {
        public virtual long? Barcount { get; set; }

        public virtual PriceBar[] PriceBars { get; set; }

        public virtual object Symbol { get; set; }

        public virtual string TimeZone { get; set; }
    }
}