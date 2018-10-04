using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    class UsuarioException: Exception
    {
        private const string MESSAGE = "ERROR AL CREAR USUARIO";

        public UsuarioException() : base(MESSAGE)
        {
        }

        public UsuarioException(String mensaje) : base(mensaje)
        {
        }

        public UsuarioException(Exception innerException) : base(MESSAGE, innerException)
        {
        }

    }
}
