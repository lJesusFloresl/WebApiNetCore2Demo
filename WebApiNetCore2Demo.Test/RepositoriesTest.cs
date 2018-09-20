using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiNetCore2Demo.Implementations;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Repositories;

namespace WebApiNetCore2Demo.Test
{
    /// <summary>
    /// Clase con metodos para testear los repositorios
    /// </summary>
    [TestClass]
    public class RepositoriesTest
    {
        private SetupObject megaMock;

        [TestInitialize]
        public void Setup()
        {
            megaMock = IoCDIConfiguration.InicializaDependenciasManualmente();
        }

        /// <summary>
        /// Testea el metodo GetAll()
        /// </summary>
        [TestMethod]
        public async Task GetProductExpectsListTest()
        {
            await GuardaNuevoProducto();
            var listaProductos = await megaMock.productoRepository.GetAll();
            Assert.IsNotNull(listaProductos);
            Assert.AreNotEqual(0, listaProductos.Count());
        }

        /// <summary>
        /// Testea el metodo GetById()
        /// </summary>
        [TestMethod]
        public async Task GetProductByIdExpectsProductTest()
        {
            var productoGuardado = await GuardaNuevoProducto();
            var productoBuscado = await megaMock.productoRepository.GetById(productoGuardado.Id);
            Assert.IsNotNull(productoBuscado);
            Assert.AreSame(productoGuardado, productoBuscado);
        }

        /// <summary>
        /// Testea el metodo Add()
        /// </summary>
        [TestMethod]
        public async Task AddProductExpectsTrue()
        {
            var productoGuardado = await GuardaNuevoProducto();
            Assert.AreNotEqual(0, productoGuardado.Id);
            var productoBuscado = await megaMock.productoRepository.GetById(productoGuardado.Id);
            Assert.IsNotNull(productoBuscado);
            Assert.AreSame(productoBuscado, productoGuardado);
        }

        /// <summary>
        /// Testea el metodo Update()
        /// </summary>
        [TestMethod]
        public async Task UpdateProductExpectsTrue()
        {
            var productoGuardado = await GuardaNuevoProducto();
            productoGuardado.Descripcion = "Producto Test Modificado";
            var productoActualizado = await megaMock.productoRepository.Update(productoGuardado);
            var productoBuscado = await megaMock.productoRepository.GetById(productoActualizado.Id);
            Assert.IsNotNull(productoBuscado);
            Assert.AreSame(productoBuscado, productoActualizado);
        }

        /// <summary>
        /// Testea el metodo Update()
        /// </summary>
        [TestMethod]
        public async Task DeleteProductExpectsTrue()
        {
            var productoGuardado = await GuardaNuevoProducto();
            var productoEliminado = await megaMock.productoRepository.Delete(productoGuardado.Id);
            Assert.IsTrue(productoEliminado);
            var productoBuscado = await megaMock.productoRepository.GetById(productoGuardado.Id);
            Assert.IsNull(productoBuscado);
        }

        #region Metodos Privados

        private async Task<Producto> GuardaNuevoProducto()
        {
            var producto = new Producto()
            {
                Id = 0,
                Clave = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Descripcion = "Producto Test",
                PrecioUnitario = 0
            };

            return await megaMock.productoRepository.Add(producto);
        }

        #endregion
    }
}
