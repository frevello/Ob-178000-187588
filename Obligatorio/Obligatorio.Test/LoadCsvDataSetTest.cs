using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfazAccesoDatos;
using AccesoDatosCsv;

namespace Obligatorio.Test
{
  
    public class LoadCsvDataSetTest
    {

        [TestMethod]
        public void ValidarFormatoTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Correcto_2.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoNoExisteCsvTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/file.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoVacioCsvTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Incorrecto_0.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoFaltanRegistrosTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Incorrecto_2.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoFaltaDatoRegistroTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Incorrecto_3.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoFaltaTIMEenVARDEFTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Incorrecto_4.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoDatoRegistroIncorrectoTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Incorrecto_11.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoDatoRegistroIncorrecto2Test()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Incorrecto_13.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoRegistroTIMEMenorACeroTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Incorrecto_10.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoTIMENoEstaPrimeroTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Incorrecto_12.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoDatoRegistroVacioTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Incorrecto_14.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoNoExisteVARDEFTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Incorrecto_15.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoVariableRepetidaVARDEFTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Incorrecto_16.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoMinimoVariablesVARDEFTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Incorrecto_17.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatCsvException))]
        public void ValidarFormatoVariableTIMEnoOrdenadaTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Incorrecto_19.csv");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        public void CargarDataSetTest()
        {
            ILoadDataSet loadDataSet = new LoadCsvDataSet(@"../../../DataSetCsv/Correcto_3.csv");
            loadDataSet.CargarDataSet();
        }
    }
}
