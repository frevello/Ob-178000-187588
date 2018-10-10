using System.Collections.Generic;

namespace Dominio
{
    public class VariablesDataSet
    {
        public string nombreVariable;
        public List<float> time;
        public List<float> variable;

        public VariablesDataSet(string nombre)
        {
            nombreVariable = nombre;
            time = new List<float>();
            variable = new List<float>();
        }

    }
}
