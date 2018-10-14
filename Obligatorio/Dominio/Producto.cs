using System;
using System.Collections.Generic;

namespace Dominio
{ 
    public class Producto
    {
        public String nombre;
        public DateTime fechaInicial;
        private List<Version> listaVersion;

        public Producto(String nombre, DateTime fecha)
        {
            ValidarNoVacio(nombre, "ERROR: nombre vacio");
            this.nombre = nombre;
            this.fechaInicial = fecha;
            this.listaVersion = new List<Version>();
        }

        private void ValidarNoVacio(String campo, String mensaje)
        {
            if (campo.Length == 0)
            {
                throw new LargoDatoNoValidoException(mensaje);
            }
        }

        public List<Version> GetVersiones()
        {
            return this.listaVersion;
        }
    }
}
