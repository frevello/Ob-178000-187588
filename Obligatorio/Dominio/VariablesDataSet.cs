using System.Collections.Generic;

namespace Dominio
{
    public class VariablesDataSet
    {
        public string nombreVariable;
        public List<float> registro;

        public VariablesDataSet(string nombre)
        {
            nombreVariable = nombre;
            registro = new List<float>();
        }

    }
}
