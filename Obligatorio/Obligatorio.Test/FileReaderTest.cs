using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using Excepciones;

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
    }
}
