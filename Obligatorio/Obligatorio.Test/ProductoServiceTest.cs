
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using Dominio;
using System;

namespace Obligatorio.Test
{ 
    [TestClass]
    public class ProductoServiceTest
    {
        public ProductoService productoService = new ProductoService();

        [TestMethod]
        public void AltaProductoTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(LargoDatoNoValidoException))]
        public void AltaNombreProductoVacioTest()
        {
            productoService.AltaProducto("", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void AltaNombreProductoFechaIncorrectaTest()
        {
            DateTime fecha = DateTime.ParseExact("1999-10-10 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",System.Globalization.CultureInfo.InvariantCulture);
            productoService.AltaProducto("Abode PhotoShoot", fecha);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void AltaNombreProductoExistenteTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
        }

        [TestMethod]
        public void ModificacionProductoTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.ModificarProducto("Abode PhotoShoot", "Abode PhotoShoot", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void ModificarProductoNombreExistenteTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaProducto("Abode Photo", DateTime.Now);
            productoService.ModificarProducto("Abode PhotoShoot", "Abode Photo", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionException))]
        public void ModificarProductoFechaVersionPosteriorTest()
        {
            DateTime fecha = DateTime.ParseExact("2001-10-10 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
            productoService.ModificarProducto("Abode PhotoShoot", "Abode PhotoShoot", fecha);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void ModificarProductoFechaIncorrectaTest()
        {
            DateTime fecha = DateTime.ParseExact("1999-10-10 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.ModificarProducto("Abode PhotoShoot", "Abode Photo", fecha);
        }

        [TestMethod]
        public void AgregarVersionTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void AgregarVersionProductoInexistenteTest()
        {
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionException))]
        public void AgregarVersionYaExistenteTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionException))]
        public void AgregarVersionFechaIncorrectaTest()
        {
            DateTime fecha = DateTime.ParseExact("1999-10-10 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", fecha);
        }

        [TestMethod]
        [ExpectedException(typeof(LargoDatoNoValidoException))]
        public void AgregarVersionEstadoVacioTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionEtiquetaException))]
        public void AgregarVersionEtiquetaVaciaTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "", "Interna", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionEtiquetaException))]
        public void AgregarVersionEtiquetaFormatoIncorrectoTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.00", "Interna", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionEtiquetaException))]
        public void AgregarVersionEtiquetaFormatoIncorrecto2Test()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.0.000", "Interna", DateTime.Now);
        }

        [TestMethod]
        public void GetVersionDeProductoTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
            productoService.GetVersionProducto("Abode PhotoShoot", "1.00.000");
        }

        [TestMethod]
        public void GetListaVersionesDeProductoTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.001", "Interna", DateTime.Now);
            productoService.GetListaVersionesVersionProducto("Abode PhotoShoot");
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void GetListaVersionesDeProductoInexistenteTest()
        {
            productoService.GetListaVersionesVersionProducto("Abode PhotoShoot");
        }

        [TestMethod]
        public void GetProductoTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.GetProducto("Abode PhotoShoot");
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void GetProductoInexistenteTest()
        {
            productoService.GetProducto("Abode PhotoShoot");
        } 

        [TestMethod]
        public void GetListaProductoTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.GetListaProducto();
        }

        [TestMethod]
        public void ModificarVersionTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
            productoService.ModificarVersion("Abode PhotoShoot", "1.00.000", "1.00.001", "Interna", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionException))]
        public void ModificarVersionFechaIncorrectaTest()
        {
            DateTime fecha = DateTime.ParseExact("1999-10-10 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.003", "Interna", DateTime.Now);
            productoService.ModificarVersion("Abode PhotoShoot", "1.00.000", "1.00.000","Interna", fecha);
        }


        [TestMethod]
        [ExpectedException(typeof(VersionException))]
        public void ModificarVersionEtiquetaExistenteTest()
        {
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.001", "Interna", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.003", "Interna", DateTime.Now);
            productoService.ModificarVersion("Abode PhotoShoot", "1.00.003", "1.00.001","Interna", DateTime.Now);
        }
    }
}
