using System;
using System.Collections.Generic;

namespace Dominio
{ 
    public class Producto
    {
        private String nombre;
        private DateTime fechaInicial;
        private List<Version> versiones;

        public Producto(String nombre, DateTime fecha)
        {
            ValidarNoVacio(nombre);
            this.nombre = nombre;
            this.fechaInicial = fecha;
            this.versiones = new List<Version>();
        }

        private void ValidarNoVacio(String campo)
        {
            if (campo.Length == 0)
            {
                throw new LargoDatoNoValidoException("ERROR: nombre vacio");
            }
        }

        public IEnumerable<Version> GetVersiones()
        {
            return this.versiones;
        }
        public String GetNombre()
        {
            return this.nombre;
        }

        public DateTime GetFechaInicial()
        {
            return this.fechaInicial;
        }

        public void SetNombre(String nombre)
        {
           this.nombre = nombre;
        }
        public void SetFechaInicial(DateTime fechaInicial)
        {
            this.fechaInicial = fechaInicial;
        }

        public void AddVersion(Version version)
        {
            this.versiones.Add(version);
        }
    }
}
