using Dominio;
using System;

namespace InterfazServiceUI
{
    public interface IUsuarioService
    {
        void AltaUsuario(String nombreUsuario, String nombre, String contraseña, String apellido, String rol);
        void BajaUsuario(Usuario usuario);
        void ModificarUsuario(Usuario usuario);
    }
}
