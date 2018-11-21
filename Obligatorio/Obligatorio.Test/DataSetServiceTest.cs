using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Collections.Generic;
using Logica;
using InterfazServiceUI;

namespace Obligatorio.Test
{
    [TestClass]
    public class DataSetServiceTest

    {
        [TestMethod]
        public void CargarDataSetTest()
        {
            IDataSetService dataSet = new DataSetService();
            dataSet.CargarDataSet(@"../../../DataSetFiles/file.txt");
        }

        [TestMethod]
        public void  GetRegistrosTest()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = new DataSet("DataSet1");
            String[] nombresRegistros = { "CPU", "TIME" };
            dataSet.CargarRegistrosVARDEF(nombresRegistros);
            IDictionary<String, float> grupoRegistro = new Dictionary<String, float>();
            grupoRegistro.Add("CPU", 1);
            grupoRegistro.Add("TIME", 2);
            dataSet.AddGrupoRegistro(grupoRegistro);
            IEnumerable<VariablesDataSet> registros = dataSetService.GetRegistros(dataSet);
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetRegistrosNoExisteDataSetTest()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = null;
            IEnumerable<VariablesDataSet> registros = dataSetService.GetRegistros(dataSet);
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetRegistrosNoExisteRegistrosTest()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = null;
            IEnumerable<VariablesDataSet> registros = dataSetService.GetRegistros(dataSet);
        }
        [TestMethod]
        public void GetRegistroTest()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = new DataSet("DataSet1");
            String[] nombresRegistros = { "CPU", "TIME" };
            dataSet.CargarRegistrosVARDEF(nombresRegistros);
            IDictionary<String, float> grupoRegistro = new Dictionary<String, float>();
            grupoRegistro.Add("CPU", 1);
            grupoRegistro.Add("TIME", 2);
            dataSet.AddGrupoRegistro(grupoRegistro);
            dataSetService.GetRegistro(dataSet, "CPU");
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetRegistroNoExisteRegistroTest()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = new DataSet("DataSet1");
            String[] nombresRegistros = { "CPU", "TIME" };
            dataSet.CargarRegistrosVARDEF(nombresRegistros);
            IDictionary<String, float> grupoRegistro = new Dictionary<String, float>();
            grupoRegistro.Add("CPU", 1);
            grupoRegistro.Add("TIME", 2);
            dataSet.AddGrupoRegistro(grupoRegistro);
            dataSetService.GetRegistro(dataSet, "Registro1");
        }

        [TestMethod]
        public void GetNombreDataSetTest()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = new DataSet("DataSet1");
            String nombre = dataSetService.GetNombreDataSet(dataSet);
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetNombreDataSetNoExisteDataSetTest()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = null;
            dataSetService.GetNombreDataSet(dataSet);
        }
      
        [TestMethod]
        public void GetNombreRegistrosDataSetTest()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = new DataSet("DataSet1");
            String[] nombresRegistros = { "CPU", "TIME" };
            dataSet.CargarRegistrosVARDEF(nombresRegistros);
            IDictionary<String, float> grupoRegistro = new Dictionary<String, float>();
            grupoRegistro.Add("CPU", 1);
            grupoRegistro.Add("TIME", 2);
            dataSet.AddGrupoRegistro(grupoRegistro);
            dataSetService.GetNombreRegistrosDataSet(dataSet);
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetNombresRegistrosDataSetNoExisteDataSetTest()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = null;
            dataSetService.GetNombreRegistrosDataSet(dataSet);
        }


        [TestMethod]
        public void GetRegistroAtIndexTest()
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
            dataSetService.GetRegistroAtIndex(dataSet,1);
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetRegistroAtIndexNoExisteDataSetTest()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = new DataSet("DataSet1");
            dataSetService.GetRegistroAtIndex(dataSet, 1);
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetRegistroAtIndexNoExisteRegistroTest()
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
            dataSetService.GetRegistroAtIndex(dataSet, 3);
        }
        [TestMethod]
        public void GetNombreRegistroAtIndexTest()
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
            dataSetService.GetNombreRegistroAtIndex(dataSet, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetNombreAtIndexNoExisteDataSetTest()
        {
            IDataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = new DataSet("DataSet1");
            dataSetService.GetNombreRegistroAtIndex(dataSet, 1);
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public void GetNombreAtIndexNoExisteRegistroTest()
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
            dataSetService.GetRegistroAtIndex(dataSet, 3);
        }
      
    }
}
