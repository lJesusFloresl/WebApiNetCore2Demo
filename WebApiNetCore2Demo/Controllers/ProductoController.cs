using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Routes;
using WebApiNetCore2Demo.Utils;

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
        public async Task<IActionResult> GetProductos()
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
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await productoService.GetById(id);
            if (producto == null)
                return NotFound(Constantes.MENSAJE_NOT_FOUND);
            else
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
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            var guardado = await productoService.Add(producto);
            if (guardado.exito)
                return Ok(guardado);
            else
                return BadRequest(guardado);
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
        public async Task<IActionResult> Put(int id, [FromBody] Producto producto)
        {
            var actualizado = await productoService.Update(producto);
            if (actualizado.exito)
                return Ok(actualizado);
            else
                return BadRequest(actualizado);
        }

        /// <summary>
        /// Elimina un producto en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await productoService.Delete(id);
            if (eliminado.exito)
                return NotFound(Constantes.MENSAJE_NOT_FOUND);
            else
                return Ok(eliminado);
        }
    }
}