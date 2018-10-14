using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Collections.Generic;
using Logica;

namespace Obligatorio.Test
{
    [TestClass]
    public class DataSetServiceTest

    {
        [TestMethod]
        public void CargarDataSetTest()
        {
            DataSetService dataSet = new DataSetService();
            dataSet.CargarDataSet(@"../../../DataSetFiles/file.txt");
        }

        [TestMethod]
        public IEnumerable<VariablesDataSet> GetRegistrosTest()
        {
            DataSetService dataSetService = new DataSetService();
            Dominio.DataSet dataSet = new DataSet("DataSet1");
            return dataSetService.GetRegistros(dataSet);
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public IEnumerable<VariablesDataSet> GetRegistrosNoExisteDataSetTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public VariablesDataSet GetRegistroTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public VariablesDataSet GetRegistroNoExisteRegistroTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public String GetNombreDataSetTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public String GetNombreDataSetNoExisteDataSetTest()
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public String GetRegistrosDataSetTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public String GetRegistrosDataSetNoExisteDataSetTest()
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public IEnumerable<String> GetNombreRegistrosDataSetTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public IEnumerable<String> GetNombresRegistrosDataSetNoExisteDataSetTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public float GetPromedioRegistroTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public float GetPromedioRegistroNoExiteRegistroTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public float GetMinimoRegistroTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public float GetMinimoRegistroNoExiteRegistroTest()
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public float GetMaximoRegistroTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public float GetMaximoRegistroNoExisteRegistroTest()
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public float GetCantidadRegistrosTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetServiceException))]
        public float GetCantidadRegistrosNoExisteTest()
        {
            throw new NotImplementedException();
        }
    }
}
