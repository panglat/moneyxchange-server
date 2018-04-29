using Microsoft.EntityFrameworkCore;
using MoneyXChangeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyXChangeServer.Infrastructure.Context
{
    public class CurrencyRateContext : DbContext
    {
        public CurrencyRateContext(DbContextOptions options)
            :base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CurrencyRate>().HasKey(currencyRate => new {
                currencyRate.BaseCurrencyId,
                currencyRate.ToCurrencyId
            });

            builder.Entity<CurrencyRate>()
                .HasOne(currencyRate => currencyRate.BaseCurrency)
                .WithMany(currency => currency.Rates)
                .HasForeignKey(currencyRate => currencyRate.BaseCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<CurrencyRate> CurrencyRate { get; set; }
    }
}
