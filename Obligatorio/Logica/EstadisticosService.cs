using InterfazUI;
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
        private const String TIME = "TIME";
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

        public float GetPromedioRegistroDesdeHasta(DataSet dataSet, string nombreRegistro, float timeDesde, float timeHasta)
        {
            IEnumerable<float> datosFiltrados = GetDatosRegistroFiltrado(dataSet, nombreRegistro, timeDesde, timeHasta);
            return GetPromedioFiltrado(datosFiltrados);
        }

        public float GetMinimoRegistroDesdeHasta(DataSet dataSet, string nombreRegistro, float timeDesde, float timeHasta)
        {
            IEnumerable<float> datosFiltrados = GetDatosRegistroFiltrado(dataSet, nombreRegistro, timeDesde, timeHasta);
            return GetMinimoFiltrado(datosFiltrados);
        }

        public float GetMaximoRegistroDesdeHasta(DataSet dataSet, string nombreRegistro, float timeDesde, float timeHasta)
        {
            IEnumerable<float> datosFiltrados = GetDatosRegistroFiltrado(dataSet, nombreRegistro, timeDesde, timeHasta);
            return GetMaximoFiltrado(datosFiltrados);
        }

        private IEnumerable<float> GetDatosRegistroFiltrado(DataSet dataSet, string nombreRegistro, float timeDesde, float timeHasta)
        {
            ValidarTimeDesdeMenorHasta(timeDesde, timeHasta);
            IDataSetService dataSetService = new DataSetService();
            VariablesDataSet variableDataSet = dataSetService.GetRegistro(dataSet, nombreRegistro);
            int indexDesde = GetIndexTimeDesde(dataSet, timeDesde);
            int indexHasta = GetIndexTimeHasta(dataSet, timeHasta);
            return GetListaFiltrada(variableDataSet.GetDatosRegistro(), indexDesde, indexHasta);
        }
        private void ValidarTimeDesdeMenorHasta(float timeDesde, float timeHasta)
        {
            if(timeDesde >= timeHasta)
            {
                throw new EstadisticosServiceException("El filtro desde debe ser mayor al filtro hasta");
            }
        }
        private IEnumerable<float> GetListaFiltrada(IEnumerable<float> datos, int desde, int hasta)
        {
            if (desde != -1 && hasta != -1)
            {
                return datos.ToList().GetRange(desde, hasta - desde + 1);
            }
            return null;
        }
        private int GetIndexTimeDesde(DataSet dataSet, float timeDesde)
        {
            IDataSetService dataSetService = new DataSetService();
            VariablesDataSet variableDataSet = dataSetService.GetRegistro(dataSet, TIME);
            if(timeDesde <= GetMaximoRegistro(dataSet, TIME))
            {
                float desde = GetFirstIgualoMayor(variableDataSet.GetDatosRegistro(), timeDesde);
                float[] registros = variableDataSet.GetDatosRegistro().ToArray();
                return Array.IndexOf(registros, desde);
            }
            return -1;
        }

        private float GetFirstIgualoMayor(IEnumerable<float> time, float timeDesde)
        {
            return time.FirstOrDefault(d => d >= timeDesde);
        }
        private int GetIndexTimeHasta(DataSet dataSet, float timeHasta)
        {
            IDataSetService dataSetService = new DataSetService();
            VariablesDataSet variableDataSet = dataSetService.GetRegistro(dataSet, TIME);
            if (timeHasta >= GetMinimoRegistro(dataSet, TIME))
            {
                float desde = GetLastIgualoMenor(variableDataSet.GetDatosRegistro(), timeHasta);
                float[] registros = variableDataSet.GetDatosRegistro().ToArray();
                return Array.IndexOf(registros, desde);
            }
            return -1;
        }
        private float GetLastIgualoMenor(IEnumerable<float> time, float timeHasta)
        {
            return time.LastOrDefault(d => d <= timeHasta);
        }
        private float GetPromedioFiltrado(IEnumerable<float> datosRegistro)
        {
            try
            {
                return datosRegistro.Average();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        private float GetMaximoFiltrado(IEnumerable<float> datosRegistro)
        {
            try
            {
                return datosRegistro.Max();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        private float GetMinimoFiltrado(IEnumerable<float> datosRegistro)
        {
            try
            {
                return datosRegistro.Min();
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
