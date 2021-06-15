using System;
using System.Collections.Generic;
using System.Linq;

namespace LewisFam.Stocks.ThirdParty.Cnbc
{
    /// <summary>
    /// The cnbc data service.
    /// </summary>
    public sealed partial class CnbcDataService
    {
        /// <summary>
        /// The cnbc data service helper class.
        /// </summary>
        private static class Helper
        {
            internal const string BaseUriCharts = "https://ts-api.cnbc.com/harmony/app/bars";

            internal const string ChartQuery = "adjusted/EST5EDT.json";

            internal const string DateFormat = "yyyyMMdd000000";

            internal const string TokenBarData = "barData.priceBars";

            internal const string TokenQuickQuote = "QuickQuoteResult.QuickQuote";

            internal static Uri BuildUri(string symbol) => new Uri($"{BaseUriQuote}{QuoteQuery}{symbol}");

            internal static Uri BuildUri(IEnumerable<string> symbols) => new Uri($"{BaseUriQuote}{QuoteQuery}{parseSymbols(symbols)}".Replace("||", "|").Trim('|'));

            internal static IEnumerable<string> SplitStringToStringSymbols(string split, char[] acceptableSplitChars = null)
            {
                acceptableSplitChars ??= new[]
                {
                    ',', '&', ' '
                };

                return split?.Split(acceptableSplitChars);
            }

            

            private const string BaseUriQuote = "https://quote.cnbc.com/quote-html-webservice/quote.htm";

            private const string QuoteQuery = "?exthrs=1&noform=1&fund=1&output=json&events=1&requestMethod=quick&symbols=";

            private static string parseSymbols(IEnumerable<string> symbols) => symbols.Aggregate(string.Empty, (current, symbol) => $"{current}{symbol.Trim('|')}|");
        }
    }
}