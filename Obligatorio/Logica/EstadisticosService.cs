﻿using InterfazUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using InterfazServiceUI;

namespace Logica
{
    public class EstadisticosService : IEstadisticosService
    {
        public int GetCantidadRegistros(DataSet dataSet)
        {
            TryValidarExisteDataSetYRegistro(dataSet);
            return dataSet.GetRegistros().Count();
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
        private void TryExiteDataSet(DataSet dataSet)
        {
            if (dataSet == null)
            {
                throw new DataSetServiceException("ERROR: DataSet no existe");
            }
        }
        public float GetMaximoRegistro(DataSet dataSet, string nombreRegistro)
        {
            IDataSetService dataSetService = new DataSetService();
            VariablesDataSet variableDataSet = dataSetService.GetRegistro(dataSet, nombreRegistro);
            ValidarExistenDatosRegistro(variableDataSet);
            return variableDataSet.GetDatosRegistro().Max();
        }

        public float GetMinimoRegistro(DataSet dataSet, string nombreRegistro)
        {
            IDataSetService dataSetService = new DataSetService();
            VariablesDataSet variableDataSet = dataSetService.GetRegistro(dataSet, nombreRegistro);
            ValidarExistenDatosRegistro(variableDataSet);
            return variableDataSet.GetDatosRegistro().Min();
        }

        public float GetPromedioRegistro(DataSet dataSet, String nombreRegistro)
        {
            IDataSetService dataSetService = new DataSetService();
            VariablesDataSet variableDataSet = dataSetService.GetRegistro(dataSet, nombreRegistro);
            ValidarExistenDatosRegistro(variableDataSet);
            return variableDataSet.GetDatosRegistro().Average();
        }
        private void ValidarExistenDatosRegistro(VariablesDataSet variableDataSet)
        {
            TryGetDatosRegistro(variableDataSet);
            TryValidarExisteDatosRegistro(variableDataSet.GetDatosRegistro());
        }

        private void TryValidarExisteDatosRegistro(IEnumerable<float> datosRegistro)
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
                IEnumerable<float> datosRegistro = variableDataSet.GetDatosRegistro();
            }
            catch (Exception)
            {
                throw new DataSetServiceException("ERROR: No Existe variablesDataSet");
            }
        }
    }
}
