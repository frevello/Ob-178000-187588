using System;
using System.Collections.Generic;

namespace Dominio
{ 
    public class Producto
    {
        public Guid Id { get; set; }
        public String nombre { get; set; }
        public DateTime fechaInicial { get; set; }
        public List<Version> versiones { get; set; }


        public Producto()
        {
            Id = Guid.NewGuid();
            this.versiones = new List<Version>();
        }

        public Producto(String nombre, DateTime fecha)
        {
            Id = Guid.NewGuid();
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
