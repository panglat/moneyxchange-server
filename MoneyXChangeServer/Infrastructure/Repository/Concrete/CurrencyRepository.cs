using Microsoft.EntityFrameworkCore;
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
        public CurrencyRepository(DbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
