using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio
{
    public class DataSet
    {
        private String nombre;
        private List<String> nombreRegistros;
        private List<VariablesDataSet> registros;
        private const String REGISTRO_TIME = "TIME";
        

        public DataSet(String path)
        {
            nombre = path;
            nombreRegistros = new List<String>();
            registros = new List<VariablesDataSet>();
        }

        public void CargarRegistrosVARDEF(String[] registrosVARDEF)
        {
            ValidarExisteRegistroTIME(registrosVARDEF);
            AddNombresRegistros(registrosVARDEF);

        }


        private void ValidarExisteRegistroTIME(String[] registrosVARDEF)
        {
            if (registrosVARDEF.Contains(REGISTRO_TIME)){
                throw new FieldAccessException("ERROR: No esta definido el registro TIME");
            }
        }

        private void AddNombresRegistros(String[] registrosVARDEF)
        {
            for (int i = 0; i < registrosVARDEF.Length; i++)
            {
                nombreRegistros.Add(registrosVARDEF[i]);
            }
        }

    }

   
}
