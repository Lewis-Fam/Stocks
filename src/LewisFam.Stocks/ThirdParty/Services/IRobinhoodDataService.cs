using System.Collections.Generic;
using LewisFam.Interfaces;
using LewisFam.Stocks.ThirdParty.Robinhood.Models;

namespace LewisFam.Stocks.ThirdParty.Services
{
    public interface IRobinhoodDataService : IDataService
    {
        List<string> Lines { get; set; }
        ICollection<StockHolding> StockHoldings { get; }
        double SumEquity { get; }
        double SumTotalReturn { get; }
        ICollection<StockHolding> ParseStockHoldings(string input);

        ICollection<OptionHolding> ParseOptionHoldings(string input);

        IEnumerable<OptionHolding> ParseSymbolPage(string input);
    }

    //public static class MyExtensions
    //{
    //    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items,
    //                                                       int maxItems)
    //    {
    //        return items.Select((item, inx) => new { item, inx })
    //                    .GroupBy(x => x.inx / maxItems)
    //                    .Select(g => g.Select(x => x.item));
    //    }
    //}
}
