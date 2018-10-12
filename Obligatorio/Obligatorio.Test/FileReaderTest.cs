using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            reader.OpenFile(@"../../../DataSetFiles/file.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(FileReaderException))]
        public void FileOpenNotExistsTests()
        {
            FileReader reader = new FileReader();
            reader.OpenFile(@"../../../DataSetFiles/file2.txt");
        }

    }
}
