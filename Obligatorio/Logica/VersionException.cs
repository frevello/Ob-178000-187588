using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class VersionException : Exception
    {
        private const string MESSAGE = "ERROR AL CREAR VERSION";
        public VersionException() : base(MESSAGE)
        {
        }

        public VersionException(String mensaje) : base(mensaje)
        {
        }

        public VersionException(Exception innerException) : base(MESSAGE, innerException)
        {
        }

    }
}
