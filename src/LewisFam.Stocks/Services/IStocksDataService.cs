using System.Collections.Generic;
using System.Threading.Tasks;

namespace LewisFam.Stocks.Services
{
    public interface IStocksDataService
    {
        Task<object> RawQuote(string symbol, string token = null);
    }

    public interface INewDataService<T> 
    {
        T Get();
        IEnumerable<T> GetEnumerable();
    }
}