using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DataSetServiceException: Exception
    {
        private const string MESSAGE = "ERROR DATASET";
        public DataSetServiceException() : base(MESSAGE)
        {
        }

        public DataSetServiceException(String mensaje) : base(mensaje)
        {
        }

        public DataSetServiceException(Exception innerException) : base(MESSAGE, innerException)
        {
        }
    }
}
