using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Datos
    {
       public List<Usuario> listaUsuarios = new List<Usuario>();
       
        public Datos()
        {
            Usuario admin = new Usuario("Admin", "Admin", "Admin", "Admin", "Administrador");
            this.listaUsuarios.Add(admin);
        }
    }
}
