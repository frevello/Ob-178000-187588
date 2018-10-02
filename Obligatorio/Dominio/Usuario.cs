using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        private String nombreUsuario;
        private String nombre;
        private String contraseña;
        private String apellido;
        private String rol;
        private DateTime registro;
        private DateTime ultimoIngreso;

        public Usuario(String nombreUsuario, String nombre, String contraseña, String apellido, String rol)
        {
            this.nombreUsuario = nombreUsuario;
            this.nombre = nombre;
            this.contraseña = contraseña;
            this.apellido = apellido;
            this.registro = new DateTime();
            this.rol = rol;
        }

        public void SetUltimoIngreso()
        {
            this.ultimoIngreso = new DateTime();
        }

    }
}
