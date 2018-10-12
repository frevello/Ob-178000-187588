using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VersionEtiquetaException : Exception
    {
        private const string MESSAGE = "ERROR EN LA ETIQUETA";

        public VersionEtiquetaException() : base(MESSAGE)
        {
        }

        public VersionEtiquetaException(String mensaje) : base(mensaje)
        {
        }

        public VersionEtiquetaException(Exception innerException) : base(MESSAGE, innerException)
        {
        }
    }
}
