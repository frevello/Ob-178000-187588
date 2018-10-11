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
            else
            {
                throw new UsuarioServiceException("Error: Ya existe un usuario con el mismo nombre");
            }
        }

        private Boolean ExisteUsuario(String nombreUsuario)
        {
            if (this.listaUsuarios.FirstOrDefault(u => u.nombreUsuario == nombreUsuario) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void BajaUsuario(Usuario usuario)
        {
            TryBajaUsuarioAdmin(usuario, "Error: No se puede dar de baja a Admin");
            TryBajaUsuarioInexistente(usuario, "Error: No existe el usuario");
            this.listaUsuarios.RemoveAll(u => u.nombreUsuario == usuario.nombreUsuario);
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
