using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {

        public String nombreUsuario;
        public String nombre;
        public String contraseña;
        public String apellido;
        public String rol;
        public DateTime registro;
        public DateTime ultimoIngreso;

        private const int minLargoContraseña = 3;

        public Usuario(String nombreUsuario, String nombre, String contraseña, String apellido, String rol)
        {
            try
            {
                ValidarNoVacio(nombreUsuario, "ERROR: Nombre usuario vacio");
                ValidarNoVacio(nombre, "ERROR: Nombre vacio");
                ValidarNoVacio(apellido, "ERROR: Apellido vacio");
                ContraseñaCorrecta(contraseña, "ERROR: Contraseña menor a 3");

                this.nombreUsuario = nombreUsuario;
                this.nombre = nombre;
                this.contraseña = contraseña;
                this.apellido = apellido;
                this.registro = new DateTime();
                this.rol = rol;
            }
            catch(UsuarioServiceException e)
            {
                throw new UsuarioServiceException(e);
            }
            
        }

        private void ValidarNoVacio(String campo, String mensaje)
        {
            if(campo.Length == 0)
            {
                throw new UsuarioServiceException(mensaje);
            }
        }

        private void ContraseñaCorrecta(String contraseña, String mensaje)
        {
            if (contraseña.Length < minLargoContraseña)
            {
                throw new UsuarioServiceException(mensaje);
            }
        }

        public void SetUltimoIngreso()
        {
            this.ultimoIngreso = new DateTime();
        }

    }
}
