using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class UsuarioService
    {

        public void AltaUsuario(String nombreUsuario, String nombre, String contraseña, String apellido, String rol)
        {
            Usuario usuario = new Usuario(nombreUsuario, nombre, contraseña, apellido, rol);
        }

    }
}
