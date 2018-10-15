using System;

namespace Logica
{
    public class UsuarioServiceException : Exception
    {
        public UsuarioServiceException(String mensaje) : base(mensaje)
        {
        }
    }
}
