using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Repositories;
using WebApiNetCore2Demo.Utils;

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

        public async Task<ServerResponse> Add(Producto entity)
        {
            LOGGER.LogDebug(Constantes.FORMATO_LOGGER_DEBUG_VOID, nameof(Add));
            try
            {
                var productoGuardado = await productoRepository.Add(entity);
                return Utilerias.GenerarRespuestaCorrecta(productoGuardado);
            }
            catch (Exception ex)
            {
                return Utilerias.GenerarRespuestaExcepcion(ex, entity);
            }
        }

        public async Task<ServerResponse> Delete(int id)
        {
            LOGGER.LogDebug(Constantes.FORMATO_LOGGER_DEBUG_ID, nameof(Delete), id);
            try
            {
                var productoEliminado = await productoRepository.Delete(id);
                return Utilerias.GenerarRespuestaCorrecta(productoEliminado);
            }
            catch (Exception ex)
            {
                return Utilerias.GenerarRespuestaExcepcion(ex, id);
            }
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            LOGGER.LogDebug(Constantes.FORMATO_LOGGER_DEBUG_VOID, nameof(GetAll));
            return await productoRepository.GetAll();
        }

        public async Task<Producto> GetById(int id)
        {
            LOGGER.LogDebug(Constantes.FORMATO_LOGGER_DEBUG_ID, nameof(GetById), id);
            return await productoRepository.GetById(id);
        }

        public async Task<ServerResponse> Update(Producto entity)
        {
            LOGGER.LogDebug(Constantes.FORMATO_LOGGER_DEBUG_VOID, nameof(Update));
            try
            {
                var productoActualizado = await productoRepository.Update(entity);
                return Utilerias.GenerarRespuestaCorrecta(productoActualizado);
            }
            catch (Exception ex)
            {
                return Utilerias.GenerarRespuestaExcepcion(ex, entity);
            }
        }
    }
}
