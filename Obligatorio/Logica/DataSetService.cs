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
            return registros.FirstOrDefault(r => r.nombreVariable == nombreRegistro);
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
            if (registros.FirstOrDefault(r => r.nombreVariable == nombreRegistro) == null)
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

        public float GetPromedioRegistro(DataSet dataSet, String nombreRegistro)
        {
            VariablesDataSet variableDataSet = GetRegistro(dataSet, nombreRegistro);
            ValidarExistenDatosRegistro(variableDataSet);
            return variableDataSet.datosRegistro.Average();
        }
        public float GetMinimoRegistro(DataSet dataSet, String nombreRegistro)
        {
            VariablesDataSet variableDataSet = GetRegistro(dataSet, nombreRegistro);
            ValidarExistenDatosRegistro(variableDataSet);
            return variableDataSet.datosRegistro.Min();
        }
        public float GetMaximoRegistro(DataSet dataSet, String nombreRegistro)
        {
            VariablesDataSet variableDataSet = GetRegistro(dataSet, nombreRegistro);
            ValidarExistenDatosRegistro(variableDataSet);
            return variableDataSet.datosRegistro.Max();
        }

        public int GetCantidadRegistros(DataSet dataSet)
        {
            TryValidarExisteDataSetYRegistro(dataSet);
            return dataSet.GetRegistros().Count();
        }
        private void TryExiteDataSet(DataSet dataSet)
        {
            if (dataSet == null)
            {
                throw new DataSetServiceException("ERROR: DataSet no existe");
            }
        }
       
        private void ValidarExistenDatosRegistro(VariablesDataSet variableDataSet)
        {
            TryGetDatosRegistro(variableDataSet);
            TryValidarExisteDatosRegistro(variableDataSet.datosRegistro);
        }

        private void TryValidarExisteDatosRegistro(List<float> datosRegistro)
        {
            try
            {
                float avarage = datosRegistro.Average();
            }
            catch (Exception)
            {
                throw new DataSetServiceException("ERROR: No Existen Datos en el Registro");
            }
        }
        private void TryGetDatosRegistro(VariablesDataSet variableDataSet)
        {
            try
            {
                List<float> datosRegistro = variableDataSet.datosRegistro;
            }
            catch(Exception)
            {
                throw new DataSetServiceException("ERROR: No Existe variablesDataSet");
            }
        }

    }
}
