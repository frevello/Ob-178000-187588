using System;

namespace Dominio
{
    public class LargoDatoNoValidoException : Exception
    {
        public LargoDatoNoValidoException(String mensaje) : base(mensaje)
        {
        }
    }
}

