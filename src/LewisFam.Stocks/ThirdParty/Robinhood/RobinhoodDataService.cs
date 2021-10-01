using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LewisFam.Extensions;
using LewisFam.Stocks.Internal;
using LewisFam.Stocks.Models.Enums;
using LewisFam.Stocks.ThirdParty.Robinhood.Models;
using LewisFam.Stocks.ThirdParty.Services;

namespace LewisFam.Stocks.ThirdParty.Robinhood
{
    /// <summary>
    /// The Robinhood data service.
    /// </summary>
    public sealed class RobinhoodDataService : BaseDataService, IRobinhoodDataService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RobinhoodDataService"/> class.
        /// </summary>
        public RobinhoodDataService()
        {
        }

        public bool HasOptionHoldings => OptionHoldings?.Any() ?? false;

        public bool HasStockHoldings => StockHoldings?.Any() ?? false;

        public List<string> Lines { get; set; }

        public ICollection<OptionHolding> OptionHoldings { get; } = new List<OptionHolding>();

        public ICollection<StockHolding> StockHoldings { get; } = new List<StockHolding>();

        public double SumEquity => StockHoldings?.Sum(s => s.Equity) ?? 0;

        public double SumTotalReturn => StockHoldings?.Sum(s => s?.TotalReturn) ?? 0;

        public IEnumerable<StockHolding> ParseAccountPage(string pageText)
        {
            var lines = pageText.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            if (lines == null)
                return null;

            var first = lines.FindIndex(e => e.StartsWith(_START_)) + 1;
            var last = lines.FindIndex(e => e.StartsWith(_END_)) - 1;

            var selectedLines = lines.Skip(first).Take(last - first);

            var b = selectedLines.Skip(7).Batch(7);

            StockHoldings.Clear();

            foreach (var item in b.ToList())
            {
                if (item == null) break;
                var x = item.ToArray();

                var z = new StockHolding(x[0], x[1], double.Parse(x[2], NumberStyles.Any), double.Parse(x[3], NumberStyles.Currency), double.Parse(x[4], NumberStyles.Currency), double.Parse(x[6], NumberStyles.Currency));
                StockHoldings.Add(z);
            }

            return StockHoldings;
        }

        /// <summary>Parses the option holdings.</summary>
        /// <param name="input">The input.</param>
        /// <returns>An ICollection.</returns>
        /// <remarks>ToDo: Convert to delegete</remarks>
        [Obsolete("Needs testing. check var z")]
        public ICollection<OptionHolding> ParseOptionHoldings(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            if (!lines.Any())
                return null;

            var b = lines.Batch(4)?.ToList();

            OptionHoldings.Clear();

            foreach (var item in b)
            {
                var x = item.ToArray();
                string[] line0 = x?[0]?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string[] line1 = x?[1]?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    string symbol = line0?[0];

                    double lastPrice = double.Parse(x?[2], NumberStyles.Any);
                    double todayReturnPerc = double.Parse(x?[3].Trim('%'), NumberStyles.Any);

                    double strikePrice = double.Parse(line0?[1], NumberStyles.AllowCurrencySymbol | NumberStyles.Any);
                    double strikePrice1 = -1;

                    CallPut direction = CallPut.Call;
                    BuySell optionType = BuySell.Buy;

                    DateTime expireDate = DateTime.Parse(line1?[0]);
                    int qty = int.Parse(line1?[3]);

                    if (line0.Length == 3)
                    {
                        direction = line0[2].Trim('s').ToEnum<CallPut>();
                        optionType = line1[4].Trim('s').ToEnum<BuySell>();
                    }

                    if (line0.Length >= 4)
                    {
                        strikePrice1 = double.Parse(line0?[3], NumberStyles.AllowCurrencySymbol | NumberStyles.Any);
                        direction = line0[4].Trim('s').ToEnum<CallPut>();
                    }

                    if (line1.Length == 6)
                    {
                        optionType = $"{line1?[4]}{line1?[5]}".Trim('s').ToEnum<BuySell>();
                    }

                    var z = new OptionHolding(symbol, direction, optionType, qty, expireDate, lastPrice, strikePrice);

                    OptionHoldings.Add(z);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }

            return OptionHoldings;
        }

        /// <summary>Parses the stock holdings.</summary>
        /// <param name="input">The input.</param>
        /// <returns>An ICollection.</returns>
        public ICollection<StockHolding> ParseStockHoldings(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            if (lines == null || !lines.Any())
                return null;

            const string _START_ = "Stocks";
            const string _END_ = "Margin Investing";

            var first = lines.FindIndex(e => e.Equals(_START_)) + 1;
            var last = lines.FindIndex(e => e.StartsWith(_END_)) - 1;

            var selectedLines = lines.Skip(first).Take(last - first);

            var b = selectedLines.Skip(7).Batch(7)?.ToList();

            StockHoldings.Clear();

            foreach (var item in b)
            {
                var x = item.ToArray();
                try
                {
                    StockHoldings.Add(new StockHolding(x[0], x[1], double.Parse(x[2], NumberStyles.Any), double.Parse(x[3], NumberStyles.Currency), double.Parse(x[4], NumberStyles.Currency), double.Parse(x[6], NumberStyles.Currency)));
                }
                catch (FormatException)
                {
                    break;
                }
            }

            return StockHoldings;
        }

        public IEnumerable<OptionHolding> ParseSymbolPage(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            var first = lines.FindIndex(e => e.Equals(_START_SYMBOLPAGE_OPTIONS_)) + 1;
            var selectedLines = lines.Skip(first);

            var b = selectedLines.Skip(8).Batch(3);

            OptionHoldings.Clear();

            foreach (var item in b.ToList())
            {
                if (item == null) break;
                var x = item.ToArray();
                var z = x[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var symbol = z[0];
                var strikePrice = double.Parse(z[1], NumberStyles.Any);
                var directionType = Enum.Parse<CallPut>(z[2], true);
                var lastPrice = double.Parse(x[2], NumberStyles.Any);
                var y = x[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var expireDate = DateTime.Parse(y[0]);
                var qty = int.Parse(y[3]);
                var holdingType = Enum.Parse<BuySell>(y[4]);

                var oh = new OptionHolding(symbol, directionType, holdingType, qty, expireDate, lastPrice, strikePrice);
                OptionHoldings.Add(oh);
            }

            return OptionHoldings;
        }

        private const string _END_ = "Margin Health";

        private const string _END_SYMBOLPAGE_OPTIONS_ = "";

        private const string _START_ = "Stocks";

        private const string _START_SYMBOLPAGE_OPTIONS_ = "Options";

        private const int _SYMBOLPAGE_SKIP_ = 8;
    }
}