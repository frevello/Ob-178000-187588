using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Version
    {
        [Key]
        public Guid Version_Id { get; set; }
        public Guid Producto_Id { get; set; }
        public String etiqueta { get; set; }
        public DateTime fechaCreacion { get; set; }
        public String estado { get; set; }
        public List<DataSet> datasets { get; set; }

        private const String formatoEtiqueta = "^\\d{1}.\\d{2}.\\d{3}$";

        public Version()
        {
            Version_Id = Guid.NewGuid();
            this.datasets = new List<DataSet>();
        }

        public Version(String etiqueta, String estado, Producto producto, DateTime fecha)
        {
            ValidarFormatoEtiqueta(etiqueta, "ERROR: Formato de etiqueta invalido");
            ValidarCampoNoVacios(estado, "ERROR: Estado vacio");
            Version_Id = Guid.NewGuid();
            this.etiqueta = etiqueta;
            this.fechaCreacion = fecha;
            this.estado = estado;
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
