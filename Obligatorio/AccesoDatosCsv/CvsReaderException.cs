using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosCsv
{
    public class CvsReaderException : Exception
    {
        private const string MESSAGE = "ERROR AL LEER EL ARCHIVO";
        public CvsReaderException(Exception innerException) : base(MESSAGE, innerException)
        {
        }
        public CvsReaderException(String mensaje) : base(mensaje)
        {
        }
    }
}
