using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosCsv
{
    public class CreatorCsv
    {
        private DataSet dataSet;
        private const char SEPARADOR_DATOS = ',';
        private IDictionary<String, float> grupoRegistro;
        private List<String> nombresRegistro;

        public CreatorCsv(String path)
        {
            dataSet = new DataSet(path);
            nombresRegistro = new List<String>();
        }
        public void CargarRegistrosVARDEF(String line)
        {
            String[] registrosVARDEF = line.Split(SEPARADOR_DATOS);
            dataSet.CargarRegistrosVARDEF(registrosVARDEF);
            AddNombresRegisros(registrosVARDEF);
        }
        private void AddNombresRegisros(String[] registrosVARDEF)
        {
            for (int i = 0; i < registrosVARDEF.Length; i++)
            {
                AddNombreRegistro(registrosVARDEF[i]);
            }
        }
        private void AddNombreRegistro(String nombre)
        {
            nombresRegistro.Add(nombre);
        }
        public void IniciaGrupoRegistro()
        {
            grupoRegistro = new Dictionary<String, float>();
        }

        public void AddGrupoRegistro(String line)
        {
            String[] registros = line.Split(SEPARADOR_DATOS);
            for (int i = 0; i < registros.Length; i++)
            {
                AddRegistro(registros[i], i);
            }

        }
        private void AddRegistro(String dato, int index)
        {
            float datoRegistro = ObtenerDato(dato);
            String nombreRegistro = ObtenerNombreRegistro(index);
            grupoRegistro.Add(nombreRegistro, datoRegistro);
        }
        private float ObtenerDato(String dato)
        {
            return float.Parse(dato);
        }
        private String ObtenerNombreRegistro(int index)
        {
            return nombresRegistro.ElementAt(index);
        }
        public void FinGrupoRegistro()
        {
            dataSet.AddGrupoRegistro(grupoRegistro);
        }

        public DataSet DevolverDataSet()
        {
            return dataSet;
        }
        public void EndDataSet()
        {
            dataSet.ValidarMinimoDeRegistros();
        }

    }
}
