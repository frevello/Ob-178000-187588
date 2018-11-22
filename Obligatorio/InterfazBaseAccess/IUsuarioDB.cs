using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazBaseAccess
{
    public interface IUsuarioDB
    {
        void AgregarUsuario(Usuario usuario);
        void EliminarUsuario(Usuario usuario);
        void ModificarUsuario(Usuario usuario);
        bool ExisteUsuario(string nombreUsuario);
        Usuario GetUsuario(string nombreUsuario);
        List<Usuario> GetListaUsuarios();
    }
}
