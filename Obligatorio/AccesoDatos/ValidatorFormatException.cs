using System;

namespace AccesoDatos
{
    public class ValidatorFormatException : Exception
    {
        public ValidatorFormatException(String mensaje) : base(mensaje)
        {
        }
    }
}
