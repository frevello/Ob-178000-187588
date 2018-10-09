using System;

namespace Dominio
{
    public class Producto
    {
        public String nombre;
        public DateTime fechaInicial;

        public Producto(String nombre)
        {
            try
            {
                ValidarNoVacio(nombre, "ERROR: nombre vacio");
                this.nombre = nombre;
                this.fechaInicial = new DateTime();
            }
            catch(ProductoException e)
            {
                throw new ProductoException(e);
            }
        }

        private void ValidarNoVacio(String campo, String mensaje)
        {
            if (campo.Length == 0)
            {
                throw new ProductoException(mensaje);
            }
        }

    }
}
