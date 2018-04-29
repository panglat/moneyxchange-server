using MoneyXChangeServer.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyXChangeServer.Core.Manager.Abstract
{
    public interface ICurrencyManager
    {
        SymbolsDto GetAllCurrency();
        SymbolRatesDto GetConversionRate(String fromCurrencyCode, string toCountryCodes);
    }
}
