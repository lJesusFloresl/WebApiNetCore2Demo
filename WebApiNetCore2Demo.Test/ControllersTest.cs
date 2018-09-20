using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiNetCore2Demo.Controllers;
using WebApiNetCore2Demo.Interfaces;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Services;

namespace WebApiNetCore2Demo.Test
{
    /// <summary>
    /// Clase con metodos para testear los controladores
    /// </summary>
    [TestClass]
    public class ControllersTest
    {
        [TestInitialize]
        public void Setup()
        {
            IoCDIConfiguration.RegistrarInyeccionDependencias();
        }

        #region ProductoController

        /// <summary>
        /// Testea el metodo GetAll()
        /// </summary>
        [TestMethod]
        public async Task GetProductExpectsListTest()
        {
            IService<int, Producto> productoService = null;
            IoCDIConfiguration.RegistrarInyeccionDependencias();
            var controller = new ProductoController(productoService);
            var actionResult = await controller.GetAll();
            Assert.IsNotNull(actionResult);
            OkObjectResult result = actionResult as OkObjectResult;
            Assert.IsNotNull(result);
        } 

        #endregion
    }
}
