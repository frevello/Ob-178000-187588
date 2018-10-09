using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (!ExisteUsuario(nombreUsuario))
            {
                Usuario usuario = new Usuario(nombreUsuario, nombre, contraseña, apellido, rol);
                this.listaUsuarios.Add(usuario);
            }
        }

        private Boolean ExisteUsuario(String nombreUsuario)
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
            TryBajaUsuarioAdmin(usuario, "Error: No se puede dar de baja a Admin");
            TryBajaUsuarioInexistente(usuario, "Error: No existe el usuario");
            this.listaUsuarios.Remove(usuario);
        }

        private void TryBajaUsuarioAdmin(Usuario usuario, String mensaje)
        {
            if (usuario.nombreUsuario.Equals("Admin"))
            {
                throw new UsuarioServiceException(mensaje);
            }
        }

        private void TryBajaUsuarioInexistente(Usuario usuario, String mensaje)
        {
            if (!ExisteUsuario(usuario.nombreUsuario))
            {
                throw new UsuarioServiceException(mensaje);
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            ValidarDatosUsuarioAModificar(usuario);
            TryModificarUsuario(usuario);
        }

        private void ValidarDatosUsuarioAModificar(Usuario usuario)
        {
            Usuario usuarioConModificaciones = new Usuario(usuario.nombreUsuario, usuario.nombre, usuario.contraseña, usuario.apellido, usuario.rol);
        }

        private void TryModificarUsuario(Usuario usuario)
        {
            BajaUsuario(usuario);
            AltaUsuario(usuario.nombreUsuario, usuario.nombre, usuario.contraseña, usuario.apellido, usuario.rol);

        }

    }
}
