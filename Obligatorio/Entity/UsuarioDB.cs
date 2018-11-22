using BaseAccess;
using Dominio;
using InterfazBaseAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UsuarioDB : IUsuarioDB
    {
        public void AgregarUsuario(Usuario usuario)
        {
            try
            {
                using (ContextDB aContext = new ContextDB())
                {
                    aContext.Usuarios.Add(usuario);
                    aContext.SaveChanges();
                }
            }
            catch(DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public void EliminarUsuario(Usuario usuario)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    Usuario u = GetUsuario(usuario.nombreUsuario);
                    context.Usuarios.Attach(u);
                    context.Usuarios.Remove(u);
                    context.SaveChanges();
                }  
            }
            catch(DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public void ModificarUsuario(Usuario usuario)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    context.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public bool ExisteUsuario(string nombreUsuario)
        {
            try
            {
                bool exists = false;
                using (ContextDB context = new ContextDB())
                {
                    foreach (Usuario usuarioFromColecction in context.Usuarios)
                    {
                        if (nombreUsuario.Equals(usuarioFromColecction.nombreUsuario))
                        {
                            exists = true;
                        }
                    }
                }
                return exists;
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public Usuario GetUsuario(string nombreUsuario)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    return context.Usuarios.FirstOrDefault(usuario => usuario.nombreUsuario.Equals(nombreUsuario));
                }
                
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public List<Usuario> GetListaUsuarios()
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    var query = context.Usuarios;
                    context.SaveChanges();
                    return query.ToList<Usuario>();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
    }
}
