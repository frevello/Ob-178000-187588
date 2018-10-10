using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ProductoServiceException : Exception
    {
        private const string MESSAGE = "ERROR AL CREAR PRODUCTO";
        public ProductoServiceException() : base(MESSAGE)
        {
        }

        public ProductoServiceException(String mensaje) : base(mensaje)
        {
        }

        public ProductoServiceException(Exception innerException) : base(MESSAGE, innerException)
        {
        }
    }
}
