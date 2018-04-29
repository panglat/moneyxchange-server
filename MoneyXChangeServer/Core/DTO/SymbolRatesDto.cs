using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyXChangeServer.Core.DTO
{
    public class SymbolRatesDto
    {
        public string @base;
        public string date;
        public Dictionary<string, float> rates;
    }
}
