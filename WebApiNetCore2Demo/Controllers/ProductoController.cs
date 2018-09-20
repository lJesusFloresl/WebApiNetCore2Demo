﻿using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Routes;

namespace WebApiNetCore2Demo.Controllers
{
    /// <summary>
    /// Controlador para Productos
    /// <para>Ejemplo de controlador manejado por versiones</para>
    /// </summary>
    [ApiController]
    [Produces(ApiRoutesBase.ApiResponseFormat)]
    [Route(ApiRoutesBase.ControllerRoute)]
    [ApiVersion(ApiVersions.v1, Deprecated = true)]
    [ApiVersion(ApiVersions.v2)]
    public class ProductoController : ControllerBase
    {
        private readonly IService<int, Producto> productoService;

        /// <summary>
        /// Constructor con inyeccion de servicio
        /// </summary>
        /// <param name="productoService"></param>
        public ProductoController(IService<int, Producto> productoService)
        {
            this.productoService = productoService;
        }

        /// <summary>
        /// Obtiene la lista de productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var productos = await productoService.GetAll();
            return Ok(productos);
        }

        /// <summary>
        /// Obtiene un producto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await productoService.GetById(id);
            return Ok(producto);
        }

        /// <summary>
        /// Guarda un producto
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(Producto producto)
        {
            if (ModelState.IsValid)
            {
                var guardado = await productoService.Add(producto);
                return Ok(guardado);
            }
            else
            {
                return BadRequest(producto);
            }
        }

        /// <summary>
        /// Actualiza un producto en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="producto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, Producto producto)
        {
            if (ModelState.IsValid)
            {
                var actualizado = await productoService.Update(producto);
                return Ok(actualizado);
            }
            else
            {
                return BadRequest(producto);
            }
        }

        /// <summary>
        /// Elimina un producto en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await productoService.Delete(id);
            return Ok(eliminado);
        }
    }
}