using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyXChangeServer.Core.DTO
{
    public class SymbolsDto
    {
        public SymbolsDto()
        {
            symbols = new Dictionary<string, string>();
        }

        public Dictionary<string, string> symbols;
    }
}
