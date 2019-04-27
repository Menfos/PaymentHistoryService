using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentHistory.DAL;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDataDependencies(builder =>
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
