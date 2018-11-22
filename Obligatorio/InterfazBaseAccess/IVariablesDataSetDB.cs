using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazBaseAccess
{ 
    public interface IVariablesDataSetDB
    { 
        void AgregarVariablesDataSet(VariablesDataSet variableDataSet);
        void modificarVariablesDataSet(VariablesDataSet variableDataSet);
        bool ExisteVariablesDataSet(string nombreVariablesDataSet);
        VariablesDataSet GetVariablesDataSet(string nombreVariablesDataSet);
        List<VariablesDataSet> GetListaVariablesDataSet();
    }
}
