using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AccesoDatos
{
    public class FileReader
    {
        private StreamReader reader;

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
