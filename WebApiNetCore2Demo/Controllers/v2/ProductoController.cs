using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models;
using WebApiNetCore2Demo.Routes;

namespace WebApiNetCore2Demo.Controllers.v2
{
    /// <summary>
    /// Controlador para Productos, utiliza el inyector de dependencias de Autofac
    /// </summary>
    [ApiController]
    [ApiVersion(ApiRouteV2.ApiVersion)]
    [Produces(ApiRouteV2.ApiResponseFormat)]
    [Route(ApiRouteV2.ControllerRoute)]
    public class ProductoController : ControllerBase
    {
        private readonly IService<int, ProductoModel> _productoService;

        /// <summary>
        /// Constructor con inyeccion de servicio
        /// </summary>
        /// <param name="productoService"></param>
        public ProductoController(IService<int, ProductoModel> productoService)
        {
            _productoService = productoService;
        }

        /// <summary>
        /// Obtiene la lista de productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<ProductoModel>> GetProductos()
        {
            return _productoService.GetAll().ToList();
        }

        /// <summary>
        /// Obtiene un producto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public ActionResult<ProductoModel> Get(int id)
        {
            return _productoService.GetById(id);
        }

        /// <summary>
        /// Guarda un producto
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(400)]
        public ActionResult<bool> Post([FromBody] string value)
        {
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Actualiza un producto en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        public ActionResult<bool> Put(int id, [FromBody] string value)
        {
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Elimina un producto en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        public ActionResult<bool> Delete(int id)
        {
            return NotFound();
        }
    }
}