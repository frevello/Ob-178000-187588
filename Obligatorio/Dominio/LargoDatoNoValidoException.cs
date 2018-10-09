using InterfazUI;
using System;

namespace Dominio
{
    class LargoDatoNoValidoException : UsuarioException
    {
        private const string MESSAGE = "ERROR LARGO DATO NO VALIDO";

        public LargoDatoNoValidoException() : base(MESSAGE)
        {
        }

        public LargoDatoNoValidoException(String mensaje) : base(mensaje)
        {
        }

        public LargoDatoNoValidoException(Exception innerException) : base(MESSAGE, innerException)
        {
        }

    }
}

