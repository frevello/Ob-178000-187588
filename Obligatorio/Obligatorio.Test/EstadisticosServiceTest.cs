using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using InterfazServiceUI;
using Dominio;

namespace Obligatorio.Test
{
    [TestClass]
    public class EstadisticosServiceTest
    {

       [TestMethod]
        public void GetPromedioRegistroTest()
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
            dataSetService.GetPromedioRegistro(dataSet, "CPU");
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetPromedioRegistroNoExiteRegistroTest()
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
            dataSetService.GetPromedioRegistro(dataSet, "GPU");
        }

        [TestMethod]
        public void GetMinimoRegistroTest()
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
            dataSetService.GetMinimoRegistro(dataSet, "CPU");
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetMinimoRegistroNoExiteRegistroTest()
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
            dataSetService.GetMinimoRegistro(dataSet, "PU");
        }
        [TestMethod]
        public void GetMaximoRegistroTest()
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
            dataSetService.GetMaximoRegistro(dataSet, "CPU");
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetMaximoRegistroNoExisteRegistroTest()
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
            dataSetService.GetMaximoRegistro(dataSet, "PU");
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetMaximoRegistroNoExistenDatosRegistroTest()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = new DataSet("DataSet1");
            String[] nombresRegistros = { "CPU", "TIME" };
            dataSet.CargarRegistrosVARDEF(nombresRegistros);
            dataSetService.GetMaximoRegistro(dataSet, "CPU");
        }

        [TestMethod]
        public void GetCantidadRegistrosTest()
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
            dataSetService.GetCantidadRegistros(dataSet);
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetCantidadRegistrosNoExisteDataSetTest()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = null;
            dataSetService.GetCantidadRegistros(dataSet);
        }
    }
}
