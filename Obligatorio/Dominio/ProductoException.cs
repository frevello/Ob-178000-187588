using System;

namespace Dominio
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
