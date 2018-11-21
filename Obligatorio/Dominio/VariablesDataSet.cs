using System;
using System.Collections.Generic;

namespace Dominio
{
    public class VariablesDataSet
    {
        private String nombreVariable;
        private List<float> datosRegistro;
        private Boolean ordenado;

        public VariablesDataSet(String nombre, Boolean esOrdenado = false)
        {
            nombreVariable = nombre;
            datosRegistro = new List<float>();
            ordenado = esOrdenado;
        }

        public String GetNombreVariable()
        {
            return this.nombreVariable;
        }
        public void SetNombreVariable(String nombre)
        {
            this.nombreVariable = nombre;
        }
        public Boolean GetOrdenado()
        {
            return this.ordenado;
        }
        public void SetOrdenado(Boolean ordenado)
        {
            this.ordenado = ordenado;
        }
        public IEnumerable<float> GetDatosRegistro()
        {
            return this.datosRegistro;
        }
        public void AddDdatosRegistro(float datoRegistro)
        {
            this.datosRegistro.Add(datoRegistro);
        }
    }
}
