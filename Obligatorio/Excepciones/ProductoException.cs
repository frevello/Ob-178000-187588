using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ProductoException: Exception
    {
        private const string MESSAGE = "ERROR AL CREAR PRODUCTO";

        public ProductoException() : base(MESSAGE)
        {
        }

        public ProductoException(String mensaje) : base(mensaje)
        {
        }

        public ProductoException(Exception innerException) : base(MESSAGE, innerException)
        {
        }

    }
}
