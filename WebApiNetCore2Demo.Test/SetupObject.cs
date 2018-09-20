using System;
using System.Collections.Generic;
using System.Text;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Repositories;

namespace WebApiNetCore2Demo.Test
{
    /// <summary>
    /// Objeto que contiene todos los objetos utilizados en los test que se deben inicializar
    /// </summary>
    public class SetupObject
    {
        public ComprasContext context { get; set; }
        public IProductoRepository productoRepository { get; set; }
    }
}
