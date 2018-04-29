using MoneyXChangeServer.Infrastructure.Context;
using MoneyXChangeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyXChangeServer.Infrastructure.DbInitializer
{
    public static class DbInitializer
    {
        public static void Initialize(CurrencyRateContext context)
        {
            context.Database.EnsureCreated();

            if (context.Currency.Any())
            {
                return; // DB has been seeded
            }

            var currencies = new Currency[]
            {
                new Currency{ Code = "ARS", Name = "Argentine peso"},
                new Currency{ Code = "EUR", Name = "Euro"},
                new Currency{ Code = "USD", Name = "United States dollar"}
            };

            foreach (Currency currency in currencies)
            {
                context.Currency.Add(currency);
            }

            context.SaveChanges();

            var currencyRates = new CurrencyRate[]
            {
                new CurrencyRate{ BaseCurrency = currencies[0], ToCurrency = currencies[1], ExchangeRate = 0.04F},
                new CurrencyRate{ BaseCurrency = currencies[0], ToCurrency = currencies[2], ExchangeRate = 0.049F},

                new CurrencyRate{ BaseCurrency = currencies[1], ToCurrency = currencies[0], ExchangeRate = 24.90F},
                new CurrencyRate{ BaseCurrency = currencies[1], ToCurrency = currencies[2], ExchangeRate = 1.21F},

                new CurrencyRate{ BaseCurrency = currencies[2], ToCurrency = currencies[0], ExchangeRate = 20.50F},
                new CurrencyRate{ BaseCurrency = currencies[2], ToCurrency = currencies[1], ExchangeRate = 0.82F},
            };

            foreach (CurrencyRate currencyRate in currencyRates)
            {
                context.CurrencyRate.Add(currencyRate);
            }

            context.SaveChanges();
        }
    }
}
