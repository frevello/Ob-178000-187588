using Dominio;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class UsuarioService
    {

        private List<Usuario> listaUsuarios;

        public UsuarioService()
        {
            this.listaUsuarios = new List<Usuario>();
            Usuario admin = new Usuario("Admin", "Admin", "Admin", "Admin", "Administrador");
            listaUsuarios.Add(admin);
        }


        public void AltaUsuario(String nombreUsuario, String nombre, String contraseña, String apellido, String rol)
        {
            try
            {
                TryAltaUsuario(nombreUsuario, nombre, contraseña, apellido, rol);               
            }catch(UsuarioServiceException e)
            {
                throw new UsuarioServiceException(e);
            }    
        }

        public void TryAltaUsuario(String nombreUsuario, String nombre, String contraseña, String apellido, String rol)
        {
            if (!ExisteUsuario(nombreUsuario))
            {
                Usuario usuario = new Usuario(nombreUsuario, nombre, contraseña, apellido, rol);
                this.listaUsuarios.Add(usuario);
            }
        }

        public Boolean ExisteUsuario(String nombreUsuario)
        {
            Boolean esta = false;
            for (int i = 0; i < this.listaUsuarios.Count() && !esta; i++)
            {
                if (nombreUsuario.Equals(this.listaUsuarios.ElementAt(i).nombreUsuario))
                {
                    esta = true;
                }
            }
            return esta;
        }

        public void BajaUsuario(Usuario usuario)
        {
            try
            {
                TryBajaUsuarioAdmin(usuario, "Error: No se puede dar de baja a Admin");
                TryBajaUsuarioInexistente(usuario, "Error: No existe el usuario");
                this.listaUsuarios.Remove(usuario);
            }
            catch (UsuarioServiceException e)
            {
                throw new UsuarioServiceException(e);
            }
        }

        public void TryBajaUsuarioAdmin(Usuario usuario, String mensaje)
        {
            if (usuario.nombreUsuario.Equals("Admin"))
            {
                throw new UsuarioServiceException(mensaje);
            }
        }

        public void TryBajaUsuarioInexistente(Usuario usuario, String mensaje)
        {
            if (!ExisteUsuario(usuario.nombreUsuario))
            {
                throw new UsuarioServiceException(mensaje);
            }
        }

        public void ModificarUsuario( Usuario usuario)
        {
            try
            {
                
            }
            catch (Exception e)
            {

            }
        }



    }
}
