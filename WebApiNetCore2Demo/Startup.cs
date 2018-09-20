using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Logging;
using WebApiNetCore2Demo.Services;
using WebApiNetCore2Demo.Interfaces;
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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        /// <summary>
        /// Variable que contiene toda la configuracion de la aplicacion
        /// </summary>
        public IConfigurationRoot Configuration { get; private set; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container. 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            #region Configuracion de Mvc

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            #endregion

            #region Configuracion de Swagger y Versionamiento de Api

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddSwaggerGen(swagger =>
            {
                var contact = new Contact() { Name = SwaggerConfiguration.ContactName };

                swagger.SwaggerDoc(ApiVersions.v1, new Info
                {
                    Title = SwaggerConfiguration.DocInfoTitle,
                    Version = ApiVersions.v1,
                    Description = SwaggerConfiguration.DocInfoDescription,
                    Contact = contact
                });
            });

            #endregion

            #region Registro de clases para la Inyeccion de dependencias

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
                c.SwaggerEndpoint(SwaggerConfiguration.GetEndpointUrl(ApiVersions.v1), SwaggerConfiguration.EndpointDescription);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            else
            {
                app.UseHsts();
            }

            // Agrega el log
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Agrega el MVC a la aplicacion
            app.UseMvc();
        }
    }
}
