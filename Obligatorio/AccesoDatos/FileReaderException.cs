using System;

namespace AccesoDatos
{
   public class FileReaderException: Exception
    {
        private const string MESSAGE = "ERROR AL LEER EL ARCHIVO";
        public FileReaderException(Exception innerException) : base(MESSAGE, innerException)
        {
        }

    }
}
