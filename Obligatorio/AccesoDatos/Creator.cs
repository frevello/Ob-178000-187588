using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Creator
    {
        private DataSet dataSet;
        private const char SEPARADOR_REGISTRO_DE_DATO = '=';
        private const char SEPARADOR_DE_REGISTROS_EN_VARDEF = ',';
        private IDictionary<String, float> grupoRegistro;

        public Creator(String path)
        {
            dataSet = new DataSet(path);
        }

        public DataSet DevolverDataSet()
        {
            return dataSet;
        }

        public void CargarRegistrosVARDEF(String line)
        {
            String[] registrosVARDEF = ObtenerRegistrosVARDEF(line);
            dataSet.CargarRegistrosVARDEF(registrosVARDEF);
        }

        private String[] ObtenerRegistrosVARDEF(String line)
        {
            line = EliminarDeLineaVARDEF(line);
            return SplitRegistrosVARDEF(line);
        }

        private String EliminarDeLineaVARDEF(String line)
        {
            String[] lineSinVARDEF = line.Split(SEPARADOR_REGISTRO_DE_DATO);
            return lineSinVARDEF[1];
        }
        private String[] SplitRegistrosVARDEF(String line)
        {
            return line.Split(SEPARADOR_DE_REGISTROS_EN_VARDEF);
        }

        public void IniciaGrupoRegistro()
        {
            grupoRegistro = new Dictionary<String, float>();
        }

        public void CargarRegistro(String line)
        {
            String nombreRegistro = ObtenerNombreRegistro(line);
            float datoRegistro = ObtenerDatoRegistro(line);
            TryAddRegistro(nombreRegistro, datoRegistro);
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

        private void TryAddRegistro(String nombreRegistro, float datoRegistro)
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

        public void FinGrupoRegistro()
        {
            CargarGrupoRegistro();
        }

        private void CargarGrupoRegistro()
        {
            dataSet.AddGrupoRegistro(grupoRegistro);
        }

    }
}
