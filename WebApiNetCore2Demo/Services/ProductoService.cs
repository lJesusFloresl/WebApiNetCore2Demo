using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Repositories;

namespace WebApiNetCore2Demo.Services
{
    /// <summary>
    /// Servicio para el manejo de productos
    /// </summary>
    public class ProductoService : IService<int, Producto>
    {
        private readonly ILogger<ProductoService> LOGGER;
        private readonly IProductoRepository productoRepository;

        /// <summary>
        /// Constructor de ProductoService con logger
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        public ProductoService(ILogger<ProductoService> logger, IProductoRepository repository)
        {
            LOGGER = logger;
            productoRepository = repository;
        }

        /// <summary>
        /// Obtiene la lista de productos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Producto> GetAll()
        {
            LOGGER.LogDebug("{method} called", nameof(GetAll));
            return productoRepository.GetAll().ToList();
        }

        /// <summary>
        /// Obtiene un producto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Producto GetById(int id)
        {
            LOGGER.LogDebug("{method} called with {id}", nameof(GetById), id);
            return productoRepository.GetById(id);
        }
    }
}
