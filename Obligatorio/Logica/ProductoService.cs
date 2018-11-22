using Dominio;
using Entity;
using InterfazBaseAccess;
using InterfazServiceUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{ 
    public class ProductoService : IProductoService
    {
        private IProductoDB IProductoDB;

        private const int FECHA = 2000;

        public ProductoService()
        {
            this.IProductoDB = new ProductoDB();
        }

        public void AltaProducto(String nombre, DateTime fecha)
        {
            if (!ExisteProducto(nombre))
            {
                TryFechaCorrecta(fecha, "Error: El año debe ser posterior al 2000");
                AgregarProducto(nombre, fecha);
            }
            else
            {
                throw new ProductoServiceException("Error: Ya existe producto con el mismo nombre");
            }
        }

        private void TryFechaCorrecta(DateTime fecha, String mensaje)
        {
            if (fecha.Year < FECHA)
            {
                throw new ProductoServiceException(mensaje);
            }
        }

        private void AgregarProducto(String nombre, DateTime fecha)
        {
            Producto producto = new Producto(nombre, fecha);
            this.IProductoDB.AgregarProducto(producto);
        }

        public Producto GetProducto(String nombre)
        {
            TryProductoInexistente(nombre, "Error: No existe el producto");
            return this.IProductoDB.GetProducto(nombre);
        }

        public List<Producto> GetListaProducto()
        {
            return this.IProductoDB.GetListaProductos();
        }

        private void TryProductoInexistente(String nombre, String mensaje)
        {
            if (!ExisteProducto(nombre))
            {
                throw new ProductoServiceException(mensaje);
            }
        }

        public Boolean ExisteProducto(String nombre)
        {
            return this.IProductoDB.ExisteProducto(nombre);              
        }

        public void AltaVersion(String nombreProducto, String etiqueta, String estado, DateTime fecha)
        {
            TryProductoInexistente(nombreProducto, "Error: No existe el producto");
            Producto producto = this.GetProducto(nombreProducto);
            TryVersionUnica(producto, etiqueta, "Error: Ya existe esa version para el producto");
            TryFechaCreacion(producto, fecha, "Error: La fecha debe ser posterior o igual a la del producto");
            AgregarVersion(producto, etiqueta, estado, fecha);
        }

        private void TryVersionUnica(Producto producto, String etiqueta, String mensaje)
        {

            if (this.IProductoDB.GetListaVersionesProducto(producto.nombre).FirstOrDefault(v => v.GetEtiqueta() == etiqueta) != null)
            {
                throw new VersionException(mensaje);
            }
        }

        private void TryFechaCreacion(Producto producto, DateTime fecha, String mensaje)
        {
            if (producto.GetFechaInicial() > fecha)
            {
                throw new VersionException(mensaje);
            }
        }

        private void AgregarVersion(Producto producto, String etiqueta, String estado, DateTime fecha)
        {
            Dominio.Version version = new Dominio.Version(etiqueta, estado, producto, fecha);
            this.IProductoDB.AgregarVersionProducto(producto, version);
        }

        public Dominio.Version GetVersionProducto(String nombre, String etiqueta)
        {
            TryProductoInexistente(nombre, "Error: No existe el producto");
            Producto producto = this.GetProducto(nombre);
            TryExisteVersion(producto, etiqueta, "Error: No existe la version");
            return GetVersion(producto, etiqueta);
        }

        private void TryExisteVersion(Producto producto, String etiqueta, String mensaje)
        {
            if (this.IProductoDB.GetListaVersionesProducto(producto.nombre).FirstOrDefault(v => v.GetEtiqueta() == etiqueta) == null)
            {
                throw new VersionException(mensaje);
            }
        }

        private Dominio.Version GetVersion(Producto producto, String etiqueta)
        {
            return this.IProductoDB.GetListaVersionesProducto(producto.nombre).FirstOrDefault(v => v.GetEtiqueta() == etiqueta);
        }

        public IEnumerable<Dominio.Version> GetListaVersionesVersionProducto(String nombre)
        {
            TryProductoInexistente(nombre, "Error: No existe el producto");
            return GetListaVersiones(nombre);
        }

        private IEnumerable<Dominio.Version> GetListaVersiones(String nombre)
        {
            //Producto producto = this.listaProductos.FirstOrDefault(p => p.GetNombre() == nombre);
            // return producto.GetVersiones();
            return this.IProductoDB.GetListaVersionesProducto(nombre);
        }

        public void ModificarProducto(String nombreProductoViejo, String nombreProductoNuevo, DateTime nuevaFecha)
        {
            TryDatosNuevoProducto(nombreProductoViejo, nombreProductoNuevo, nuevaFecha);
            TryNombreNuevoProducto(nombreProductoViejo, nombreProductoNuevo);
            ModificarDatos(nombreProductoViejo, nombreProductoNuevo, nuevaFecha);
        }

        private void TryDatosNuevoProducto(String nombreProductoViejo, String nombreProductoNuevo, DateTime nuevaFecha)
        {
            TryFechaCorrecta(nuevaFecha, "Error: La fecha debe ser posterior al 2000");
            TryFechaVersiones(nuevaFecha, nombreProductoViejo, "Error: La fecha del producto debe ser posterior a las versiones");
            Producto producto = new Producto(nombreProductoNuevo, nuevaFecha);
        }

        private void TryFechaVersiones(DateTime nuevaFecha, String nombreProductoViejo, String mensaje)
        {
            DateTime menorFecha = GetMenorFechaVersion(nombreProductoViejo);
            if (nuevaFecha < menorFecha && GetListaVersionesVersionProducto(nombreProductoViejo).Count() != 0)
            {
                throw new VersionException(mensaje);
            }
        }

        private DateTime GetMenorFechaVersion(String nombreProductoViejo)
        {
            DateTime fechaMenor = DateTime.Now;
            IEnumerable<Dominio.Version> listaV = GetListaVersionesVersionProducto(nombreProductoViejo);
            for (int i = 0; i < listaV.Count(); i++)
            {
                if (listaV.ElementAt(i).GetFechaCreacion() < fechaMenor)
                {
                    fechaMenor = listaV.ElementAt(i).GetFechaCreacion();
                }
            }
            return fechaMenor;
        }

        private void TryNombreNuevoProducto(String nombreProductoViejo, String nombreProductoNuevo)
        {
            if (!nombreProductoViejo.Equals(nombreProductoNuevo))
            {
                TryNombreProductoAModificar(nombreProductoNuevo);
            }
        }

        private void TryNombreProductoAModificar(String nombreProductoNuevo)
        {
            if (ExisteProducto(nombreProductoNuevo))
            {
                throw new ProductoServiceException("Error: ya existe un Producto con ese nombre");
            }
        }

        private void ModificarDatos(String nombreProductoViejo, String nombreProductoNuevo, DateTime nuevaFecha)
        {
            Producto producto = this.GetProducto(nombreProductoViejo);
            producto.SetNombre(nombreProductoNuevo);
            producto.SetFechaInicial(nuevaFecha);
            this.IProductoDB.ModificarProducto(producto);
        }

        public void ModificarVersion(String nombreProducto, String etiquetaVieja, String etiquetaNueva, String estado, DateTime fecha)
        {
            TryDatosNuevosVersion(nombreProducto, etiquetaNueva, estado, fecha);
            TryEtiquetaNuevaVersion(etiquetaVieja, etiquetaNueva, nombreProducto);
            ModificarDatosVersion(nombreProducto, etiquetaVieja, etiquetaNueva, estado, fecha);
        }

        public void AddDataSet(String nombreProducto, String etiquetaVersion, DataSet dataSet)
        {
            Dominio.Version version = GetVersionProducto(nombreProducto, etiquetaVersion);
            ValidarExisteDataSet(dataSet);
            version.AddDataSet(dataSet);
        }

        private void ValidarExisteDataSet(DataSet dataSet)
        {
            if(dataSet == null)
            {
                throw new ProductoServiceException("ERROR: No existe DataSet");
            }
        }

        public DataSet GetDataSet(String nombreProducto, String etiquetaVersion, String nombreDataSet)
        {
            Dominio.Version version = GetVersionProducto(nombreProducto, etiquetaVersion);
            ValidarNombreDataSetNoVacio(nombreDataSet);
            return version.GetDataSets().FirstOrDefault(d => d.GetNombre() == nombreDataSet);
        }

        private void ValidarNombreDataSetNoVacio(String nombre)
        {
            if(nombre == null || nombre.Equals(""))
            {
                throw new ProductoServiceException("ERROR: Nombre DataSet vacio");
            }
        }

        private void TryDatosNuevosVersion(String nombreProducto, String etiquetaNueva, String estado, DateTime fecha)
        {
            Producto prod = this.GetProducto(nombreProducto);
            TryFechaCreacion(prod, fecha, "Error: La fecha debe ser posterior o igual a la del producto");
            Dominio.Version v = new Dominio.Version(etiquetaNueva, estado, prod, fecha);
        }

        private void TryEtiquetaNuevaVersion(String etiquetaVieja, String etiquetaNueva, String nombreProducto)
        {
            if (!etiquetaVieja.Equals(etiquetaNueva))
            {
                TryEtiquetaVersionAModificar(nombreProducto, etiquetaNueva);
            }
        }

        private void TryEtiquetaVersionAModificar(String nombreProducto, String etiquetaNueva)
        {
            if (GetVersion(this.GetProducto(nombreProducto), etiquetaNueva) != null)
            {
                throw new VersionException("Error: ya existe una Version para este producto con esa etiqueta");
            }
        }

        private void ModificarDatosVersion(String nombreProducto, String etiquetaVieja, String etiquetaNueva, String estado, DateTime fecha)
        {           
            Dominio.Version v = GetVersion(this.GetProducto(nombreProducto), etiquetaVieja);
            this.IProductoDB.EliminarVersionProducto(this.GetProducto(nombreProducto), GetVersion(this.GetProducto(nombreProducto), etiquetaVieja));
            v.SetEstado(estado);
            v.SetEtiqueta(etiquetaNueva);
            v.SetFechaCreacion(fecha);
            this.IProductoDB.AgregarVersionProducto(this.GetProducto(nombreProducto), v);
        }
   
        public IEnumerable<DataSet> GetDataSets(String nombreProducto, String etiquetaVersion)
        {
            Dominio.Version version = GetVersionProducto(nombreProducto, etiquetaVersion);
            TryExistenDataSets(version);
            return version.GetDataSets();
        }

        private void TryExistenDataSets(Dominio.Version version)
        {
            if(version.GetDataSets() == null)
            {
                throw new ProductoServiceException("ERROR: No existen DataSets");
            }
        }
    }
}
