using System;
using System.Collections.Generic;

namespace Dominio
{
    public class VariablesDataSet
    {
        public Guid Id { get; set; }
        public String nombreVariable { get; set; }
        public List<float> datosRegistro { get; set; }
        public Boolean ordenado { get; set; }

        public VariablesDataSet(String nombre, Boolean esOrdenado = false)
        {
            Id = Guid.NewGuid();
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
