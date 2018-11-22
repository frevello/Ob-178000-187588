using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosCsv
{
    public class ValidatorFormatCsvException : Exception
    {
        public ValidatorFormatCsvException(String mensaje) : base(mensaje)
        {
        }
    }
}
