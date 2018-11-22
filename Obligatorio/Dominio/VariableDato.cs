using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VariableDato
    {
        [Key]
        public Guid VariableDato_Id { get; set; }
        public Guid VariableDataSet_Id { get; set; }
        public float dato { get; set; }
        public VariableDato()
        {
            VariableDato_Id = Guid.NewGuid();
        }
        public VariableDato(float dato)
        {
            VariableDato_Id = Guid.NewGuid();
            this.dato = dato;
        }
    }
}
