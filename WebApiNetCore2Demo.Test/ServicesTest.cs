using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore2Demo.Controllers;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Services;

namespace WebApiNetCore2Demo.Test
{
    /// <summary>
    /// Clase con metodos para testear los servicios
    /// </summary>
    [TestClass]
    public class ServicesTest
    {
        private readonly IService<int, Producto> productoService;

        [TestInitialize]
        public void Setup()
        {
            IoCDIConfiguration.RegistrarInyeccionDependencias();
        }

        public ServicesTest(IService<int, Producto> productoService)
        {
            this.productoService = productoService;
        }

        #region ProductoService

        /// <summary>
        /// Testea el metodo GetAll()
        /// </summary>
        [TestMethod]
        public async Task GetProductExpectsListTest()
        {
            var listaProductos = await productoService.GetAll();
            Assert.IsNotNull(listaProductos);
            Assert.AreNotSame(0, listaProductos.Count());
        } 

        #endregion
    }
}
