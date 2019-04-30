using System;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentHistory.API.ActionFilters;
using PaymentHistory.Domain;

namespace PaymentHistory.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.DateFormatString =  "dd/mm/yyyy hh:mm";
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton<PaymentHistoryRequestValidationAttribute>();

            services.AddDomainDependencies(builder =>
                builder.UseSqlServer(
                    Configuration["PaymentHistoryDatabase:ConnectionString"],
                    optionsBuilder => optionsBuilder.EnableRetryOnFailure(
                        maxRetryCount: int.Parse(Configuration["PaymentHistoryDatabase:RetryCount"]),
                        maxRetryDelay: TimeSpan.FromSeconds(double.Parse(Configuration["PaymentHistoryDatabase:RetryDelayInSeconds"])),
                        errorNumbersToAdd: null)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
