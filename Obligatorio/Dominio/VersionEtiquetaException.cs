using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VersionEtiquetaException : Exception
    {
        public VersionEtiquetaException(String mensaje) : base(mensaje)
        {
        }
    }
}
