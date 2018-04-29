using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyXChangeServer.Core.Manager.Abstract;
using MoneyXChangeServer.Core.Manager.Concrete;
using MoneyXChangeServer.Infrastructure.Context;
using MoneyXChangeServer.Infrastructure.Repository.Abstract;
using MoneyXChangeServer.Infrastructure.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyXChangeServer.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CurrencyRateContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            // services.AddScoped<ICurrencyRateRepository, CurrencyRateRepository>();
        }

        public static void ConfigureManagers(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyManager, CurrencyManager>();
        }
    }
}
