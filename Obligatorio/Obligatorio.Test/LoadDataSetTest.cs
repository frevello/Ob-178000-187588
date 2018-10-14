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
    }
}
