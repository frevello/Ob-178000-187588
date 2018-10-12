using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AccesoDatos
{
    public class FileReader
    {
        private StreamReader reader;
        private List<string> variables = new List<string>();
        private int nroLinea = 1;
        
        private const String TIME = "TIME";
        private const String VARDEF = "VARDEF";
        private const String FIN_REGISTRO = "#";

        public void OpenFile(string path)
        {
            try
            {
                TryOpenFile(path);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileReaderException(ex);
            }
        }

        private void TryOpenFile(string path)
        {
             reader = new StreamReader(path);
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
