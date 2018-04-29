using Microsoft.EntityFrameworkCore;
using MoneyXChangeServer.Infrastructure.Context;
using MoneyXChangeServer.Infrastructure.Repository.Abstract;
using MoneyXChangeServer.Model;
using Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyXChangeServer.Infrastructure.Repository.Concrete
{
    public class CurrencyRepository : RepositoryBase<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(CurrencyRateContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
