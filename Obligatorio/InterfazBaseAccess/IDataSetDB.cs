using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazBaseAccess
{
    public interface IDataSetDB
    { 
        void AgregarDataSet(DataSet dataSet);
        void modificarDataSet(DataSet dataSet);
        bool ExisteDataSet(string nombreProducto);
        DataSet GetDataSet(string nombreProducto);
        List<DataSet> GetListaDataSet();
        List<VariablesDataSet> GetRegistros(string nombreDataSet);
    }
}
