using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.IO;
using MainService.Contracts;
using MainService.Services;

namespace WebApplication1
{
    /// <summary>
    /// startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// startup class constructor.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// configuration instance.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// use this method to configure services.
        /// </summary>
        /// <param name="services">an instance of services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<ICalc, CalcService>();

            services.AddSwaggerGen(
                c =>
                {
                    var info = new OpenApiInfo
                    {
                        Title = "Desafio Técnico SoftPlan - Marcos Pinello - API 1",
                        Version = PlatformServices.Default.Application.ApplicationVersion,
                        Description = "Get interest rate.",
                        Contact = new OpenApiContact
                        {
                            Name = "SoftPlan",
                            Url = new Uri("https://www.softplan.com.br/"),
                        },
                    };
                    c.SwaggerDoc("v1", info);
                    c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"WebApplication1.xml"));
                });
        }

        /// <summary>
        /// method to configure application.
        /// </summary>
        /// <param name="app">an app instance.</param>
        /// <param name="env">an env instance.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/v1/swagger.json", env.ApplicationName); });
        }
    }
}
