using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using InterfazServiceUI;
using Dominio;
using InterfazUI;

namespace Obligatorio.Test
{
    [TestClass]
    public class EstadisticosServiceTest
    {

       [TestMethod]
        public void GetPromedioRegistroTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetPromedioRegistro(dataSet, "CPU");
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetPromedioRegistroNoExiteRegistroTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetPromedioRegistro(dataSet, "GPU");
        }

        [TestMethod]
        public void GetMinimoRegistroTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetMinimoRegistro(dataSet, "CPU");
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetMinimoRegistroNoExiteRegistroTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetMinimoRegistro(dataSet, "PU");
        }
        [TestMethod]
        public void GetMaximoRegistroTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetMaximoRegistro(dataSet, "CPU");
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetMaximoRegistroNoExisteRegistroTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetMaximoRegistro(dataSet, "PU");
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetMaximoRegistroNoExistenDatosRegistroTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = new DataSet("DataSet1");
            String[] nombresRegistros = { "CPU", "TIME" };
            dataSet.CargarRegistrosVARDEF(nombresRegistros);
            estadisticosService.GetMaximoRegistro(dataSet, "CPU");
        }

        [TestMethod]
        public void GetCantidadRegistrosTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetCantidadRegistros(dataSet);
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetCantidadRegistrosNoExisteDataSetTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = null;
            estadisticosService.GetCantidadRegistros(dataSet);
        }

        [TestMethod]
        public void GetPromedioRegistroDesdeHastaTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetPromedioRegistroDesdeHasta(dataSet, "CPU", 2,4);
        }
        [TestMethod]
        public void GetMinimoRegistroDesdeHastaTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetMinimoRegistroDesdeHasta(dataSet, "CPU", 2, 4);
        }
        [TestMethod]
        public void GetMaximoRegistroDesdeHastaTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetMaximoRegistroDesdeHasta(dataSet, "CPU", 2, 4);
        }
        [TestMethod]
        public void GetPromedioRegistroDesdeHastaFueraRangoTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetPromedioRegistroDesdeHasta(dataSet, "CPU", 8, 9);
        }
        [TestMethod]
        public void GetMinimoRegistroDesdeHastaFueraRangoTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetMinimoRegistroDesdeHasta(dataSet, "CPU", 8, 9);
        }
        [TestMethod]
        public void GetMaximoRegistroDesdeHastaFueraRangoTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetMaximoRegistroDesdeHasta(dataSet, "CPU", 8, 9);
        }
        [TestMethod]
        [ExpectedException(typeof(EstadisticosServiceException))]
        public void GetMaximoRegistroDesdeMenorHastaTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetMaximoRegistroDesdeHasta(dataSet, "CPU", 10, 9);
        }
        [TestMethod]
        public void GetMaximoRegistroDesdeMayorMaximoTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetMaximoRegistroDesdeHasta(dataSet, "CPU", 10, 14);
        }
        [TestMethod]
        public void GetMaximoRegistroHastaMenorMinimoTest()
        {
            IEstadisticosService estadisticosService = new EstadisticosService();
            Dominio.DataSet dataSet = crearDataSet();
            estadisticosService.GetMaximoRegistroDesdeHasta(dataSet, "CPU", 0, 1);
        }
        private Dominio.DataSet crearDataSet()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = new DataSet("DataSet1");
            String[] nombresRegistros = { "CPU", "TIME" };
            dataSet.CargarRegistrosVARDEF(nombresRegistros);
            IDictionary<String, float> grupoRegistro = new Dictionary<String, float>();
            grupoRegistro.Add("CPU", 1);
            grupoRegistro.Add("TIME", 2);
            dataSet.AddGrupoRegistro(grupoRegistro);
            IDictionary<String, float> grupoRegistro2 = new Dictionary<String, float>();
            grupoRegistro2.Add("CPU", 1);
            grupoRegistro2.Add("TIME", 3);
            dataSet.AddGrupoRegistro(grupoRegistro2);
            IDictionary<String, float> grupoRegistro4 = new Dictionary<String, float>();
            grupoRegistro4.Add("CPU", 1);
            grupoRegistro4.Add("TIME", 4);
            dataSet.AddGrupoRegistro(grupoRegistro4);
            IDictionary<String, float> grupoRegistro5 = new Dictionary<String, float>();
            grupoRegistro5.Add("CPU", 1);
            grupoRegistro5.Add("TIME", 5);
            dataSet.AddGrupoRegistro(grupoRegistro5);
            return dataSet;
        }
    }
}
