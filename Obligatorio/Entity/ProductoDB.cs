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
                using (ContextDB aContext = new ContextDB())
                {
                    Producto p = new Producto();
                    p = aContext.Productos.Include("versiones").FirstOrDefault(productoDB => productoDB.nombre.Equals(nombreProducto));
                    aContext.SaveChanges();
                    return p;
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
                List<Producto> productos = new List<Producto>();
                using (ContextDB context = new ContextDB())
                {
                    foreach (Producto producto in context.Productos.Include("versiones"))
                    {
                        productos.Add(producto);
                    }
                    context.SaveChanges();
                    return productos;
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
        public void AgregarVersionProducto(Producto producto, Dominio.Version version)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    Producto p = new Producto();
                    p = context.Productos.Include("versiones").FirstOrDefault(productoDB => productoDB.Id.Equals(producto.Id));
                    p.AddVersion(version);
                    context.Productos.Attach(p);
                    context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public void EliminarVersionProducto(Producto producto, Dominio.Version version)
        {
            try
            {
               
                using (ContextDB context = new ContextDB())
                {
                    Producto p = new Producto();
                    p = context.Productos.Include("versiones").FirstOrDefault(productoDB => productoDB.nombre.Equals(producto.nombre));
                    context.Productos.Attach(p);

                    Dominio.Version versionDB = context.Versiones.FirstOrDefault(v => v.etiqueta.Equals(version.etiqueta));
                    context.Versiones.Attach(versionDB);
                    context.Versiones.Remove(versionDB);
                    context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
    }
}
