using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;
using WebApiNetCore2Demo.Services;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models;
using Microsoft.AspNetCore.Mvc.Versioning;
using System.Linq;
using WebApiNetCore2Demo.Routes;

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

        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            #region Configuracion de Mvc

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressConsumesConstraintForFormFileParameters = true;
                options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressModelStateInvalidFilter = true;
            });

            #endregion

            #region Configuracion de Swagger

            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ApiVersionReader = new MediaTypeApiVersionReader();
            });

            services.AddSwaggerGen(swagger =>
            {
                var contact = new Contact() { Name = SwaggerConfiguration.ContactName };
                swagger.SwaggerDoc(ApiRouteV1.ApiVersion, new Info
                {
                    Title = SwaggerConfiguration.DocInfoTitle,
                    Version = ApiRouteV1.ApiVersion,
                    Description = SwaggerConfiguration.DocInfoDescription,
                    Contact = contact
                });

                //swagger.SwaggerDoc(ApiRouteV2.ApiVersion, new Info
                //{
                //    Title = SwaggerConfiguration.DocInfoTitle,
                //    Version = ApiRouteV2.ApiVersion,
                //    Description = SwaggerConfiguration.DocInfoDescription,
                //    Contact = contact
                //});

                //swagger.DocInclusionPredicate((apiVersion, apiDescription) =>
                //{
                //    var actionApiVersionModel = apiDescription.ActionDescriptor?.GetApiVersion();
                //    if (actionApiVersionModel == null)
                //        return true;
                //    if (actionApiVersionModel.DeclaredApiVersions.Any())
                //        return actionApiVersionModel.DeclaredApiVersions.Any(v => $"v{v.ToString()}" == apiVersion);
                //    return actionApiVersionModel.ImplementedApiVersions.Any(v => $"v{v.ToString()}" == apiVersion);
                //});

                swagger.OperationFilter<ApiVersionOperationFilter>();

                // Agrega la ruta de los comentarios para que sea leida por Swagger JSON and UI.
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "WebApiNetCore2Demo.xml");
                swagger.IncludeXmlComments(xmlPath);
            });

            #endregion

            #region Configuracion de Autofac (inyeccion de dependencias)

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.Register(c => new ProductoService(c.Resolve<ILogger<ProductoService>>()))
                .As<IService<int, ProductoModel>>().InstancePerLifetimeScope();

            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);

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
                c.SwaggerEndpoint(ApiRouteV1.SwaggerEndpointUrl, ApiRouteV1.SwaggerEndpointDescription);
                //c.SwaggerEndpoint(ApiRouteV2.SwaggerEndpointUrl, ApiRouteV2.SwaggerEndpointDescription);
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
