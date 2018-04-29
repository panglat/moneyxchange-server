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

        public CurrencyManager(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public IEnumerable<CurrencyDto> GetAllCurrency()
        {
            return _currencyRepository.FindAll()
                .OrderBy(currency => currency.Name)
                .Select(currency => ConverterObjectHelper.CurrencyToCurrencyDto(currency));
        }
    }
}
