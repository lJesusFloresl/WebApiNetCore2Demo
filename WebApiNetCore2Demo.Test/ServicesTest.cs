using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore2Demo.Controllers;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Services;
using WebApiNetCore2Demo.Utils;

namespace WebApiNetCore2Demo.Test
{
    /// <summary>
    /// Clase con metodos para testear los servicios
    /// </summary>
    [TestClass]
    public class ServicesTest
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
            var respuestaProducto = await GuardaNuevoProducto();
            Assert.IsTrue(respuestaProducto.exito);
            var listaProductos = await megaMock.productoService.GetAll();
            Assert.IsNotNull(listaProductos);
            Assert.AreNotEqual(0, listaProductos.Count());
        }

        /// <summary>
        /// Testea el metodo GetById()
        /// </summary>
        [TestMethod]
        public async Task GetProductByIdExpectsProductTest()
        {
            var respuestaProducto = await GuardaNuevoProducto();
            Assert.IsTrue(respuestaProducto.exito);
            var productoGuardado = (Producto)respuestaProducto.datos;
            var productoBuscado = await megaMock.productoService.GetById(productoGuardado.Id);
            Assert.IsNotNull(productoBuscado);
            Assert.AreSame(productoGuardado, productoBuscado);
        }

        /// <summary>
        /// Testea el metodo Add()
        /// </summary>
        [TestMethod]
        public async Task AddProductExpectsTrue()
        {
            var respuestaProducto = await GuardaNuevoProducto();
            Assert.IsTrue(respuestaProducto.exito);
            var productoGuardado = (Producto)respuestaProducto.datos;
            Assert.AreNotEqual(0, productoGuardado.Id);
            var productoBuscado = await megaMock.productoService.GetById(productoGuardado.Id);
            Assert.IsNotNull(productoBuscado);
            Assert.AreSame(productoBuscado, productoGuardado);
        }

        /// <summary>
        /// Testea el metodo Update()
        /// </summary>
        [TestMethod]
        public async Task UpdateProductExpectsTrue()
        {
            var respuestaProducto = await GuardaNuevoProducto();
            Assert.IsTrue(respuestaProducto.exito);
            var productoGuardado = (Producto)respuestaProducto.datos;
            productoGuardado.Descripcion = "Producto Test Modificado";
            var respuestaProductoActualizado = await megaMock.productoService.Update(productoGuardado);
            Assert.IsTrue(respuestaProductoActualizado.exito);
            var productoActualizado = (Producto)respuestaProductoActualizado.datos;
            var productoBuscado = await megaMock.productoService.GetById(productoActualizado.Id);
            Assert.IsNotNull(productoBuscado);
            Assert.AreSame(productoBuscado, productoActualizado);
        }

        /// <summary>
        /// Testea el metodo Update()
        /// </summary>
        [TestMethod]
        public async Task DeleteProductExpectsTrue()
        {
            var respuestaProducto = await GuardaNuevoProducto();
            Assert.IsTrue(respuestaProducto.exito);
            var productoGuardado = (Producto)respuestaProducto.datos;
            var productoEliminado = await megaMock.productoService.Delete(productoGuardado.Id);
            Assert.IsTrue(productoEliminado.exito);
            var productoBuscado = await megaMock.productoService.GetById(productoGuardado.Id);
            Assert.IsNull(productoBuscado);
        }

        #region Metodos Privados

        private async Task<ServerResponse> GuardaNuevoProducto()
        {
            var producto = new Producto()
            {
                Id = 0,
                Clave = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Descripcion = "Producto Test",
                PrecioUnitario = 0
            };

            return await megaMock.productoService.Add(producto);
        }

        #endregion
    }
}
