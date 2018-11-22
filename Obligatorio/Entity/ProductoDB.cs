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
    public class ProductoDB : IProductoDB
    {
        public void AgregarProducto(Producto producto)
        {
            try
            {
                using (ContextDB aContext = new ContextDB())
                {
                    aContext.Productos.Add(producto);
                    aContext.SaveChanges();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public void ModificarProducto(Producto producto)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    context.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public bool ExisteProducto(string nombreProducto)
        {
            try
            {
                bool exists = false;
                using (ContextDB context = new ContextDB())
                {
                    foreach (Producto productoFromColecction in context.Productos)
                    {
                        if (nombreProducto.Equals(productoFromColecction.nombre))
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
        public Producto GetProducto(string nombreProducto)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    return context.Productos.FirstOrDefault(producto => producto.nombre.Equals(nombreUsuario));
                }

            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public List<Producto> GetListaProductos()
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    var query = context.Productos;
                    context.SaveChanges();
                    return query.ToList<Producto>();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public List<Dominio.Version> GetListaVersionesProducto(string nombreProducto)
        {
            return GetProducto(nombreProducto).versiones;
        }
    }
}
