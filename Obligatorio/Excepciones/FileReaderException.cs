using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
   public class FileReaderException: Exception
    {
        private const string MESSAGE = "ERROR AL LEER EL ARCHIVO";
        public FileReaderException() : base(MESSAGE)
        {
        }

        public FileReaderException(String mensaje) : base(mensaje)
        {
        }

        public FileReaderException(Exception innerException) : base(MESSAGE, innerException)
        {
        }

    }
}
