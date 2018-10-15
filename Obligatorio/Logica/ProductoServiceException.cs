using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ProductoServiceException : Exception
    {
        public ProductoServiceException(String mensaje) : base(mensaje)
        {
        }
    }
}
