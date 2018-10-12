using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio
{
    public class DataSet
    {
        private String nombre;
        private List<String> nombreRegistros;
        private List<VariablesDataSet> registros;
        private const String REGISTRO_TIME = "TIME";
        

        public DataSet(String path)
        {
            nombre = path;
            nombreRegistros = new List<String>();
            registros = new List<VariablesDataSet>();
        }

        public void CargarRegistrosVARDEF(String[] registrosVARDEF)
        {
            ValidarExisteRegistroTIME(registrosVARDEF);
            AddNombresRegistros(registrosVARDEF);
        }

        private void ValidarExisteRegistroTIME(String[] registrosVARDEF)
        {
            if (!registrosVARDEF.Contains(REGISTRO_TIME)){
                throw new DataSetException("ERROR: No esta definido el registro TIME");
            }
        }

        private void AddNombresRegistros(String[] registrosVARDEF)
        {
            for (int i = 0; i < registrosVARDEF.Length; i++)
            {
                nombreRegistros.Add(registrosVARDEF[i]);
            }
        }

        public void AddGrupoRegistro(IDictionary<String, float> grupoRegistro)
        {
            ValidarTodosLosRegistrosExisten(grupoRegistro);
            AddTodosLosRegistros(grupoRegistro);
        }

        private void ValidarTodosLosRegistrosExisten(IEnumerable<KeyValuePair<String, float>> grupoRegistro)
        {
            for(int i = 0; i < grupoRegistro.Count(); i++)
            {
                KeyValuePair<String, float> registro = grupoRegistro.ElementAt(i);
                ValidarExisteNombreRegistro(registro.Key);
            }
        }

        private void ValidarExisteNombreRegistro(String nombreRegistro)
        {
            if (!ExisteNombreRegistro(nombreRegistro))
            {
                throw new DataSetException("ERROR: Nombre de Registro no existe");
            }
        }

        private Boolean ExisteNombreRegistro(String nombreRegistro)
        {
            return nombreRegistros.Contains(nombreRegistro);
        }

        private void AddTodosLosRegistros(IEnumerable<KeyValuePair<String, float>> grupoRegistro)
        {
            for (int i = 0; i < grupoRegistro.Count(); i++)
            {
                KeyValuePair<String, float> registro = grupoRegistro.ElementAt(i);
                AddRegistro(registro.Key, registro.Value);
            }
        }

        private void AddRegistro(String nombreRegistro, float datoRegistro)
        {
            AddRegistroDataSetSiNoExiste(nombreRegistro);
            AddDatoARegistoDataSet(nombreRegistro, datoRegistro);
        }

        private void AddRegistroDataSetSiNoExiste(String nombreRegistro)
        {
            if (!ExisteRegistroDataSet(nombreRegistro))
            {
                AddRegistroDataSet(nombreRegistro);
            }
        }

        private Boolean ExisteRegistroDataSet(String nombreRegistro)
        {
            return registros.Exists(r => r.nombreVariable == nombreRegistro);
        }

        private void AddRegistroDataSet(String nombreRegistro)
        {
            VariablesDataSet registro = new VariablesDataSet(nombreRegistro);
            registros.Add(registro);
        }

        private void AddDatoARegistoDataSet(String nombreRegistro, float datoRegistro)
        {
            VariablesDataSet registro = registros.Find(r => r.nombreVariable == nombreRegistro);
            SiRegistroEsOredenadoValidar(registro, datoRegistro);
            registro.datosRegistro.Add(datoRegistro);
        }

        private void SiRegistroEsOredenadoValidar(VariablesDataSet registro, float datoRegistro)
        {
            if (registro.ordenado && registro.datosRegistro != null)
            {
                ValidarDatoRegistroOrdenado(registro, datoRegistro);
            }
        }

        private void ValidarDatoRegistroOrdenado(VariablesDataSet registro, float datoRegistro)
        {
            float lastDato = ObtenerLastDatoDeRegistroDataSet(registro, datoRegistro);
            if(lastDato > datoRegistro)
            {
                throw new DataSetException("ERROR: DataSet ordenado por" + registro.nombreVariable);
            }
        }

        private float ObtenerLastDatoDeRegistroDataSet(VariablesDataSet registro, float datoRegistro)
        {
            return registro.datosRegistro.Last();
        }
    }

   
}
