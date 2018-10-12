using System;

namespace AccesoDatos
{
    public class ValidatorFormatException : Exception
    {
        private const string MESSAGE = "ERROR FORMATO NO VALIDO";
        public ValidatorFormatException() : base(MESSAGE)
        {
        }

        public ValidatorFormatException(String mensaje) : base(mensaje)
        {
        }

        public ValidatorFormatException(Exception innerException) : base(MESSAGE, innerException)
        {
        }
    
    }
}
