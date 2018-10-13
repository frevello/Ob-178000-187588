using Dominio;
using System;
using System.Collections.Generic;

namespace InterfazServiceUI
{
    public interface IUsuarioService
    {
        void AltaUsuario(String nombreUsuario, String nombre, String contraseña, String apellido, String rol);
        void BajaUsuario(Usuario usuario);
        void ModificarUsuario(Usuario usuario);
        Boolean LogIn(String nombre, String contraseña);
        List<Usuario> GetListaUsuarios();
        Usuario GetUsuario(String nombreUsuario);
        void SetUltimoIngreso(DateTime fecha, String nombreUsuario);
    }
}
