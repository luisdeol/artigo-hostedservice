using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtigoHostedService.API.HostedServices;
using ArtigoHostedService.API.Persistence;
using ArtigoHostedService.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ArtigoHostedService.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHostedService<RegistrarBoletoHostedService>();

            services
                .AddScoped<IBoletoRepository, BoletoFakeRepository>();

            services
                .AddScoped<IBoletoRegistroService, BoletoRegistroFakeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
