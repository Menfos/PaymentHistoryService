using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaymentHistory.DAL.Abstractions;
using PaymentHistory.DAL.Contexts;
using PaymentHistory.DAL.Repositories;

namespace PaymentHistory.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataDependencies(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> dbContextConfigurator)
        {
            services.AddScoped<IPaymentHistoryRepository, PaymentHistoryRepository>();
            services.AddDbContext<PaymentHistoryDbContext>(dbContextConfigurator);
            return services;
        }
    }
}