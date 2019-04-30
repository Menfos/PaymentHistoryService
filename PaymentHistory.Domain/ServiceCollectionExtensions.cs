using Microsoft.Extensions.DependencyInjection;
using PaymentHistory.DAL;
using System;
using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentHistory.Domain.Abstractions;
using PaymentHistory.Domain.Handlers;

namespace PaymentHistory.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainDependencies(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> dbContextConfigurator)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDataDependencies(dbContextConfigurator);
            services.AddScoped<IPaymentHistoryHandler, PaymentHistoryHandler>();
            return services;
        }
    }
}