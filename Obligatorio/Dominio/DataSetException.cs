using System;

namespace Dominio
{
    public class DataSetException : Exception
    {
        private const string MESSAGE = "ERROR DATASET";

        public DataSetException() : base(MESSAGE)
        {
        }

        public DataSetException(String mensaje) : base(mensaje)
        {
        }

        public DataSetException(Exception innerException) : base(MESSAGE, innerException)
        {
        }

    }
}