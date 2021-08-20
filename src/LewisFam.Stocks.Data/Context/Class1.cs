using System;
using Microsoft.EntityFrameworkCore;

namespace LewisFam.Stocks.Data.Context
{
    public class StocksDbContext : DbContext
    {
        public StocksDbContext(DbContextOptions<StocksDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<object> Trades { get; set; }
    }

}
