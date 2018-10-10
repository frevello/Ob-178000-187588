using System;

namespace Logica
{
    public class UsuarioServiceException : Exception
    {
        private const string MESSAGE = "ERROR AL CREAR USUARIO";
        public UsuarioServiceException() : base(MESSAGE)
        {
        }

        public UsuarioServiceException(String mensaje) : base(mensaje)
        {
        }

        public UsuarioServiceException(Exception innerException) : base(MESSAGE, innerException)
        {
        }

    }
}
