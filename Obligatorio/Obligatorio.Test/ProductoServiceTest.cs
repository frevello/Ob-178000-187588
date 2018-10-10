using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using Dominio;

namespace Obligatorio.Test
{
    
    [TestClass]
    public class ProductoServiceTest
    {
        public ProductoService productoService = new ProductoService();

        [TestMethod]
        public void AltaProductoTest()
        {
            productoService.AltaProducto("Abode PhotoShoot");
        }

        [TestMethod]
        [ExpectedException(typeof(LargoDatoNoValidoException))]
        public void AltaNombreProductoVacioTest()
        {
            productoService.AltaProducto("");
        }

        [TestMethod]
       [ExpectedException(typeof(ProductoServiceException))]
        public void AltaNombreProductoExistenteTest()
        {
            productoService.AltaProducto("Abode PhotoShoot");
            productoService.AltaProducto("Abode PhotoShoot");
        }

        [TestMethod]
        public void ModificacionProductoTest()
        {

        }
    }
}
