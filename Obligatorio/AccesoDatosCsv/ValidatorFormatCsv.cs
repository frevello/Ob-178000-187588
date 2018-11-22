using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AccesoDatosCsv
{
    public class ValidatorFormatCsv
    {
        private const char SEPARADOR_DATOS = ',';
        private const String REGISTRO_TIME = "TIME";
        private const String FORMATO_ALFANUMERICO = "^[a-zA-Z][a-zA-Z0-9]*$";
        private const int MINIMO_NOMBRES_REGISTROS = 2;
        private const int MINIMO_REGISTROS = 2;
        private const int INDEX_TIME = 0;
        private int countNombresRegistros = 0;
        private float lastDatoTime = -1;

        public void ValidarPrimeraLinea(String line)
        {
            String[] registrosVARDEF = line.Split(SEPARADOR_DATOS);
            countNombresRegistros = registrosVARDEF.Length;
            ValidarNombresRegistros(registrosVARDEF);
            ValidarExistenMinimoDeVariables(registrosVARDEF);
            ValidarNoExistanRegistrosRepetidosVARDEF(registrosVARDEF);
            
        }
        private void ValidarNombresRegistros(String[] registrosVARDEF)
        {
            ValidarNombreRegistrosValidos(registrosVARDEF);
            ValidarRegistroTIMEPrimero(registrosVARDEF);
            ValidarNoExistenRegistrosVacios(registrosVARDEF, "ERROR: Se esperaba una variables en VARDEF");
        }
        private void ValidarNombreRegistrosValidos(String[] registrosVARDEF)
        {
            for (int i = 0; i < registrosVARDEF.Length; i++)
            {
                ValidarFormatoNombreVariable(registrosVARDEF[i]);
            }
        }
        private void ValidarFormatoNombreVariable(String nombre)
        {
            Regex regex = new Regex(FORMATO_ALFANUMERICO);
            if (!regex.IsMatch(nombre))
            {
                throw new ValidatorFormatCsvException("ERROR: Variable mal definida en VARDEF");
            }
        }
        private void ValidarRegistroTIMEPrimero(String[] registrosVARDEF)
        {
            if (!registrosVARDEF[INDEX_TIME].Equals(REGISTRO_TIME))
            {
                throw new ValidatorFormatCsvException("ERROR: No esta definido el registro TIME en primer lugar");
            }
        }
       
        private void ValidarExistenMinimoDeVariables(String[] registrosVARDEF)
        {
            if (registrosVARDEF.Length < MINIMO_NOMBRES_REGISTROS)
            {
                throw new ValidatorFormatCsvException("ERROR: No tiene el minimo (" + MINIMO_NOMBRES_REGISTROS + ") de registros");
            }
        }
        private void ValidarNoExistanRegistrosRepetidosVARDEF(String[] registrosVARDEF)
        {
            if (registrosVARDEF.Count() != DevolverRegistrosDistintos(registrosVARDEF).Count())
            {
                throw new ValidatorFormatCsvException("ERROR: Variables Repetida en VARDEF");
            }
        }
        private IEnumerable<String> DevolverRegistrosDistintos(String[] registrosVARDEF)
        {
            return registrosVARDEF.Distinct();
        }
        
        public void ValidarRegistro(String line)
        {
            String[] registros = line.Split(SEPARADOR_DATOS);
            ValidarNoExistenRegistrosVacios(registros, "ERROR: se esperaba un dato");
            ValidarCantidadDatos(registros);
            ValidarDatosRegistro(registros);
            ValidarDatoTIME(registros);
        }
        private void ValidarNoExistenRegistrosVacios(String[] registros, String message)
        {
            if (registros.Any(r => r == null || r.Equals("")))
            {
                throw new ValidatorFormatCsvException(message);
            }
        }
        private void ValidarCantidadDatos(String[] registros)
        {
            if (registros.Count() != countNombresRegistros)
            {
                throw new ValidatorFormatCsvException("ERROR: Se esperaban " + countNombresRegistros + "Registros" );
            }
        }
        private void ValidarDatosRegistro(String[] registros)
        {
            for(int i = 0; i <= registros.Length; i++)
            {
                ValidarFormatoDato(registros[i]);
            }

        }
        private void ValidarFormatoDato(String datoRegistro)
        {
            try
            {
                float dato = float.Parse(datoRegistro);
            }
            catch (Exception)
            {
                throw new ValidatorFormatCsvException("ERROR: Dato registro no valido");
            }
        }
        private void ValidarDatoTIME(String[] registros)
        {
            float dato = ObtenerDatoIndex(registros, INDEX_TIME);
            ValidarDatoMayorCero(dato);
            ValidarDatoTimeOrdenado(dato);
            lastDatoTime = dato;
        }
        private float ObtenerDatoIndex(String[] registros, int index)
        {
            String datoRegistro = registros[index];
            return float.Parse(datoRegistro);
        }
        private void ValidarDatoMayorCero(float datoRegistro)
        {

            if (datoRegistro < 0)
            {
                throw new ValidatorFormatCsvException("ERROR: Dato TIME menor a cero");
            }
        }
        private void ValidarDatoTimeOrdenado(float datoRegistro)
        {
            if (lastDatoTime > datoRegistro)
            {
                throw new ValidatorFormatCsvException("ERROR: DataSet no esta ordenado por variable TIME");
            }
        }
        public void ValidarFinArchivo(int countGruposRegistros)
        {
            ValidarMinimoDeRegistros(countGruposRegistros);
        }
        public void ValidarMinimoDeRegistros(int countGruposRegistros)
        {
            if (countGruposRegistros < MINIMO_REGISTROS)
            {
                throw new ValidatorFormatCsvException("ERROR: Debe tener al menos " + MINIMO_REGISTROS + "registros");
            }
        }
        public Boolean ExisteLinea(String line)
        {
            return line != null;
        }
    }
}
