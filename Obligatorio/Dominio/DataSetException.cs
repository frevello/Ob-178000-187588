using System;

namespace Dominio
{
    public class DataSetException : Exception
    {
        public DataSetException(String mensaje) : base(mensaje)
        {
        }
    }
}