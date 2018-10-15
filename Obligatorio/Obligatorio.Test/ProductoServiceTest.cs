
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using Dominio;
using System;
using InterfazServiceUI;

namespace Obligatorio.Test
{ 
    [TestClass]
    public class ProductoServiceTest
    {
        

        [TestMethod]
        public void AltaProductoTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(LargoDatoNoValidoException))]
        public void AltaNombreProductoVacioTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void AltaNombreProductoFechaIncorrectaTest()
        {
            IProductoService productoService = new ProductoService();
            DateTime fecha = DateTime.ParseExact("1999-10-10 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",System.Globalization.CultureInfo.InvariantCulture);
            productoService.AltaProducto("Abode PhotoShoot", fecha);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void AltaNombreProductoExistenteTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
        }

        [TestMethod]
        public void ModificacionProductoTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.ModificarProducto("Abode PhotoShoot", "Abode PhotoShoot", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void ModificarProductoNombreExistenteTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaProducto("Abode Photo", DateTime.Now);
            productoService.ModificarProducto("Abode PhotoShoot", "Abode Photo", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionException))]
        public void ModificarProductoFechaVersionPosteriorTest()
        {
            IProductoService productoService = new ProductoService();
            DateTime fecha = DateTime.ParseExact("2001-10-10 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
            productoService.ModificarProducto("Abode PhotoShoot", "Abode PhotoShoot", fecha);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void ModificarProductoFechaIncorrectaTest()
        {
            IProductoService productoService = new ProductoService();
            DateTime fecha = DateTime.ParseExact("1999-10-10 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.ModificarProducto("Abode PhotoShoot", "Abode Photo", fecha);
        }

        [TestMethod]
        public void AgregarVersionTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void AgregarVersionProductoInexistenteTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionException))]
        public void AgregarVersionYaExistenteTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionException))]
        public void AgregarVersionFechaIncorrectaTest()
        {
            IProductoService productoService = new ProductoService();
            DateTime fecha = DateTime.ParseExact("1999-10-10 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", fecha);
        }

        [TestMethod]
        [ExpectedException(typeof(LargoDatoNoValidoException))]
        public void AgregarVersionEstadoVacioTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionEtiquetaException))]
        public void AgregarVersionEtiquetaVaciaTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "", "Interna", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionEtiquetaException))]
        public void AgregarVersionEtiquetaFormatoIncorrectoTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.00", "Interna", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionEtiquetaException))]
        public void AgregarVersionEtiquetaFormatoIncorrecto2Test()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.0.000", "Interna", DateTime.Now);
        }

        [TestMethod]
        public void GetVersionDeProductoTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
            productoService.GetVersionProducto("Abode PhotoShoot", "1.00.000");
        }
        [TestMethod]
        [ExpectedException(typeof(VersionException))]
        public void GetVersionDeProductoVersionInxistenteTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
            productoService.GetVersionProducto("Abode PhotoShoot", "1.00.001");
        }

        [TestMethod]
        public void GetListaVersionesDeProductoTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.001", "Interna", DateTime.Now);
            productoService.GetListaVersionesVersionProducto("Abode PhotoShoot");
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void GetListaVersionesDeProductoInexistenteTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.GetListaVersionesVersionProducto("Abode PhotoShoot");
        }

        [TestMethod]
        public void GetProductoTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.GetProducto("Abode PhotoShoot");
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void GetProductoInexistenteTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.GetProducto("Abode PhotoShoot");
        } 

        [TestMethod]
        public void GetListaProductoTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.GetListaProducto();
        }

        [TestMethod]
        public void ModificarVersionTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.000", "Interna", DateTime.Now);
            productoService.ModificarVersion("Abode PhotoShoot", "1.00.000", "1.00.001", "Interna", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(VersionException))]
        public void ModificarVersionFechaIncorrectaTest()
        {
            IProductoService productoService = new ProductoService();
            DateTime fecha = DateTime.ParseExact("1999-10-10 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.003", "Interna", DateTime.Now);
            productoService.ModificarVersion("Abode PhotoShoot", "1.00.000", "1.00.000","Interna", fecha);
        }

        [TestMethod]
        
        public void ModificarVersionEtiquetaIgualTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.001", "Interna", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.003", "Interna", DateTime.Now);
            productoService.ModificarVersion("Abode PhotoShoot", "1.00.003", "1.00.003", "Interna", DateTime.Now);
        }
        [TestMethod]
        [ExpectedException(typeof(VersionException))]
        public void ModificarVersionEtiquetaExistenteTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.001", "Interna", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.003", "Interna", DateTime.Now);
            productoService.ModificarVersion("Abode PhotoShoot", "1.00.003", "1.00.001","Interna", DateTime.Now);
        }

        [TestMethod]
        public void AddDataSetTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.001", "Interna", DateTime.Now);
            Dominio.DataSet dataSet = new Dominio.DataSet("DataSet1");
            productoService.AddDataSet("Abode PhotoShoot", "1.00.001", dataSet);
        }
        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void AddDataSetNoExisteDataSetTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.001", "Interna", DateTime.Now);
            Dominio.DataSet dataSet = null;
            productoService.AddDataSet("Abode PhotoShoot", "1.00.001", dataSet);
        }
        [TestMethod]
        public void GetDataSetTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.001", "Interna", DateTime.Now);
            Dominio.DataSet dataSet = new Dominio.DataSet("DataSet1");
            productoService.AddDataSet("Abode PhotoShoot", "1.00.001", dataSet);
            productoService.GetDataSet("Abode PhotoShoot", "1.00.001", "DataSet1");
        }
        [TestMethod]
        [ExpectedException(typeof(ProductoServiceException))]
        public void GetDataSetNombreDataSetVacioTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.001", "Interna", DateTime.Now);
            productoService.GetDataSet("Abode PhotoShoot", "1.00.001", "");
        }
        [TestMethod]
        public void GetDataSetsTest()
        {
            IProductoService productoService = new ProductoService();
            productoService.AltaProducto("Abode PhotoShoot", DateTime.Now);
            productoService.AltaVersion("Abode PhotoShoot", "1.00.001", "Interna", DateTime.Now);
            Dominio.DataSet dataSet = new Dominio.DataSet("DataSet1");
            productoService.AddDataSet("Abode PhotoShoot", "1.00.001", dataSet);
            productoService.GetDataSets("Abode PhotoShoot", "1.00.001");
        }
       
    }
}
