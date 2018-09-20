using Microsoft.Extensions.Logging;
using WebApiNetCore2Demo.Controllers;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Repositories;
using WebApiNetCore2Demo.Services;

namespace WebApiNetCore2Demo.Test
{
    /// <summary>
    /// Objeto que contiene todos los objetos utilizados en los test que se deben inicializar
    /// </summary>
    public class SetupObject
    {
        public ComprasContext context { get; set; }
        public IProductoRepository productoRepository { get; set; }
        public IService<int, Producto> productoService { get; set; }
        public ProductoController productoController { get; set; }
    }
}
