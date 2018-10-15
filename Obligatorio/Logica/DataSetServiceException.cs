using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DataSetServiceException: Exception
    {
        public DataSetServiceException(String mensaje) : base(mensaje)
        {
        }
    }
}
