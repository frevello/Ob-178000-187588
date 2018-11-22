using AccesoDatos;
using Dominio;
using InterfazAccesoDatos;
using InterfazServiceUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class DataSetService:IDataSetService
    {

        public IEnumerable<VariablesDataSet> GetRegistros(DataSet dataSet)
        {
            TryExiteDataSet(dataSet);
            return dataSet.GetRegistros();
        }

        public VariablesDataSet GetRegistro(DataSet dataSet, String nombreRegistro)
        {
            TryValidarExisteDataSetYRegistro(dataSet);
            return GetRegistroDeDataSet(dataSet, nombreRegistro);
        }
        public VariablesDataSet GetRegistroAtIndex(DataSet dataSet, int index)
        {
            TryValidarExisteDataSetYRegistro(dataSet);
            return GetRegistroAtIndexDeDataSet(dataSet, index);
        }
        public String GetNombreRegistroAtIndex(DataSet dataSet, int index)
        {
            TryValidarExisteDataSetYRegistro(dataSet);
            return GetNombreRegistroAtIndexDeDataSet(dataSet, index);
        }
        private void TryValidarExisteDataSetYRegistro(DataSet dataSet)
        {
            TryExiteDataSet(dataSet);
            TryExiteRegistros(dataSet);
        }
       
        private void TryExiteRegistros(DataSet dataSet)
        {
            if (dataSet.GetRegistros() == null)
            {
                throw new DataSetServiceException("ERROR: Registro en DataSet no existe");
            }
        }
        private VariablesDataSet GetRegistroDeDataSet(DataSet dataSet, String nombreRegistro)
        {
            IEnumerable<VariablesDataSet> registros = GetRegistros(dataSet);
            ValidarExisteRegistro(registros, nombreRegistro);
            return registros.FirstOrDefault(r => r.GetNombreVariable() == nombreRegistro);
        }

        private VariablesDataSet GetRegistroAtIndexDeDataSet(DataSet dataSet, int index)
        {
            IEnumerable<VariablesDataSet> registros = GetRegistros(dataSet);
            ValidarExisteRegistroAtIndex(registros, index);
            return registros.ElementAt(index);
        }
        private String GetNombreRegistroAtIndexDeDataSet(DataSet dataSet, int index)
        {
            IEnumerable<String> nombresRegistros = GetNombreRegistrosDataSet(dataSet);
            ValidarExisteNombreRegistroAtIndex(nombresRegistros, index);
            return nombresRegistros.ElementAt(index);
        }
        private void ValidarExisteRegistro(IEnumerable<VariablesDataSet> registros, String nombreRegistro)
        {
            if (registros.FirstOrDefault(r => r.GetNombreVariable() == nombreRegistro) == null)
            {
                throw new DataSetServiceException("ERROR: no existe registro");
            }
        }
        private void ValidarExisteRegistroAtIndex(IEnumerable<VariablesDataSet> registros, int index)
        {
            if (registros.Count() <= index)
            {
                throw new DataSetServiceException("ERROR: no existe registro");
            }
        }
        private void ValidarExisteNombreRegistroAtIndex(IEnumerable<String> nombreRegistros, int index)
        {
            if (nombreRegistros.Count() <= index)
            {
                throw new DataSetServiceException("ERROR: no existe registro");
            }
        }
        public String GetNombreDataSet(DataSet dataSet)
        {
            TryExiteDataSet(dataSet);
            return dataSet.GetNombre();
        }
      
        public IEnumerable<String> GetNombreRegistrosDataSet(DataSet dataSet)
        {
            TryExiteDataSet(dataSet);
            return dataSet.GetNomresRegistros();
        }

        private void TryExiteDataSet(DataSet dataSet)
        {
            if (dataSet == null)
            {
                throw new DataSetServiceException("ERROR: DataSet no existe");
            }
        }
    }
}
