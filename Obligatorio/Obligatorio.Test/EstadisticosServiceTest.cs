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
            grupoRegistro2.Add("TIME", 2);
            dataSet.AddGrupoRegistro(grupoRegistro2);
            return dataSet;
        }
    }
}
