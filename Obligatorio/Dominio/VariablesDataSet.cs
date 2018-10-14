using System;
using System.Collections.Generic;

namespace Dominio
{
    public class VariablesDataSet
    {
        public String nombreVariable;
        public List<float> datosRegistro;
        public Boolean ordenado;

        public VariablesDataSet(String nombre, Boolean esOrdenado = false)
        {
            nombreVariable = nombre;
            datosRegistro = new List<float>();
            ordenado = esOrdenado;
        }




    }
}
