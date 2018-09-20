using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiNetCore2Demo.Controllers;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Services;
using WebApiNetCore2Demo.Utils;

namespace WebApiNetCore2Demo.Test
{
    /// <summary>
    /// Clase con metodos para testear los controladores
    /// </summary>
    [TestClass]
    public class ControllersTest
    {
        private SetupObject megaMock;

        [TestInitialize]
        public void Setup()
        {
            megaMock = IoCDIConfiguration.InicializarDependenciasManualmente();
        }

        /// <summary>
        /// Testea el metodo GetAll()
        /// </summary>
        [TestMethod]
        public async Task GetProductExpectsListTest()
        {
            var actionResultProducto = await GuardaNuevoProducto() as OkObjectResult;
            var respuestaProducto = (ServerResponse)actionResultProducto.Value;
            Assert.IsTrue(respuestaProducto.exito);
            var actionResult = await megaMock.productoController.GetAll() as OkObjectResult;
            var listaProductos = actionResult.Value as IEnumerable<Producto>;
            Assert.IsNotNull(listaProductos);
            Assert.AreNotEqual(0, listaProductos.Count());
        }

        /// <summary>
        /// Testea el metodo GetById()
        /// </summary>
        [TestMethod]
        public async Task GetProductByIdExpectsProductTest()
        {
            var actionResultProducto = await GuardaNuevoProducto() as OkObjectResult;
            var respuestaProducto = (ServerResponse)actionResultProducto.Value;
            Assert.IsTrue(respuestaProducto.exito);
            var productoGuardado = (Producto)respuestaProducto.datos;
            var actionResult = await megaMock.productoController.GetById(productoGuardado.Id) as OkObjectResult;
            var productoBuscado = actionResult.Value as Producto;
            Assert.IsNotNull(productoBuscado);
            Assert.AreSame(productoBuscado, productoGuardado);
        }

        /// <summary>
        /// Testea el metodo Add()
        /// </summary>
        [TestMethod]
        public async Task AddProductExpectsTrue()
        {
            var actionResultProducto = await GuardaNuevoProducto() as OkObjectResult;
            var respuestaProducto = (ServerResponse)actionResultProducto.Value;
            Assert.IsTrue(respuestaProducto.exito);
            var productoGuardado = (Producto)respuestaProducto.datos;
            Assert.AreNotEqual(0, productoGuardado.Id);
            var actionResult = await megaMock.productoController.GetById(productoGuardado.Id) as OkObjectResult;
            var productoBuscado = actionResult.Value as Producto;
            Assert.IsNotNull(productoBuscado);
            Assert.AreSame(productoBuscado, productoGuardado);
        }

        /// <summary>
        /// Testea el metodo Update()
        /// </summary>
        [TestMethod]
        public async Task UpdateProductExpectsTrue()
        {
            var actionResultProducto = await GuardaNuevoProducto() as OkObjectResult;
            var respuestaProducto = (ServerResponse)actionResultProducto.Value;
            Assert.IsTrue(respuestaProducto.exito);
            var productoGuardado = (Producto)respuestaProducto.datos;
            productoGuardado.Descripcion = "Producto Test Modificado";
            var actionResultActualizado = await megaMock.productoController.Put(productoGuardado.Id, productoGuardado) as OkObjectResult;
            var respuestaProductoActualizado = (ServerResponse)actionResultActualizado.Value;
            Assert.IsTrue(respuestaProductoActualizado.exito);
            var productoActualizado = (Producto)respuestaProductoActualizado.datos;
            var actionResult = await megaMock.productoController.GetById(productoActualizado.Id) as OkObjectResult;
            var productoBuscado = actionResult.Value as Producto;
            Assert.IsNotNull(productoBuscado);
            Assert.AreSame(productoBuscado, productoActualizado);
        }

        /// <summary>
        /// Testea el metodo Update()
        /// </summary>
        [TestMethod]
        public async Task DeleteProductExpectsTrue()
        {
            var actionResultProducto = await GuardaNuevoProducto() as OkObjectResult;
            var respuestaProducto = (ServerResponse)actionResultProducto.Value;
            Assert.IsTrue(respuestaProducto.exito);
            var productoGuardado = (Producto)respuestaProducto.datos;
            var actionResultEliminado = await megaMock.productoController.Delete(productoGuardado.Id) as OkObjectResult;
            var productoEliminado = (ServerResponse)actionResultEliminado.Value;
            Assert.IsTrue(productoEliminado.exito);
            var actionResult = await megaMock.productoController.GetById(productoGuardado.Id) as OkObjectResult;
            var productoBuscado = actionResult.Value as Producto;
            Assert.IsNull(productoBuscado);
        }

        #region Metodos Privados

        private async Task<IActionResult> GuardaNuevoProducto()
        {
            var producto = new Producto()
            {
                Id = 0,
                Clave = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Descripcion = "Producto Test",
                PrecioUnitario = 0
            };

            return await megaMock.productoController.Post(producto);
        }

        #endregion
    }
}
