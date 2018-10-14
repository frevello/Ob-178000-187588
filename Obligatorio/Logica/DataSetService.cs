using AccesoDatos;
using Dominio;
using InterfazAccesoDatos;
using InterfazServiceUI;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class DataSetService:IDataSetService
    {

        public DataSet CargarDataSet(String path)
        {
            ILoadDataSet l = new LoadDataSet(path);
            return l.CargarDataSet();
        }
        public IEnumerable<VariablesDataSet> GetRegistros(DataSet dataSet)
        {
            TryExiteDataSet(dataSet);
            return dataSet.GetRegistros();
        }

        private void TryExiteDataSet(DataSet dataSet)
        {
            if (dataSet == null)
            {
                throw new DataSetException("ERROR: DataSet no existe");
            }
        }

    }
}
