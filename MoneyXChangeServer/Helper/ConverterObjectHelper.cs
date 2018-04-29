using MoneyXChangeServer.Core.DTO;
using MoneyXChangeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyXChangeServer.Helper
{
    public static class ConverterObjectHelper
    {
        public static CurrencyDto CurrencyToCurrencyDto(Currency currency)
        {
            if (currency != null)
            {
                return new CurrencyDto()
                {
                    Code = currency.Code,
                    Name = currency.Name
                };
            } else
            {
                return null;
            }
        }

        public static SymbolsDto CurrenciesToSymbolsDto(Currency[] currencies)
        {
            return new SymbolsDto
            {
                symbols = currencies.ToDictionary(currency => currency.Code, currency => currency.Name)
            };
        }

        public static SymbolRatesDto CurrencyRatesToSymbolRatesDto(CurrencyRate[] currencyRates)
        {
            if (currencyRates != null && currencyRates.Length > 0) { 

                return new SymbolRatesDto
                {
                    @base = currencyRates[0].BaseCurrency.Code,
                    date = $"{DateTime.Now:yyyy/MM/dd}",
                    rates = currencyRates.ToDictionary(currencyRate => currencyRate.ToCurrency.Code, currencyRate => currencyRate.ExchangeRate)
                };
            } else
            {
                return null;
            }
        }
    }
}
