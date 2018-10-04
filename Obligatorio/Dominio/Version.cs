using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Version
    {

        public String etiqueta;
        public DateTime fechaCreacion;
        public String estado;
        public Producto producto;

        private const String formatoEtiqueta = "X.YY.ZZZ";

        public Version(String etiqueta, String estado, Producto producto)
        {

            try
            {
                ValidarFormatoEtiqueta(etiqueta, "ERROR: formato de etiqueta invalido");
                this.etiqueta = etiqueta;
                this.fechaCreacion = new DateTime();
                this.estado = estado;
                this.producto = producto;
            }
            catch (ProductoException e)
            {
                throw new ProductoException(e);
            }
        }

        private void ValidarFormatoEtiqueta(String campo, String mensaje)
        {
            ///Falta validar formato
            if (campo.Length == 0) 
            {
                throw new ProductoException(mensaje);
            }
        }

    }
}
