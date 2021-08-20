using LewisFam.Stocks.Data.Models;
using LewisFam.Stocks.Entity;

using Microsoft.EntityFrameworkCore;

namespace LewisFam.Stocks.EntityFrameworkCore
{
    public partial class StocksDbContext : DbContext
    {
        public StocksDbContext(DbContextOptions<StocksDbContext> options) : base(options)
        {
        }

        public StocksDbContext(string connectionString)
        {
        }

        public virtual DbSet<Notes> Notes { get; set; }

        public virtual DbSet<OptionPrices> OptionPrices { get; set; }

        public virtual DbSet<OptionPricesDaily> OptionPricesDaily { get; set; }

        public virtual DbSet<Options> Options { get; set; }

        public virtual DbSet<OptionWatchListItems> OptionWatchListItems { get; set; }

        public virtual DbSet<Tickers> Tickers { get; set; }

        public virtual DbSet<Transactions> Transactions { get; set; }

        public virtual DbSet<TransactionsDev> TransactionsDev { get; set; }


        public virtual DbSet<v_OptionPricesDaily> v_OptionPricesDaily { get; set; }

        public virtual DbSet<vOptionPrices> vOptionPrices { get; set; }

        public virtual DbSet<vOptions> vOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "alltdl_daddy");

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<OptionPricesDaily>(entity =>
            {
                entity.Property(e => e.Slide).IsUnicode(false);
            });

            modelBuilder.Entity<OptionPrices>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.BatchId, e.UpdatedOn, e.TickerId, e.UnSymbol })
                    .HasName("x_OptionPrices_a");

                entity.HasIndex(e => new { e.StrikePrice, e.ExpireDate, e.Direction, e.UnSymbol, e.TickerId })
                    .HasName("x_Options");

                entity.HasIndex(e => new { e.StrikePrice, e.ExpireDate, e.Direction, e.UnSymbol, e.TickerId, e.UpdatedOn })
                    .HasName("x_OptionPrices");
            });

            modelBuilder.Entity<Options>(entity =>
            {
                entity.HasIndex(e => new { e.FirstSeenOn, e.UnSymbol, e.TickerId, e.StrikePrice, e.ExpireDate, e.Direction })
                    .HasName("xu_Option")
                    .IsUnique();
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.TimeStamp).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.OptionId)
                    .HasConstraintName("FK_OptionId");
            });

            modelBuilder.Entity<TransactionsDev>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.TimeStamp).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.TransactionsDev)
                    .HasForeignKey(d => d.OptionId)
                    .HasConstraintName("FK_OptionIdDev");
            });

            modelBuilder.Entity<vOptionPrices>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vOptionPrices", "trading");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Slide).IsUnicode(false);
            });

           

            modelBuilder.Entity<vOptionPrices_ChartDatas>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vOptionPrices_ChartDatas", "trading");
            });

            modelBuilder.Entity<vOptions>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vOptions", "trading");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Slide).IsUnicode(false);
            });


            modelBuilder.Entity<vOptions_FirstSeen>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vOptions_FirstSeen", "trading");
            });

       

            modelBuilder.Entity<v_OptionPricesDaily>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_OptionPricesDaily", "trading");

                entity.Property(e => e.Slide).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}