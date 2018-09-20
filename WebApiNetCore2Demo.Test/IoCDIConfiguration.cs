﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApiNetCore2Demo.Controllers;
using WebApiNetCore2Demo.Implementations;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Repositories;
using WebApiNetCore2Demo.Services;

namespace WebApiNetCore2Demo.Test
{
    /// <summary>
    /// Clase para la configuracion de la inyeccion de dependencias
    /// </summary>
    public class IoCDIConfiguration
    {
        private const string DB_CONNECTION_STRING = "Server=192.168.100.10;Database=Compras;User Id=compras; Password=compras";
        private const string DB_NAME = "Compras";

        /// <summary>
        /// Realiza el registro de los objetos que serviran en la inyeccion de dependencias
        /// </summary>
        public static void RegistrarInyeccionDependencias()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ComprasContext>(options => options.UseSqlServer(DB_CONNECTION_STRING));
            //services.AddDbContext<ComprasContext>(options => options.UseInMemoryDatabase(DB_NAME));
            services.AddTransient<IService<int, Producto>, ProductoService>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
        }

        /// <summary>
        /// Simula la inyeccion de dependencias para que funcionen los test sin usar mocks sin funcionalidad
        /// </summary>
        /// <returns></returns>
        public static SetupObject InicializarDependenciasManualmente()
        {
            // Objeto principal
            SetupObject setup = new SetupObject();

            // Base de datos
            var options = new DbContextOptionsBuilder<ComprasContext>().UseInMemoryDatabase(DB_NAME).Options;
            setup.context = new ComprasContext(options);

            // Logger
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();

            // Repositorios
            setup.productoRepository = new ProductoRepository(setup.context);

            // Servicios
            setup.productoService = new ProductoService(factory.CreateLogger<ProductoService>(), setup.productoRepository);

            // Controladores
            setup.productoController = new ProductoController(setup.productoService);

            return setup;
        }
    }
}
