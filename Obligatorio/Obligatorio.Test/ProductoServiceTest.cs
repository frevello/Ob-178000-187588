
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
            productoService.ModificarProducto();
        }

        [TestMethod]
        public void AgregarVersionTest()
        {
            productoService.AltaProducto("Abode PhotoShoot");
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna");
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void AgregarVersionProductoInexistenteTest()
        {
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna");
        }

        [TestMethod]
        [ExpectedException(typeof(VersionException))]
        public void AgregarVersionYaExistenteTest()
        {
            productoService.AltaProducto("Abode PhotoShoot");
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna");
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna");
        }

        [TestMethod]
        [ExpectedException(typeof(LargoDatoNoValidoException))]
        public void AgregarVersionEstadoVacioTest()
        {
            productoService.AltaProducto("Abode PhotoShoot");
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "");
        }

        [TestMethod]
        [ExpectedException(typeof(VersionEtiquetaException))]
        public void AgregarVersionEtiquetaVaciaTest()
        {
            productoService.AltaProducto("Abode PhotoShoot");
            productoService.AltaVersion("Abode PhotoShoot", "", "Interna");
        }

        [TestMethod]
        [ExpectedException(typeof(VersionEtiquetaException))]
        public void AgregarVersionEtiquetaFormatoIncorrectoTest()
        {
            productoService.AltaProducto("Abode PhotoShoot");
            productoService.AltaVersion("Abode PhotoShoot", "1.00.00", "Interna");
        }

        [TestMethod]
        [ExpectedException(typeof(VersionEtiquetaException))]
        public void AgregarVersionEtiquetaFormatoIncorrecto2Test()
        {
            productoService.AltaProducto("Abode PhotoShoot");
            productoService.AltaVersion("Abode PhotoShoot", "1.0.000", "Interna");
        }

        [TestMethod]
        public void GetVersionDeProductoTest()
        {
            productoService.AltaProducto("Abode PhotoShoot");
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna");
            productoService.GetVersionProducto("Abode PhotoShoot", "1.00.000");
        }

        [TestMethod]
        public void GetListaVersionesDeProductoTest()
        {
            productoService.AltaProducto("Abode PhotoShoot");
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna");
            productoService.AltaVersion("Abode PhotoShoot", "1.00.001", "Interna");
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
            productoService.AltaProducto("Abode PhotoShoot");
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
            productoService.AltaProducto("Abode PhotoShoot");
            productoService.GetListaProducto("Abode PhotoShoot");
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void GetListaProductoInexistenteTest()
        {
            productoService.GetListaProducto("Abode PhotoShoot");
        }
    }
}
