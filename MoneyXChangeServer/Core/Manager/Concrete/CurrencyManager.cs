using Microsoft.EntityFrameworkCore;
using MoneyXChangeServer.Core.DTO;
using MoneyXChangeServer.Core.Manager.Abstract;
using MoneyXChangeServer.Helper;
using MoneyXChangeServer.Infrastructure.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyXChangeServer.Core.Manager.Concrete
{
    public class CurrencyManager : ICurrencyManager
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICurrencyRateRepository _currencyRateRepository;

        public CurrencyManager(ICurrencyRepository currencyRepository, ICurrencyRateRepository currencyRateRepository)
        {
            _currencyRepository = currencyRepository ?? throw new ArgumentNullException(nameof(currencyRepository));
            _currencyRateRepository = currencyRateRepository ?? throw new ArgumentNullException(nameof(currencyRateRepository));
        }

        public SymbolsDto GetAllCurrency()
        {
            var currencies = _currencyRepository.FindAll()
                .OrderBy(currency => currency.Name)
                .ToArray();
            return ConverterObjectHelper.CurrenciesToSymbolsDto(currencies);
        }

        public SymbolRatesDto GetConversionRate(String fromCurrencyCode, string toCountryCodes)
        {
            var query = _currencyRateRepository.FindByCondition(currencyRate =>
                fromCurrencyCode.Equals(currencyRate.BaseCurrency.Code)).AsQueryable();
            if(toCountryCodes != null) {
                var toCountryCodesSplitted = toCountryCodes.ToUpper().Split(',');
                if (toCountryCodesSplitted.Length > 0)
                {
                    query = query.Where(currencyRate => toCountryCodesSplitted.Any(toCountryCode => toCountryCode.Equals(currencyRate.ToCurrency.Code)));
                }
            }
            query = query.Include(currencyRate => currencyRate.BaseCurrency).Include(currencyRate => currencyRate.ToCurrency);
            var currencyRates = query.ToArray();

            return ConverterObjectHelper.CurrencyRatesToSymbolRatesDto(currencyRates);
        }
    }
}
