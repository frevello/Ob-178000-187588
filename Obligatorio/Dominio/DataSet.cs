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
        private const int MINIMO_NOMBRES_REGISTROS = 2;
        private const int MINIMO_REGISTROS = 2;

        public DataSet(String path)
        {
            nombre = path;
            nombreRegistros = new List<String>();
            registros = new List<VariablesDataSet>();
        }

        public void CargarRegistrosVARDEF(String[] registrosVARDEF)
        {
            ValidarLineaVARDEF(registrosVARDEF);
            AddNombresRegistros(registrosVARDEF);
        }
        private void ValidarLineaVARDEF(String[] registrosVARDEF)
        {
            ValidarExisteRegistroTIME(registrosVARDEF);
            ValidarNoExistenRegistrosVacios(registrosVARDEF);
            ValidarExistenMinimoDeVariables(registrosVARDEF);
            ValidarNoExistanRegistrosRepetidosVARDEF(registrosVARDEF);
        }
        private void ValidarExisteRegistroTIME(String[] registrosVARDEF)
        {
            if (!registrosVARDEF.Contains(REGISTRO_TIME)){
                throw new DataSetException("ERROR: No esta definido el registro TIME");
            }
        }
        private void ValidarNoExistenRegistrosVacios(String[] registrosVARDEF)
        {
            if(registrosVARDEF.Any(r => r == null || r.Equals("")))
            {
                throw new DataSetException("ERROR: Se esperaba una variables en VARDEF");
            }
        }
        private void ValidarExistenMinimoDeVariables(String[] registrosVARDEF)
        {
            if (registrosVARDEF.Length < MINIMO_NOMBRES_REGISTROS)
            {
                throw new DataSetException("ERROR: No tiene el minimo (" + MINIMO_NOMBRES_REGISTROS + ") de registros");
            }
        }
       
        private void ValidarNoExistanRegistrosRepetidosVARDEF(String[] registrosVARDEF)
        {
            if(registrosVARDEF.Count() != DevolverRegistrosDistintos(registrosVARDEF).Count())
            {
                throw new DataSetException("ERROR: Variables Repetida en VARDEF");
            }
        }

        private IEnumerable<String> DevolverRegistrosDistintos(String[] registrosVARDEF)
        {
            return registrosVARDEF.Distinct();
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
            ValidarCantidadDeRegistros(grupoRegistro);
            ValidarTodosLosRegistrosExisten(grupoRegistro);
            AddTodosLosRegistros(grupoRegistro);
        }
       
        private void ValidarCantidadDeRegistros(IDictionary<String, float> grupoRegistro)
        {
            if(grupoRegistro.Count() != nombreRegistros.Count())
            {
                throw new DataSetException("ERROR: falta en el Registro una variables");
            }
        }

        private void ValidarTodosLosRegistrosExisten(IEnumerable<KeyValuePair<String, float>> grupoRegistro)
        {
            for(int i = 0; i < grupoRegistro.Count(); i++)
            {
                KeyValuePair<String, float> registro = grupoRegistro.ElementAt(i);
                ValidarExisteNombreRegistro(registro.Key);
                ValidarVariableTimeSeaMayorCero(registro);
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

        private void ValidarVariableTimeSeaMayorCero(KeyValuePair<String, float> registro)
        {
            if (registro.Key.Equals("TIME"))
            {
                ValidarMayorCero(registro.Value);
            }
        }
        private void ValidarMayorCero(float datoRegistro)
        {
            if (datoRegistro < 0)
            {
                throw new DataSetException("ERROR: Variable TIME menor que Cero");
            }
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
            if (nombreRegistro.Equals(REGISTRO_TIME))
            {
                registro.ordenado = true;
            }
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
            return registro.datosRegistro.LastOrDefault();
        }

        public String GetNombre()
        {
            return this.nombre;
        }
      
        public IEnumerable<String> GetNomresRegistros()
        {
            return this.nombreRegistros;
        } public IEnumerable<VariablesDataSet> GetRegistros()
        {
            return this.registros;
        }

        public void ValidarMinimoDeRegistros()
        {
            TryGetDatosRegistro();
            List<float> datosRegistros = registros.ElementAt(0).datosRegistro;
            if (datosRegistros.Count() < MINIMO_REGISTROS)
            {
                throw new DataSetException("ERROR: Debe tener al menos " + MINIMO_REGISTROS + "registros");
            }
        }

        private void  TryGetDatosRegistro()
        {
            try
            {
               List<float> datos =  registros.ElementAt(0).datosRegistro;
            }
            catch(Exception e)
            {
                throw new DataSetException("ERROR: No existen Datos Registros");
            }
        }
    }

   
}
