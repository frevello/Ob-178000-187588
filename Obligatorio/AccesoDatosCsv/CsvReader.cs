using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosCsv
{
    public class CsvReader
    {
        private StreamReader reader;
        private const String EXTENSION_CSV = "csv";
        private const char PUNTO = '.';

        public void OpenFile(string path)
        {
            try
            {
                TryOpenFile(path);
            }
            catch (FileNotFoundException ex)
            {
                throw new CvsReaderException(ex);
            }
        }

        private void TryOpenFile(string path)
        {
            if (path.Split(PUNTO)[1].Equals(EXTENSION_CSV))
            {
                reader = new StreamReader(path);
            }
            else
            {
                throw new CvsReaderException("ERROR: Extension no soportada");
            }
            
        }


        public string GetNextLine()
        {
            return reader.ReadLine();
        }

        public void EndReading()
        {
            reader.Close();
        }
    }
}
