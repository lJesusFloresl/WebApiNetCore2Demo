using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models;

namespace WebApiNetCore2Demo.Services
{
    /// <summary>
    /// Servicio para el manejo de productos
    /// </summary>
    public class ProductoService : IService<int, ProductoModel>
    {
        private readonly ILogger<ProductoService> _logger;

        /// <summary>
        /// Constructor de ProductoService con logger
        /// </summary>
        /// <param name="logger"></param>
        public ProductoService(ILogger<ProductoService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Obtiene la lista de productos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductoModel> GetAll()
        {
            _logger.LogDebug("{method} called", nameof(GetAll));

            List<ProductoModel> productos = new List<ProductoModel>();
            productos.Add(new ProductoModel() { id = 1, clave = "00001", descripcion = "COMPUTADORA HP PAVILION", precioUnitario = 8750 });
            productos.Add(new ProductoModel() { id = 2, clave = "00002", descripcion = "LAPTOP ACER ONE", precioUnitario = 4900 });
            return productos;
        }

        /// <summary>
        /// Obtiene un producto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductoModel GetById(int id)
        {
            _logger.LogDebug("{method} called with {id}", nameof(GetById), id);

            return new ProductoModel();
        }
    }
}
