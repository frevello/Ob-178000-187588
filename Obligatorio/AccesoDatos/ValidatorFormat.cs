
using Dominio;
using System;
using System.Collections.Generic;

namespace AccesoDatos
{
    public class ValidatorFormat
    {
        private const String VARDEF = "VARDEF";
        private const String FIN_GRUPO_REGISTRO = "#";
        private const char SEPARADOR_REGISTRO_DE_DATO = '=';
        private const char SEPARADOR_DE_REGISTROS_EN_VARDEF = ',';

        
        public void ValidarPrimeraLinea(String line)
        {
            ValidarLineaContieneVARDEF(line);
            ValidarLineaContieneUnicoSeparadorDeDato(line);
        }


        private void ValidarLineaContieneVARDEF(String line)
        {
            if (!line.StartsWith(VARDEF))
            {
                throw new FileReaderException("ERROR: Falta VARDEF");
            }
        }

        public void ValidarRegistro(String line)
        {
            if (line != null && !line.Equals(FIN_GRUPO_REGISTRO))
            {
                ValidarLineaContieneUnicoSeparadorDeDato(line);
            }
            
            if (line == null)
            {
                throw new FileReaderException("ERROR: en linea falta fin del registro");
            }

        }
         private void ValidarLineaContieneUnicoSeparadorDeDato(String line)
        {
            String[] datos = line.Split(SEPARADOR_REGISTRO_DE_DATO);
            if(datos.Length != 2)
            {
                throw new FileReaderException("ERROR: Linea debe tener un unico separador" + SEPARADOR_REGISTRO_DE_DATO);
            }
        }

       
    }
}
