using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class VersionException : Exception
    {
        public VersionException(String mensaje) : base(mensaje)
        {
        }
    }
}
