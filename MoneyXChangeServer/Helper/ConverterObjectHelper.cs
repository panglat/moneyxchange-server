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
            if(currency != null)
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
    }
}
