
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
            ValidarLineaContieneUnicoSeparadorDeDato(line);
            ValidarLineaContieneVARDEF(line);
        }


        private void ValidarLineaContieneVARDEF(String line)
        {
            String[] vardef = line.Split(SEPARADOR_REGISTRO_DE_DATO);
            if (!vardef[0].Equals(VARDEF))
            {
                throw new ValidatorFormatException("ERROR: En 1ra linea no se encontro VARDEF");
            }
        }

        public void ValidarRegistro(String line)
        {
             ValidarLineaContieneUnicoSeparadorDeDato(line);
        }

         private void ValidarLineaContieneUnicoSeparadorDeDato(String line)
        {
            String[] datos = line.Split(SEPARADOR_REGISTRO_DE_DATO);
            if(datos.Length != 2)
            {
                throw new ValidatorFormatException("ERROR: Linea debe tener un unico separador" + SEPARADOR_REGISTRO_DE_DATO);
            }
        }

        public void ValidarFinRegistroCorrecto(String line)
        {
            if (!ExisteLinea(line))
            {
                throw new ValidatorFormatException("ERROR: Falta fin del registro");
            }
        }
        public Boolean ExisteLinea(String line)
        {
            return line != null;
        }

        public Boolean EsFinGrupoRegistro(String line)
        {
            return line.Equals(FIN_GRUPO_REGISTRO);
        }
    }
}
