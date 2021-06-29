using LewisFam.Stocks.Data.Entity;
using LewisFam.Stocks.EntityFrameworkCore;
//using LewisFam.Stocks.EntityFrameworkCore.Repository;
using LewisFam.Stocks.Webull;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LewisFam.Stocks.Data.Enums;
using LewisFam.Stocks.Entity;
using LewisFam.Utils;


namespace LewisFam.Stocks.EntityFrameworkCoreTests
{
    [TestClass()]
    public class StocksDbContextTests
    {
        //\\daddy\e$\data\stocks\options
        // > 11-05-2020

        private static readonly DbContextOptionsBuilder<StocksDbContext> _contextOptions = new DbContextOptionsBuilder<StocksDbContext>()
            .UseSqlServer(@"Data Source=wdb2.my-hosting-panel.com;Database=alltdl_lewisfam1;MultipleActiveResultSets=true;Persist Security Info=True;User ID=alltdl_daddy;Password=SHB3ExoQ3O3NyyH8sx!#");//@"Data Source=10.169.0.6\sqltdl;Database=homedb16;MultipleActiveResultSets=true;Persist Security Info=True;User ID=sa;Password=1198INgo!");

        [TestMethod]
        public async Task AddOptionsToDatabase()
        {
            using var db = new StocksDbContext(_contextOptions.Options);
            //var or = new OptionPricesRepository(db);

            var path = @"E:\_apps\LewisFam.Cli\logs";
            var file1 = @"*_option_prices.jsons";
            var file2 = @"_option_prices.jsons.dat";

            var finalPath = @"E:\_apps\LewisFam.Cli\logs\merged";

            var files = Directory.EnumerateFiles(path, file1);

            foreach (var f in files)
            {
                //var data = JsonUtil.FileUtil.ReadAllJsons<OptionEntity>(f).ToList();

                //await db.BulkInsertAsync(data); //1.2 min

                //var fn = Path.GetFileName(f);
                //var fp = Path.Combine(finalPath, fn);
                //fp = fp.Replace(".jsons", ".jsons.dat");
                //await File.AppendAllTextAsync(fp, await data.ToJsonAsync());
                //File.Delete(f);
            }

            System.Console.WriteLine("Uncomment to run. Use caution.");
            Assert.IsTrue(true, "Uncomment to run. Use caution.");
        }

        [TestMethod]
        public async Task AddOptionsToDatabase_KeepOriginals()
        {
            using var db = new StocksDbContext(_contextOptions.Options);
            //var or = new OptionPricesRepository(db);

            var path = @"\\daddy\e$\data\stocks\options";
            var file1 = @"*_option_prices.jsons";

            //var file2 = @"_option_prices.jsons.dat";

            //var finalPath = @"E:\_apps\LewisFam.Cli\logs\merged";

            var files = Directory.EnumerateFiles(path, file1);

            foreach (var f in files)
            {
                //var data = JsonUtil.FileUtil.ReadAllJsons<OptionEntity>(f).ToList();

                //await db.BulkInsertAsync(data); //1.2 min

                ////var fn = Path.GetFileName(f);
                ////var fp = Path.Combine(finalPath, fn);
                ////fp = fp.Replace(".jsons", ".jsons.dat");
                ////await File.AppendAllTextAsync(fp, await data.ToJsonAsync());
                ////File.Delete(f);
            }

            System.Console.WriteLine("Uncomment to run. Use caution.");
            Assert.IsTrue(true, "Uncomment to run. Use caution.");
        }

        [TestMethod]
        public void OptionWatchListItemsRepositoryTest_Add()
        {
            //var x = JsonUtil.FileUtil.ReadAllJsons<OptionWatchListItems>(@"E:\Dev\zMe\git_LewisFam.Desktop\src\LewisFam.Desktop\bin\Debug\netcoreapp3.1\option-watchlist.jsons");
            //var db = new StocksDbContext(_contextOptions.Options);

            ////var repository = new OptionWatchListItemsRepository(db);

            //foreach (var item in x)
            //{
            //    //repository.Add(item);
            //}

            //System.Console.WriteLine("Uncomment to run. Use caution.");
            //Assert.IsTrue(true, "Uncomment to run. Use caution.");
        }

        [TestMethod()]
        public void TickersRepositoryTest_AddMultipleTickers()
        {
            var t = new StocksDbContext(_contextOptions.Options);
            //var repo = new TickersRepository(t);
            var json = JsonUtil.FileUtil.ReadAllText(@"E:\_apps\stocks\data\watchlists\c72f1952-9df0-4fee-adb8-248e8533839c.json");
            var watchlist = JsonUtil.DeserializeObject<Watchlist>(json);

            var stocks = watchlist.Stocks;

            foreach (var stock in stocks)
            {
                //repo.Add(new Ticker { Symbol = stock.Symbol, TickerId = stock.TickerId });
            }
                        
            Assert.IsTrue(true, "Uncomment to run. Use caution.");
            Console.WriteLine("Uncomment to run. Use caution.");
        }

        [TestMethod()]
        public async Task GetChartDataTest()
        {
        }

        [TestMethod()]
        public async Task GetViewTestAsync()
        {
            var t = new StocksDbContext(_contextOptions.Options);
            var op = t.vOptionPrices.OrderBy(i => i.UpdatedOn);
            var oop = op.Where(w => w.UnSymbol == "SPCE" && w.Slide == "put").Select(s => new { s.Slide, s.AskPrice, s.BidPrice, s.SpotPrice, s.UpdatedOn, s.ImpVol, s.StrikePrice, s.ExpireDate});

            Console.WriteLine(oop.Take(10).ToJson(true));
            
            Console.WriteLine();

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void vOptionsTest()
        {               
            var t = new StocksDbContext(_contextOptions.Options);
            var op = t.vOptions.Where(w=>w.UnSymbol == "SPCE" && w.Slide == Data.Enums.DirectionType.call.ToString() && w.StrikePrice == 20.00);

            Console.WriteLine(op.ToJson(true));
            
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void v_OptionPricesDailyTest()
        {               
            var t = new StocksDbContext(_contextOptions.Options);
            var op = t.v_OptionPricesDaily.Where(w=> w.TickerId == 1018000471);

            Console.WriteLine(op.ToJson(true));
            
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void TransactionsTest()
        {               
            var t = new StocksDbContext(_contextOptions.Options);
            var op = t.Transactions.ToList();

            Console.WriteLine(op.ToJson(true));
            
            Assert.IsTrue(true);
        }
    }
}