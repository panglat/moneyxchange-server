using MoneyXChangeServer.Model;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyXChangeServer.Infrastructure.Repository.Abstract
{
    public interface ICurrencyRateRepository: IRepositoryBase<CurrencyRate>
    {
    }
}
