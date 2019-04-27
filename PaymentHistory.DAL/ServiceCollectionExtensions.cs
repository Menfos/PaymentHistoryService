using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaymentHistory.DAL.Contexts;

namespace PaymentHistory.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataDependencies(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> dbContextConfigurator)
        {

            services.AddDbContext<PaymentHistoryDbContext>(dbContextConfigurator);
            return services;
        }
    }
}