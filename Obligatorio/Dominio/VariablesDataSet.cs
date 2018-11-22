using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class VariablesDataSet
    {
        [Key]
        public Guid VariableDataSet_Id { get; set; }
        public Guid DataSet_Id { get; set; }
        public String nombreVariable { get; set; }
        public List<VariableDato> datosRegistro { get; set; }
        public Boolean ordenado { get; set; }

        public VariablesDataSet()
        {
            VariableDataSet_Id = Guid.NewGuid();
            datosRegistro = new List<VariableDato>();
        }

        public VariablesDataSet(String nombre, Boolean esOrdenado = false)
        {
            VariableDataSet_Id = Guid.NewGuid();
            nombreVariable = nombre;
            datosRegistro = new List<VariableDato>();
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
        public IEnumerable<VariableDato> GetDatosRegistro()
        {
            return this.datosRegistro;
        }
        public void AddDdatosRegistro(VariableDato datoRegistro)
        {
            this.datosRegistro.Add(datoRegistro);
        }
      
    }
}
