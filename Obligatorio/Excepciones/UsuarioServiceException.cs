using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
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
