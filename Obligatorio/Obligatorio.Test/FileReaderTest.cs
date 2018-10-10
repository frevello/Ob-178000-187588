using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using AccesoDatos;

namespace Obligatorio.Test
{
  
    [TestClass]
    public class FileReaderTest
    {
         
        [TestMethod]
        public void FileOpenTests()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"c:/file.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void FileOpenNotExistsTests()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"c:/file2.txt");
        }

        [TestMethod]
        public void ValidarFormatoArchivoTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"c:/file.txt");
            reader.ValidarFormatoArchivo();
        }

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void ValidarFormatoArchivoSinVARDEFTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileSinVARDEF.txt");
            reader.ValidarFormatoArchivo();
        }

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void ValidarFormatoArchivoSinTIMEenVARDEFTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileSinTIMEenVARDEF.txt");
            reader.ValidarFormatoArchivo();
        }

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void ValidarFormatoArchivoSinIgualTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileSinIgual.txt");
            reader.ValidarFormatoArchivo();
        }
        

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void ValidarFormatoArchivoNoExisteVarEnVARDEFTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileVarNoExisteEnVARDEF.txt");
            reader.ValidarFormatoArchivo();
        }

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void ValidarFormatoArchivoVarNoRepetidaTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileVarRepetida.txt");
            reader.ValidarFormatoArchivo();
        }

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void ValidarFormatoArchivoFormatoDatoIncorrectoTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileDatoIncorrecto.txt");
            reader.ValidarFormatoArchivo();
        }
        
        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void ValidarFormatoArchivoFormatoNoTerminaRegistroTest()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"C:\Users\Facundo\Desktop\Files\fileNoTerminaRegistro.txt");
            reader.ValidarFormatoArchivo();
        }

    }
}
