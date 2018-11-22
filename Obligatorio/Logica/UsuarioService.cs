using Dominio;
using Entity;
using InterfazBaseAccess;
using InterfazServiceUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica 
{
    public class UsuarioService: IUsuarioService
    {
        private IUsuarioDB IUsuarioDB;

        public UsuarioService()
        {
            this.IUsuarioDB = new UsuarioDB();
            SetUsuarioAdministrador();
        }

        private void SetUsuarioAdministrador()
        {
            try
            {
                this.AltaUsuario("Admin", "Admin", "Admin", "Admin", "Administrador");
            }
            catch
            {

            }

            
        }

        public void AltaUsuario(String nombreUsuario, String nombre, String contraseña, String apellido, String rol)
        {
            if (!ExisteUsuario(nombreUsuario))
            {
                AgregarUsuario(nombreUsuario, nombre, contraseña, apellido, rol);
            }
            else
            {
                throw new UsuarioServiceException("Error: Ya existe un usuario con el mismo nombre");
            }
        }

        private void AgregarUsuario(String nombreUsuario, String nombre, String contraseña, String apellido, String rol)
        {
            Usuario usuario = new Usuario(nombreUsuario, nombre, contraseña, apellido, rol);
            this.IUsuarioDB.AgregarUsuario(usuario);
        }

        private Boolean ExisteUsuario(String nombreUsuario)
        {
            return this.IUsuarioDB.ExisteUsuario(nombreUsuario);         
        }

        public void BajaUsuario(Usuario usuario)
        {
            TryBajaUsuarioAdmin(usuario, "Error: No se puede dar de baja a Admin");
            TryUsuarioInexistente(usuario.nombreUsuario, "Error: No existe el usuario");
            this.IUsuarioDB.EliminarUsuario(usuario);
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
            Usuario usuario = this.IUsuarioDB.GetUsuario(nombre);
            if (!usuario.contraseña.Equals(contraseña))
            {
                throw new UsuarioServiceException("Error: Contraseña Invalida");
            }
        }

        public List<Usuario> GetListaUsuarios()
        {
            return this.IUsuarioDB.GetListaUsuarios();
        }

        public Usuario GetUsuario(String nombreUsuario)
        {
            TryUsuarioInexistente(nombreUsuario, "Error: No existe el usuario");
            return this.IUsuarioDB.GetUsuario(nombreUsuario);
        }

        public void SetUltimoIngreso(DateTime fecha, String nombreUsuario)
        {
            TryUsuarioInexistente(nombreUsuario, "Error: No existe el usuario");
            Usuario usuario = this.IUsuarioDB.GetUsuario(nombreUsuario);
            usuario.ultimoIngreso = fecha;
        }
    }
}
