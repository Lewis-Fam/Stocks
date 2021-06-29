
//using LewisFam.Stocks.EntityFrameworkCore;
//using LewisFam.Stocks.EntityFrameworkCore.Repository;
//using LewisFam.Common.Util;

//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore.Infrastructure;

//namespace LewisFam.Stocks.EntityFrameworkCoreTests
//{
//    [TestClass()]
//    public class OptionPricesRepositoryTests
//    {

//        private static readonly DbContextOptionsBuilder<DbContext> _contextOptions = new DbContextOptionsBuilder<DbContext>()
//                    .UseSqlServer(@"Data Source=10.169.0.6\sqltdl;Database=homedb16;MultipleActiveResultSets=true;Persist Security Info=True;User ID=sa;Password=1198INgo!");

//        [TestMethod()]
//        public async Task OptionPricesRepositoryFindAsyncTest()
//        {               
//            using var db = new StocksDbContext(_contextOptions.Options);
//            var optionPricesRepository = new OptionPricesRepository(db);                       

//            //var data = db.OptionPrices.Where(s=> s.UnSymbol == "spce" && s.StrikePrice <= 25 && s.StrikePrice >= 20 );
//            var data = await optionPricesRepository.FindAsync(s=> s.UnSymbol == "spce" && s.Direction == Data.Enums.DirectionType.call && s.StrikePrice <= 25 && s.StrikePrice >= 20);            
            
                        
//            Assert.IsTrue(data.Any(), "!Data.Any()");
//            Console.WriteLine(data.Take(2000).Where(w=>w.Direction == Data.Enums.DirectionType.call).ToJson());
//        }

//        [TestMethod()]
//        public async Task vOptions_Test()
//        {
//            using var db = new StocksDbContext(_contextOptions.Options);
//            var optionPricesRepository = new OptionPricesRepository(db);

//            //var data = db.OptionPrices.Where(s => s.UnSymbol == "spce" && s.StrikePrice <= 25 && s.StrikePrice >= 20);
//            var data = optionPricesRepository.Find(s => s.UnSymbol == "spce" && s.StrikePrice <= 25 && s.StrikePrice >= 20);

//            //var data = db.vOptions.Where(w=>w.UnSymbol == "spce" && w.Direction == Data.Enums.DirectionType.call);

//            Console.WriteLine(  data.ToJson(true));

//        }


//        //[TestMethod()]
//        //public async Task OptionPricesRepositoryFindAsyncTest1()
//        //{
//        //    using var db = new StocksDbContext(@"Data Source=10.169.0.6\sqltdl;Database=homedb16;MultipleActiveResultSets=true;Persist Security Info=True;User ID=sa;Password=1198INgo!");
//        //    var optionPricesRepository = new OptionPricesRepository(db);            

//        //    var data = await optionPricesRepository.FindAsync(s => s.UnSymbol == "spce" && s.TickerId == 1003513492);

//        //    Console.WriteLine(await data.Take(2).ToJsonAsync(true));

//        //    Assert.IsNotNull(data, "Data is null!");
//        //}
//    }
//}