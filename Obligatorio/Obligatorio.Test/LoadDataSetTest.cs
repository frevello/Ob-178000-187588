using AccesoDatos;
using Dominio;
using InterfazAccesoDatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Obligatorio.Test
{
    [TestClass]
    public class LoadDataSetTest
    {
        [TestMethod]
        public void CargarDataSetTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/file.txt");
            loadDataSet.CargarDataSet();
        }
        
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatException))]
        public void CargarDataSetSinVARDEFTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileSinVARDEF.txt");
            loadDataSet.CargarDataSet();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void CargarDataSetSinTIMEenVARDEFTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileSinTIMEenVARDEF.txt");
            loadDataSet.CargarDataSet();
        }

        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatException))]
        public void CargarDataSetSinIgualTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileSinIgual.txt");
            loadDataSet.CargarDataSet();
        }
        

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void CargarDataSetNoExisteVarEnVARDEFTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileVarNoExisteEnVARDEF.txt");
            loadDataSet.CargarDataSet();
        }

        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatException))]
        public void CargarDataSetConVarRepetidaTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileVarRepetida.txt");
            loadDataSet.CargarDataSet();
        }

        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatException))]
        public void CargarDataSetFormatoDatoIncorrectoTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileDatoIncorrecto.txt");
            loadDataSet.CargarDataSet();
        }
       
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatException))]
        public void CargarDataSetRegistroNoTerminaTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileNoTerminaRegistro.txt");
            loadDataSet.CargarDataSet();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void CargarDataSetRegistroTimeNoOrdenadoTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileTimeNoOrdenado.txt");
            loadDataSet.CargarDataSet();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void CargarDataSetSinElMinimoDeRegistrosTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileSinMinimoRegistros.txt");
            loadDataSet.CargarDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void CargarDataSetTimeMenorQueCeroTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileTimeMenorQueCero.txt");
            loadDataSet.CargarDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void CargarDataSetCantidadRegistrosMenorA2Test()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileCantidadRegistrosMenor.txt");
            loadDataSet.CargarDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void CargarDataSetSinRegistrosTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileSinRegistros.txt");
            loadDataSet.CargarDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void CargarDataSetFaltaVariableEnRegistroTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileFaltaVariableEnRegistro.txt");
            loadDataSet.CargarDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatException))]
        public void CargarDataSetVARDEFmalDefnidoTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileVARDEFmalDefinido.txt");
            loadDataSet.CargarDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void CargarDataSetVARDEFFaltaVariablesTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileVARDEFfaltaVar.txt");
            loadDataSet.CargarDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void CargarDataSetVARDEFFaltaVariablesFinalTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileVARDEFfaltaVarFinal.txt");
            loadDataSet.CargarDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void CargarDataSetVARDEFRegistroRepetidoTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileVARDEFregistroReptido.txt");
            loadDataSet.CargarDataSet();
        }
        [TestMethod]
        public void ValidarFormatoTxtTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/file.txt");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatException))]
        public void ValidarFormatoTxtSinVARDEFTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileSinVARDEF.txt");
            loadDataSet.ValidarFormatoDataSet();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void ValidarFormatoTxtSinTIMEenVARDEFTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileSinTIMEenVARDEF.txt");
            loadDataSet.ValidarFormatoDataSet();
        }

        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatException))]
        public void ValidarFormatoTxtSinIgualTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileSinIgual.txt");
            loadDataSet.ValidarFormatoDataSet();
        }
        

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void ValidarFormatoTxtNoExisteVarEnVARDEFTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileVarNoExisteEnVARDEF.txt");
            loadDataSet.ValidarFormatoDataSet();
        }

        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatException))]
        public void ValidarFormatoTxtConVarRepetidaTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileVarRepetida.txt");
            loadDataSet.ValidarFormatoDataSet();
        }

        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatException))]
        public void ValidarFormatoTxtFormatoDatoIncorrectoTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileDatoIncorrecto.txt");
            loadDataSet.ValidarFormatoDataSet();
        }
       
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatException))]
        public void ValidarFormatoTxtRegistroNoTerminaTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileNoTerminaRegistro.txt");
            loadDataSet.ValidarFormatoDataSet();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void ValidarFormatoTxtRegistroTimeNoOrdenadoTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileTimeNoOrdenado.txt");
            loadDataSet.ValidarFormatoDataSet();
        }

        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void ValidarFormatoTxtSinElMinimoDeRegistrosTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileSinMinimoRegistros.txt");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void ValidarFormatoTxtTimeMenorQueCeroTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileTimeMenorQueCero.txt");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void ValidarFormatoTxtCantidadRegistrosMenorA2Test()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileCantidadRegistrosMenor.txt");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void ValidarFormatoTxtSinRegistrosTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileSinRegistros.txt");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void ValidarFormatoTxtFaltaVariableEnRegistroTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileFaltaVariableEnRegistro.txt");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(ValidatorFormatException))]
        public void ValidarFormatoTxtVARDEFmalDefnidoTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileVARDEFmalDefinido.txt");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void ValidarFormatoTxtVARDEFFaltaVariablesTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileVARDEFfaltaVar.txt");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void ValidarFormatoTxtVARDEFFaltaVariablesFinalTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileVARDEFfaltaVarFinal.txt");
            loadDataSet.ValidarFormatoDataSet();
        }
        [TestMethod]
        [ExpectedException(typeof(DataSetException))]
        public void ValidarFormatoTxtVARDEFRegistroRepetidoTest()
        {
            ILoadDataSet loadDataSet = new LoadDataSet(@"../../../DataSetFiles/fileVARDEFregistroReptido.txt");
            loadDataSet.ValidarFormatoDataSet();
        }
    }
}
