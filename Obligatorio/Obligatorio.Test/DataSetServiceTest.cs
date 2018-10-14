using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Collections.Generic;

namespace Obligatorio.Test
{
    [TestClass]
    public class DataSetServiceTest

    {
        [TestMethod]
        public void CargarDataSetTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public IEnumerable<VariablesDataSet> GetRegistrosTest(DataSet dataSet)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public IEnumerable<VariablesDataSet> GetRegistrosNoExisteDataSetTest(DataSet dataSet)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public VariablesDataSet GetRegistroTest(DataSet dataSet, String nombreRegistro)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public VariablesDataSet GetRegistroNoExisteRegistroTest(DataSet dataSet, String nombreRegistro)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public String GetNombreDataSetTest(DataSet dataSet)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public String GetNombreDataSetNoExisteDataSetTest(DataSet dataSet)
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public String GetRegistrosDataSetTest(DataSet dataSet)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public String GetRegistrosDataSetNoExisteDataSetTest(DataSet dataSet)
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public IEnumerable<String> GetNombreRegistrosDataSetTest(DataSet dataSet)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public IEnumerable<String> GetNombresRegistrosDataSetNoExisteDataSetTest(DataSet dataSet)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public float GetPromedioRegistroTest(DataSet dataSet, String nombreRegistro)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public float GetPromedioRegistroNoExiteRegistroTest(DataSet dataSet, String nombreRegistro)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public float GetMinimoRegistroTest(DataSet dataSet, String nombreRegistro)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public float GetMinimoRegistroNoExiteRegistroTest(DataSet dataSet, String nombreRegistro)
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public float GetMaximoRegistroTest(DataSet dataSet, String nombreRegistro)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public float GetMaximoRegistroNoExisteRegistroTest(DataSet dataSet, String nombreRegistro)
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public float GetCantidadRegistrosTest(DataSet dataSet)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public float GetCantidadRegistrosNoExisteTest(DataSet dataSet)
        {
            throw new NotImplementedException();
        }
    }
}
