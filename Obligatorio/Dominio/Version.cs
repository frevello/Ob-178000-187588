using System;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Version
    {

        public String etiqueta;
        public DateTime fechaCreacion;
        public String estado;
        public Producto producto;

        private const String formatoEtiqueta = "^\\d{1}.\\d{2}.\\d{3}$";

        public Version(String etiqueta, String estado, Producto producto)
        {
            ValidarFormatoEtiqueta(etiqueta, "ERROR: Formato de etiqueta invalido");
            ValidarCampoNoVacios(estado, "ERROR: Estado vacio");
            this.etiqueta = etiqueta;
            this.fechaCreacion = new DateTime();
            this.estado = estado;
            this.producto = producto;
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

    }
}
