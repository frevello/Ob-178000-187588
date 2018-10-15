using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazServiceUI
{
    public interface IDataSetService
    {
        DataSet CargarDataSet(String path);
        IEnumerable<VariablesDataSet> GetRegistros(DataSet dataSet);
        VariablesDataSet GetRegistro(DataSet dataSet, String nombreRegistro);
        String GetNombreDataSet(DataSet dataSet);
        IEnumerable<String> GetNombreRegistrosDataSet(DataSet dataSet);
        float GetPromedioRegistro(DataSet dataSet, String nombreRegistro);
        float GetMinimoRegistro(DataSet dataSet, String nombreRegistro);
        float GetMaximoRegistro(DataSet dataSet, String nombreRegistro);
        int GetCantidadRegistros(DataSet dataSet);
        VariablesDataSet GetRegistroAtIndex(DataSet dataSet, int index);
        String GetNombreRegistroAtIndex(DataSet dataSet, int index);
    }
}
