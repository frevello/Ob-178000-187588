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

        private static int minLargoContraseña = 3;

        public Usuario(String nombreUsuario, String nombre, String contraseña, String apellido, String rol)
        {
            try
            {
                ValidarNoVacio(nombreUsuario);
                ValidarNoVacio(nombre);
                ValidarNoVacio(apellido);
                ContraseñaCorrecta(contraseña);

                this.nombreUsuario = nombreUsuario;
                this.nombre = nombre;
                this.contraseña = contraseña;
                this.apellido = apellido;
                this.registro = new DateTime();
                this.rol = rol;
            }
            catch(Exception e)
            {

            }
            
        }

        public void SetUltimoIngreso()
        {
            this.ultimoIngreso = new DateTime();
        }    

        private Boolean ValidarNoVacio(String nombreUsuario)
        {
            return nombreUsuario.Length > 0;
        }

        private Boolean ContraseñaCorrecta(String contraseña)
        {
            return contraseña.Length > minLargoContraseña;
        }     

    }
}
