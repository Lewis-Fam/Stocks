using System;
using System.Collections.Generic;
using System.Linq;

using LewisFam.Stocks.ThirdParty.Webull.Models;

namespace LewisFam.Stocks.ThirdParty.Webull
{
    public sealed partial class WebullDataService
    {
        #region Classes

        private static class Helper
        {
            #region Options

            /// <summary>The base uri_ options.</summary>
            private const string BaseUri_Options = "https://quoteapi.webullfintech.com/api/quote/option/";

            //    var filtered = options.Where(w => w.StrikePrice == strikePrice && w.Direction == optionType);
            //    return filtered.ToList();
            //}
            /// <summary>The base uri_ search.</summary>
            private const string BaseUri_Search = "https://infoapi.webullbroker.com/api/search/tickerSearchV5?hasNumber=0&clientOrder=3&queryNumber=30&keys=";

            //public static IList<IOption> FilterToList(IEnumerable<IOption> options, long tickerId = 0, DirectionType optionType = DirectionType.Call, double strikePrice = 0)
            //{
            //    //var id = await FindStockIdAsync(symbol);
            //    //var options = await GetAllOptionsAsync(id.Value);
            //    if (tickerId != 0)
            //        return options.Where(w => w.TickerId == tickerId).ToList();
            /// <summary>The query params_ options.</summary>
            private const string Params_Options = "/list?count=-1&includeWeekly=1&direction=all&queryAll=0";

            /// <summary>Builds the uri.</summary>
            /// <param name="tickerId">The ticker id.</param>
            /// <param name="expDate"> The exp date.</param>
            /// <returns>An Uri.</returns>
            [Obsolete]
            public static Uri BuildUri(long tickerId, DateTimeOffset expDate) => new Uri($"{BaseUri_Options}{tickerId}{Params_Options}&expireDate={expDate:yyyy-MM-dd}");

            /// <summary>Builds the uri.</summary>
            /// <param name="tickerId">The ticker id.</param>
            /// <returns>An Uri.</returns>
            public static Uri BuildUriGetOptions(long tickerId)
            {
                return new Uri($"{BaseUri_Options}{tickerId}{Params_Options}");
            }

            public static Uri BuildUriOptionChartData(long derivedId)
            {
                //https://quotes-gw.webullfintech.com/api/quote/option/chart/query?count=800&derivativeId=1019075592&type=1d
                return new Uri($"https://quotes-gw.webullfintech.com/api/quote/option/chart/query?count=800&derivativeId={derivedId}&type=1d");
            }

            public static Uri BuildUriOptionQuoteDetail(long derivedId, long tickerId)
            {
                //https://quotes-gw.webullfintech.com/api/quote/option/quotes/detail?derivativeIds=1019075592&tickerId=950052430
                return new Uri($"https://quotes-gw.webullfintech.com/api/quote/option/quotes/detail?derivativeIds={derivedId}&tickerId={tickerId}");
            }

            #endregion Options

            #region Stocks

            //https://quotes-gw.webullfintech.com/api/quote/charts/query?tickerIds=913256135&period=d1
            private const string BaseUri_StockChart = "https://quotes-gw.webullfintech.com/api/quote/charts/query?";

            private const string BaseUri_Stocks = "https://quotes-gw.webullfintech.com/api/bgw/quote/realtime?";

            private const string Params_StockChart = "period=d1&tickerIds=";

            private const string Params_Stocks_Realtime = "includeSecu=1&delay=0&more=1&ids=";

            public static Uri BuildUriRealTimeStockQuotes(IEnumerable<long> tickerIds) => new Uri($"{BaseUri_Stocks}{Params_Stocks_Realtime}{parseIds_Trim(tickerIds)}");

            public static Uri BuildUriStockChartData(long tickerId) => new Uri($"{BaseUri_StockChart}{Params_StockChart}{tickerId}");

            public static Uri BuildUriStockChartData(long tickerIds, ChartDataType type, int count = 800) => new Uri($"{BaseUri_StockChart}{nameof(tickerIds)}={tickerIds}&{nameof(type)}={type}&{nameof(count)}={count}");

            //https://quotes-gw.webullfintech.com/api/bgw/quote/realtime?ids=913354090%2C913243250%2C913243251%2C913256135%2C913303964&includeSecu=1&delay=0&more=1

            private static string parseIds(IEnumerable<long> tickerIds) => tickerIds.Aggregate(string.Empty, (current, symbol) => $"{current}{symbol.ToString()}%2C");

            private static string parseIds_Trim(IEnumerable<long> tickerIds)
            {
                var myString = parseIds(tickerIds);
                return myString.Substring(0, myString.Length - 3);
            }

            #endregion Stocks

            #region Fields

            private const string Base_Securities = "https://securitiesapi.webullfintech.com/api/securities/financial";

            #endregion Fields

            #region Methods

            public static Uri BuilUriOptionQuote(long derivedId)
            {
                //https://quotes-gw.webullfintech.com/api/quote/option/quotes/queryBatch?derivativeIds=1019075592
                return new Uri($"https://quotes-gw.webullfintech.com/api/quote/option/quotes/queryBatch?derivativeIds={derivedId}");
            }

            public static Uri BuildUriOptionStratList()
            {
               //https://quotes-gw.webullfintech.com/api/quote/option/strategy/list
               return new Uri($"https://quotes-gw.webullfintech.com/api/quote/option/strategy/list");
            }

            public static Uri BuildUriFinancialSimple(long tickerId)
            {
                //https://securitiesapi.webullfintech.com/api/securities/financial/simple/950052430?reportType=2&statementType=2
                return new Uri($"{Base_Securities}/simple/{tickerId}?reportType=2&statementType=2");
            }

            public static Uri BuildUriFinancialSimpleV2(long tickerId)
            {
                //https://securitiesapi.webullfintech.com/api/securities/financial/v2/detail/950052430?statementType=2
                return new Uri($"{Base_Securities}/v2/detail/{tickerId}?statementType=2");
            }

            /// <summary>Builds the uri.</summary>
            /// <param name="symbol">The symbol.</param>
            /// <returns>An Uri.</returns>
            public static Uri BuildUriSearchSymbol(string symbol)
            {
                return new Uri($"{BaseUri_Search}{symbol}");
            }

            #endregion Methods
        }

        #endregion Classes
    }
}