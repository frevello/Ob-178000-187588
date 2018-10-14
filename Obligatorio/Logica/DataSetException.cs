using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DataSetException: Exception
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
