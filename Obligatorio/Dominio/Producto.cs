using System;

namespace Dominio
{
    public class Producto
    {
        public String nombre;
        public DateTime fechaInicial;

        public Producto(String nombre)
        {
                ValidarNoVacio(nombre, "ERROR: nombre vacio");
                this.nombre = nombre;
                this.fechaInicial = new DateTime();
        }

        private void ValidarNoVacio(String campo, String mensaje)
        {
            if (campo.Length == 0)
            {
             //   throw new ProductoException(mensaje);
            }
        }

    }
}
