
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos
{
    public class ValidatorFormat
    {
        private const String VARDEF = "VARDEF";
        private const String FIN_GRUPO_REGISTRO = "#";
        private const char SEPARADOR_REGISTRO_DE_DATO = '=';
        private const char SEPARADOR_DE_REGISTROS_EN_VARDEF = ',';
        private const int CANT_DATOS_SEPARADOS = 2;
        private const String REGISTRO_TIME = "TIME";
        private const int MINIMO_NOMBRES_REGISTROS = 2;
        private const int MINIMO_REGISTROS = 2;
        private List<String> nombreRegistros;
        private float lastDatoTime = -1;

        private IDictionary<String, float> grupoRegistro;

        public ValidatorFormat()
        {
            nombreRegistros = new List<String>();
            
        }
        public void ValidarPrimeraLinea(String line)
        {
            ValidarLineaContieneUnicoSeparadorDeDato(line);
            ValidarLineaContieneVARDEF(line);
            ValidarNombresRegistros(line);
            AddNombresRegistros(line);
        }

        private void ValidarLineaContieneVARDEF(String line)
        {
            String[] vardef = line.Split(SEPARADOR_REGISTRO_DE_DATO);
            if (!vardef[0].Equals(VARDEF))
            {
                throw new ValidatorFormatException("ERROR: En 1ra linea no se encontro VARDEF");
            }
        }
        private void ValidarNombresRegistros(String line)
        {
            String[] vardef = line.Split(SEPARADOR_REGISTRO_DE_DATO);
            String[] registrosVARDEF = vardef[1].Split(SEPARADOR_DE_REGISTROS_EN_VARDEF);
            ValidarExisteRegistroTIME(registrosVARDEF);
            ValidarNoExistenRegistrosVacios(registrosVARDEF);
            ValidarExistenMinimoDeVariables(registrosVARDEF);
            ValidarNoExistanRegistrosRepetidosVARDEF(registrosVARDEF);

        }

        private void ValidarExisteRegistroTIME(String[] registrosVARDEF)
        {
            if (!registrosVARDEF.Contains(REGISTRO_TIME))
            {
                throw new DataSetException("ERROR: No esta definido el registro TIME");
            }
        }
        private void ValidarNoExistenRegistrosVacios(String[] registrosVARDEF)
        {
            if (registrosVARDEF.Any(r => r == null || r.Equals("")))
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
            if (registrosVARDEF.Count() != DevolverRegistrosDistintos(registrosVARDEF).Count())
            {
                throw new DataSetException("ERROR: Variables Repetida en VARDEF");
            }
        }

        private IEnumerable<String> DevolverRegistrosDistintos(String[] registrosVARDEF)
        {
            return registrosVARDEF.Distinct();
        }
        private void AddNombresRegistros(String line)
        {
            String[] vardef = line.Split(SEPARADOR_REGISTRO_DE_DATO);
            String[] registrosVARDEF = vardef[1].Split(SEPARADOR_DE_REGISTROS_EN_VARDEF);
            for (int i = 0; i < registrosVARDEF.Length; i++)
            {
                nombreRegistros.Add(registrosVARDEF[i]);
            }
        }
        public void ValidarRegistro(String line)
        {
            ValidarLineaContieneUnicoSeparadorDeDato(line);
            ValidarDatosRegistro(line);
            
        }

         private void ValidarLineaContieneUnicoSeparadorDeDato(String line)
        {
            String[] datos = line.Split(SEPARADOR_REGISTRO_DE_DATO);
            if(datos.Length != CANT_DATOS_SEPARADOS)
            {
                throw new ValidatorFormatException("ERROR: Linea debe tener un unico separador " + SEPARADOR_REGISTRO_DE_DATO);
            }
        }
        public void ValidarDatosRegistro(String line)
        {
            String nombreRegistro = ObtenerNombreRegistro(line);
            float datoRegistro = ObtenerDatoRegistro(line);
            ValidarNoExisteRegistro(nombreRegistro, datoRegistro);
            
        }
        private String ObtenerNombreRegistro(String line)
        {
            return line.Split(SEPARADOR_REGISTRO_DE_DATO)[0];
        }

        private float ObtenerDatoRegistro(String line)
        {
            String dato = ObtenerDatoRegistroDeLinea(line);
            ValidarFormatoDato(dato);
            return float.Parse(dato);
        }
        private String ObtenerDatoRegistroDeLinea(String line)
        {
            return line.Split(SEPARADOR_REGISTRO_DE_DATO)[1];
        }
        private void ValidarFormatoDato(String datoRegistro)
        {
            try
            {
                float dato = float.Parse(datoRegistro);
            }
            catch (Exception)
            {
                throw new ValidatorFormatException("ERROR: Dato registro no valido");
            }
        }
      

        public void IniciaGrupoRegistro()
        {
            grupoRegistro = new Dictionary<String, float>();
        }
        private void ValidarNoExisteRegistro(String nombreRegistro, float datoRegistro)
        {
            try
            {
                grupoRegistro.Add(nombreRegistro, datoRegistro);
            }
            catch (ArgumentException)
            {
                throw new ValidatorFormatException("ERROR: Registro Repetido en Grupo Registro");
            }
        }
        public void ValidarFinRegistroCorrecto(String line)
        {
            if (!ExisteLinea(line))
            {
                throw new ValidatorFormatException("ERROR: Falta fin del registro");
            }
        }
        public Boolean ExisteLinea(String line)
        {
            return line != null;
        }
        public void FinGrupoRegistro(String line)
        {
            ValidarFinRegistroCorrecto(line);
            ValidarCantidadDeRegistros();
            ValidarTodosLosRegistrosExisten();
        }
        private void ValidarCantidadDeRegistros()
        {
            if (grupoRegistro.Count() != nombreRegistros.Count())
            {
                throw new DataSetException("ERROR: cantidad de variables en el registro incorrecta");
            }
        }
        private void ValidarTodosLosRegistrosExisten()
        {
            for (int i = 0; i < grupoRegistro.Count(); i++)
            {
                ValidarExisteNombreRegistro(grupoRegistro.ElementAt(i).Key);
                ValidarDatoTime(grupoRegistro.ElementAt(i));
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

        private void ValidarDatoTime(KeyValuePair<String, float> registro)
        {
            if (registro.Key.Equals(REGISTRO_TIME))
            {
                ValidarMayorCero(registro.Value);
                ValidarDatoTimeOrdenado(registro.Value);
                lastDatoTime = registro.Value;
            }
        }

        private void ValidarMayorCero(float datoRegistro)
        {
            if (datoRegistro < 0)
            {
                throw new DataSetException("ERROR: Variable TIME menor que Cero");
            }
        }
        private void ValidarDatoTimeOrdenado(float datoRegistro)
        {
            if (lastDatoTime > datoRegistro)
            {
                throw new DataSetException("ERROR: DataSet no esta ordenado por variable TIME");
            }
        }
        public Boolean EsFinGrupoRegistro(String line)
        {
            return line.Equals(FIN_GRUPO_REGISTRO);
        }
        public void ValidarFinArchivo(int countGruposRegistros)
        {
            ValidarMinimoDeRegistros(countGruposRegistros);
        }
        public void ValidarMinimoDeRegistros(int countGruposRegistros)
        {
            if (countGruposRegistros < MINIMO_REGISTROS)
            {
                throw new DataSetException("ERROR: Debe tener al menos " + MINIMO_REGISTROS + "registros");
            }
        }
    }
}
