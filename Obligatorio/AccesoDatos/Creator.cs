using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Creator
    {
        private DataSet dataSet;
        private const char SEPARADOR_REGISTRO_DE_DATO = '=';
        private const char SEPARADOR_DE_REGISTROS_EN_VARDEF = ',';

        public Creator(String path)
        {
            dataSet = new DataSet(path);
        }

        public void cargarRegistrosVARDEF(String line)
        {
            String[] registrosVARDEF = ObtenerRegistrosVARDEF(line);
            dataSet.CargarRegistrosVARDEF(registrosVARDEF);
        }

        private String[] ObtenerRegistrosVARDEF(String line)
        {
            line = EliminarDeLineaVARDEF(line);
            return SplitRegistrosVARDEF(line);
        }

        private String EliminarDeLineaVARDEF(String line)
        {
            String[] lineSinVARDEF = line.Split(SEPARADOR_REGISTRO_DE_DATO);
            return lineSinVARDEF[1];
        }
        private String[] SplitRegistrosVARDEF(String line)
        {
            return line.Split(SEPARADOR_DE_REGISTROS_EN_VARDEF);
        }



    }
}
