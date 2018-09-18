using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using Microsoft.Extensions.Logging;
using WebApiNetCore2Demo.Services;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models;
using Microsoft.AspNetCore.Mvc.Versioning;
using WebApiNetCore2Demo.Routes;
using Microsoft.EntityFrameworkCore;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Repositories;
using WebApiNetCore2Demo.Implementations;

namespace WebApiNetCore2Demo
{
    /// <summary>
    /// Contiene toda la configuracion de la api de inicio
    /// </summary>
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Configuracion de Mvc

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddOptions();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressConsumesConstraintForFormFileParameters = true;
                options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            #endregion

            #region Configuracion de Swagger

            services.AddSwaggerGen(swagger =>
            {
                var contact = new Contact() { Name = SwaggerConfiguration.ContactName };
                swagger.SwaggerDoc("v1", new Info
                {
                    Title = SwaggerConfiguration.DocInfoTitle,
                    Version = "v1",
                    Description = SwaggerConfiguration.DocInfoDescription,
                    Contact = contact
                });

                swagger.OperationFilter<SwaggerDefaultValues>();
            });

            #endregion

            #region Inyeccion de dependencias

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddDbContext<ComprasContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ComprasConnection"]));
            services.AddTransient<IService<int, Producto>, ProductoService>();
            services.AddTransient<IProductoRepository, ProductoRepository>();

            #endregion
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        /// <see cref="https://autofac.readthedocs.io/en/latest/integration/aspnetcore.html#differences-from-asp-net-classic"/>
        /// <see cref="https://geeks.ms/jorge/category/web-api/"/>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Genera el endpoint de Swagger como un objeto JSON.
            app.UseSwagger();

            // Habilita Swagger-ui para el endpoint generado.
            app.UseSwaggerUI(c =>
            {
                //c.SwaggerEndpoint(ApiRoutesBase.GetSwaggerEndpointUrl(ApiVersions.v1), ApiRoutesBase.GetSwaggerEndpointDescription(ApiVersions.v1));
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ApiRoutesBase.GetSwaggerEndpointDescription(ApiVersions.v1));
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            else
            {
                app.UseHsts();
            }

            // Habilita HTTPS
            app.UseHttpsRedirection();

            // Agrega el log
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Agrega el MVC a la aplicacion
            app.UseMvc();
        }
    }
}
