using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyXChangeServer.Core.DTO
{
    public class CurrencyRatesDto
    {
        public string fromCurrencyCode;
        public string date;
        public Dictionary<string, decimal> rates;
    }
}
