using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccesoDatos;
using Logica;

namespace Obligatorio.Test
{
  
    [TestClass]
    public class FileReaderTest
    {
         
        [TestMethod]
        public void FileOpenTests()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:/Users/alumnoFI/Desktop/Files/file.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void FileOpenNotExistsTests()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:/Users/alumnoFI/Desktop/Files/file2.txt");
        }

        [TestMethod]
        public void CargarDataSetTest()
        {
            DataSetService dataSet = new DataSetService();
            dataSet.CargarDataSet(@"C:/Users/alumnoFI/Desktop/Files/file.txt");
        }
        /*
        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void CargarDataSetSinVARDEFTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileSinVARDEF.txt");
            reader.ValidarFormatoArchivo();
        }

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void CargarDataSetSinTIMEenVARDEFTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileSinTIMEenVARDEF.txt");
            reader.ValidarFormatoArchivo();
        }

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void CargarDataSetSinIgualTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileSinIgual.txt");
            reader.ValidarFormatoArchivo();
        }
        

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void CargarDataSetNoExisteVarEnVARDEFTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileVarNoExisteEnVARDEF.txt");
            reader.ValidarFormatoArchivo();
        }

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void CargarDataSetConVarRepetidaTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileVarRepetida.txt");
            reader.ValidarFormatoArchivo();
        }

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void CargarDataSetFormatoDatoIncorrectoTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileDatoIncorrecto.txt");
            reader.ValidarFormatoArchivo();
        }
        
        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void CargarDataSetRegistroNoTerminaTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileNoTerminaRegistro.txt");
            reader.ValidarFormatoArchivo();
        }*/

    }
}
