using Dominio;
using InterfazServiceUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica 
{
    public class UsuarioService: IUsuarioService
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
            TryUsuarioInexistente(usuario.nombreUsuario, "Error: No existe el usuario");
            this.listaUsuarios.RemoveAll(u => u.nombreUsuario == usuario.nombreUsuario);
        }

        private void TryBajaUsuarioAdmin(Usuario usuario, String mensaje)
        {
            if (usuario.nombreUsuario.Equals("Admin"))
            {
                throw new UsuarioServiceException(mensaje);
            }
        }

        private void TryUsuarioInexistente(String nombreUsuario, String mensaje)
        {
            if (!ExisteUsuario(nombreUsuario))
            {
                throw new UsuarioServiceException(mensaje);
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            TryUsuarioInexistente(usuario.nombreUsuario, "Error: No existe el usuario");
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

        public Boolean LogIn(String nombre, String contraseña)
        {
            TryValidarCamposVacios(nombre, contraseña);
            TryUsuarioInexistente(nombre, "Error: No existe el usuario");
            TryDatosCorrectos(nombre, contraseña);
            return true;
        }

        private void TryValidarCamposVacios(String nombre, String contraseña)
        {
            ValidarNoVacio(nombre, "Error: Nombre de usuario vacio");
            ValidarNoVacio(contraseña, "Error: Contraseña de usuario vacia");
        }

        private void ValidarNoVacio(String campo, String mensaje)
        {
            if (campo.Length == 0)
            {
                throw new LargoDatoNoValidoException(mensaje);
            }
        }

        private void TryDatosCorrectos(String nombre, String contraseña)
        {
            Usuario usuario = this.listaUsuarios.FirstOrDefault(u => u.nombreUsuario == nombre);
            if (!usuario.contraseña.Equals(contraseña))
            {
                throw new UsuarioServiceException("Error: Contraseña Invalida");
            }
        }

        public List<Usuario> GetListaUsuarios()
        {
            return this.listaUsuarios;
        }

        public Usuario GetUsuario(String nombreUsuario)
        {
            TryUsuarioInexistente(nombreUsuario, "Error: No existe el usuario");
            return this.listaUsuarios.FirstOrDefault(u => u.nombreUsuario == nombreUsuario);
        }

        public void SetUltimoIngreso(DateTime fecha, String nombreUsuario)
        {
            TryUsuarioInexistente(nombreUsuario, "Error: No existe el usuario");
            Usuario usuario = this.listaUsuarios.FirstOrDefault(u => u.nombreUsuario == nombreUsuario);
            usuario.ultimoIngreso = fecha;
        }
    }
}
