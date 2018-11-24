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
        public Dominio.Version GetVersion(string etiqueta, string nombreProducto)
        {
            return this.GetListaVersionesProducto(nombreProducto).FirstOrDefault(v => v.etiqueta.Equals(etiqueta));
        }
        public DataSet GetDataSet(string nombreProducto, string etiquetaVersion, string nombreDataSet)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    Dominio.DataSet d = this.GetDataSetConVariablesSinDatos(nombreProducto, etiquetaVersion, nombreDataSet);
                    List<VariablesDataSet> lVariables = new List<VariablesDataSet>();
                    foreach (VariablesDataSet variable in d.GetRegistros())
                    {
                        Dominio.VariablesDataSet va = new Dominio.VariablesDataSet();
                        va = context.VariablesDataSets.Include("datosRegistro").FirstOrDefault(vardatasetDB => vardatasetDB.VariableDataSet_Id.Equals(variable.VariableDataSet_Id));
                        lVariables.Add(va);
                    }
                    d.registros = lVariables;

                    return d;
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public DataSet GetDataSetConVariablesSinDatos(string nombreProducto, string etiquetaVersion, string nombreDataSet)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    Dominio.DataSet d= this.GetDataSetSinVariables( nombreProducto,etiquetaVersion, nombreDataSet);
                    Dominio.DataSet da = new Dominio.DataSet();
                    da = context.DataSets.Include("registros").FirstOrDefault(datasetDB => datasetDB.DataSet_Id.Equals(d.DataSet_Id));

                    return da;
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }

        public DataSet GetDataSetSinVariables(string nombreProducto, string etiquetVersion, string nombreDataSet)
        {          
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    Dominio.Version v = this.GetVersion(etiquetVersion, nombreProducto);
                    Dominio.Version ve = new Dominio.Version();
                    ve = context.Versiones.Include("datasets").FirstOrDefault(versionDB => versionDB.Version_Id.Equals(v.Version_Id));
                    return ve.GetDataSets().FirstOrDefault(d => d.nombre.Equals(nombreDataSet));

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

        public List<DataSet> GetListaDataSetVersion(string nombreProducto, string etiquetaVersion)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    Dominio.Version v = this.GetVersion(etiquetaVersion, nombreProducto);
                    Dominio.Version ve = new Dominio.Version();
                    ve = context.Versiones.Include("datasets").FirstOrDefault(versionDB => versionDB.Version_Id.Equals(v.Version_Id));

                    List<DataSet> lDataSet = new List<DataSet>();
                  
                    foreach (DataSet dataSet in ve.GetDataSets())
                    {
                        lDataSet.Add(dataSet);
                    }
                    context.SaveChanges();

                    return lDataSet;                
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public void AgregarVersionProducto(Producto producto, Dominio.Version version)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    Producto p = new Producto();
                    p = context.Productos.Include("versiones").FirstOrDefault(productoDB => productoDB.Producto_Id.Equals(producto.Producto_Id));
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
        public void AgregarDataSetVersion(Producto producto, Dominio.Version version, DataSet dataSet)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {

                    Dominio.Version v = new Dominio.Version();
                    v = context.Versiones.Include("datasets").FirstOrDefault(versionDB => versionDB.Producto_Id.Equals(producto.Producto_Id) && versionDB.Version_Id.Equals(version.Version_Id));
                    v.AddDataSet(dataSet);
                    context.Versiones.Attach(v);
                    context.Entry(v).State = System.Data.Entity.EntityState.Modified;
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
