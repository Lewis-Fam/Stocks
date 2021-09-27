using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using LewisFam.Stocks.ThirdParty.Webull.Models;
using LewisFam.Utils;

namespace LewisFam.Stocks
{
    public static partial class StocksUtil
    {
        /// <summary>ReadFileAsync</summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task<T> ReadFileAsync<T>(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException(path);
            var file = await FileUtil.ReadAllTextAsync(path);
            return file.DeserializeObject<T>();
        }

        /// <summary>Writes the watchlist as json to file.</summary>
        /// <param name="watchlist">The watchlist.</param>
        /// <param name="path">     The path.</param>
        /// <param name="format">   If true, format.</param>
        public static void SaveToFile(this Watchlist watchlist, string path, bool format = false)
        {
            FileUtil.WriteAllText(path, watchlist.SerializeObjectToJson(format));
        }

        //public static string SaveToJsonFile(this IEnumerable<IWebullOptionQuote> optionQuotes, string path = "optionQuotes.json", bool format = false)
        //{
        //    var _path = Path.Combine($"{DateTime.Now:yyyy-MM-dd}_{path}");
        //    Debug.WriteLine(_path);
        //    FileUtil.WriteAllText(_path, optionQuotes.SerializeObjectToJson(format));
        //    //SaveToJsonFile(optionQuotes, _path, format);
        //    return path;
        //}

        public static void SaveToFile<T>(T t, string path = "_path.json", bool format = false, bool addDate = false)
        {
            path = addDate switch
            {
                false => Path.Combine(path),
                true => Path.Combine($"{DateTime.Now:yyyy-MM-dd}_{path}"),
            };
            Debug.WriteLine($"{nameof(path)}={path}");
            Debug.WriteLine($"Saved file to FilePath={Path.GetFullPath(path)}");
            FileUtil.WriteAllText(path, t.SerializeObjectToJson(format));
        }
    }
}
