using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Version
    {
        private String etiqueta;
        private DateTime fechaCreacion;
        private String estado;
        private Producto producto;
        private List<DataSet> datasets;

        private const String formatoEtiqueta = "^\\d{1}.\\d{2}.\\d{3}$";

        public Version(String etiqueta, String estado, Producto producto, DateTime fecha)
        {
            ValidarFormatoEtiqueta(etiqueta, "ERROR: Formato de etiqueta invalido");
            ValidarCampoNoVacios(estado, "ERROR: Estado vacio");
            this.etiqueta = etiqueta;
            this.fechaCreacion = fecha;
            this.estado = estado;
            this.producto = producto;
            this.datasets = new List<DataSet>();
        }

        private void ValidarFormatoEtiqueta(String campo, String mensaje)
        {
            if (campo.Length == 0 || !FormatoEtiqueta(campo))
            {
                throw new VersionEtiquetaException(mensaje);
            }
        }

        private Boolean FormatoEtiqueta(String campo)
        {
            Regex regex = new Regex(formatoEtiqueta);
            return regex.IsMatch(campo);

        }

        private void ValidarCampoNoVacios(String campo, String mensaje)
        {
            if (campo.Length == 0)
            {
                 throw new LargoDatoNoValidoException(mensaje);
            }
        }

        public String GetEtiqueta()
        {
            return this.etiqueta;
        }
        public String GetEstado()
        {
            return this.estado;
        }
        public IEnumerable<DataSet> GetDataSets()
        {
            return this.datasets;
        }
        public DateTime GetFechaCreacion()
        {
            return this.fechaCreacion;
        }
        public void SetEtiqueta(String etiqueta)
        {
            this.etiqueta = etiqueta;
        }
        public void SetEstado(String estado)
        {
            this.estado = estado;
        }
        public void SetFechaCreacion(DateTime fecha)
        {
            this.fechaCreacion = fecha;
        }
        public void AddDataSet(DataSet dataSet)
        {
            this.datasets.Add(dataSet);
        }
    }
}
