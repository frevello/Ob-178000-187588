using Dominio;
using InterfazServiceUI;
using System;
using System.Collections.Generic;
using System.Linq;
using InterfazServiceUI;
using System.Text;
using System.Threading.Tasks;
 
namespace Logica
{
    public class ProductoService : IProductoService
    {
        private List<Producto> listaProductos;

        public ProductoService()
        {
            this.listaProductos = new List<Producto>();
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
            if (fecha.Year < 2000)
            {
                throw new ProductoServiceException(mensaje);
            }
        }

        private void AgregarProducto(String nombre, DateTime fecha)
        {
            Producto producto = new Producto(nombre, fecha);
            this.listaProductos.Add(producto);
        }

        public Producto GetProducto(String nombre)
        {
            TryProductoInexistente(nombre, "Error: No existe el producto");
            return this.listaProductos.FirstOrDefault(p => p.nombre == nombre);
        }

        public List<Producto> GetListaProducto()
        {
            return this.listaProductos;
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
            return this.listaProductos.FirstOrDefault(p => p.nombre == nombre) != null;
            
        }

        public void AltaVersion(String nombreProducto, String etiqueta, String estado, DateTime fecha)
        {
            TryProductoInexistente(nombreProducto, "Error: No existe el producto");
            Producto producto = this.listaProductos.FirstOrDefault(p => p.nombre == nombreProducto);
            TryVersionUnica(producto, etiqueta, "Error: Ya existe esa version para el producto");
            TryFechaCreacion(producto, fecha, "Error: La fecha debe ser posterior o igual a la del producto");
            AgregarVersion(producto, etiqueta, estado, fecha);
        }

        private void TryVersionUnica(Producto producto, String etiqueta, String mensaje)
        {
            if (producto.GetVersiones().FirstOrDefault(v => v.etiqueta == etiqueta) != null)
            {
                throw new VersionException(mensaje);
            }
        }

        private void TryFechaCreacion(Producto producto, DateTime fecha, String mensaje)
        {
            if (producto.fechaInicial > fecha)
            {
                throw new VersionException(mensaje);
            }
        }

        private void AgregarVersion(Producto producto, String etiqueta, String estado, DateTime fecha)
        {
            Dominio.Version version = new Dominio.Version(etiqueta, estado, producto, fecha);
            producto.GetVersiones().Add(version);
        }

        public Dominio.Version GetVersionProducto(String nombre, String etiqueta)
        {
            TryProductoInexistente(nombre, "Error: No existe el producto");
            Producto producto = this.listaProductos.FirstOrDefault(p => p.nombre == nombre);
            TryExisteVersion(producto, etiqueta, "Error: No existe la version");
            return GetVersion(producto, etiqueta);
        }

        private void TryExisteVersion(Producto producto, String etiqueta, String mensaje)
        {
            if (producto.GetVersiones().FirstOrDefault(v => v.etiqueta == etiqueta) == null)
            {
                throw new VersionException(mensaje);
            }
        }

        private Dominio.Version GetVersion(Producto producto, String etiqueta)
        {
            return producto.GetVersiones().FirstOrDefault(v => v.etiqueta == etiqueta);
        }

        public List<Dominio.Version> GetListaVersionesVersionProducto(String nombre)
        {
            TryProductoInexistente(nombre, "Error: No existe el producto");
            return GetListaVersiones(nombre);
        }

        private List<Dominio.Version> GetListaVersiones(String nombre)
        {
            Producto producto = this.listaProductos.FirstOrDefault(p => p.nombre == nombre);
            return producto.GetVersiones();
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
            if (nuevaFecha < menorFecha && GetListaVersionesVersionProducto(nombreProductoViejo).Count != 0)
            {
                throw new VersionException(mensaje);
            }
        }

        private DateTime GetMenorFechaVersion(String nombreProductoViejo)
        {
            DateTime fechaMenor = DateTime.Now;
            List<Dominio.Version> listaV = GetListaVersionesVersionProducto(nombreProductoViejo);
            for (int i = 0; i < listaV.Count; i++)
            {
                if (listaV[i].fechaCreacion < fechaMenor)
                {
                    fechaMenor = listaV[i].fechaCreacion;
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
            Producto producto = this.listaProductos.FirstOrDefault(p => p.nombre == nombreProductoViejo);
            producto.nombre = nombreProductoNuevo;
            producto.fechaInicial = nuevaFecha;
        }

        public void ModificarVersion(String nombreProducto, String etiquetaVieja, String etiquetaNueva, String estado, DateTime fecha)
        {
            TryDatosNuevosVersion(nombreProducto, etiquetaNueva, estado, fecha);
            TryEtiquetaNuevaVersion(etiquetaVieja, etiquetaNueva, nombreProducto);
            ModificarDatosVersion(nombreProducto, etiquetaVieja, etiquetaNueva, estado, fecha);
        }

        

        public void AddDataSet(String nombreProducto, String etiquetaVersion, DataSet dataSet)
        {
            TryProductoInexistente(nombreProducto, "Error: No existe el producto");
            Producto producto = this.listaProductos.FirstOrDefault(p => p.nombre == nombreProducto);
            TryExisteVersion(producto, etiquetaVersion, "Error: No existe la version");
            Dominio.Version version = GetVersion(producto, etiquetaVersion);
            version.dataset.Add(dataSet);
        }

        public DataSet GetDataSet(String nombreProducto, String etiquetaVersion, String nombreDataSet)
        {
            Producto producto = GetProducto(nombreProducto);
            Dominio.Version version = GetVersion(producto, etiquetaVersion);
            return version.dataset.FirstOrDefault(d => d.GetNombre() == nombreDataSet);
        }

        public VariablesDataSet GetRegistro(String nombreProducto, String etiquetaVersion, String nombreDataSet, String nombreRegistro)
        {
            DataSet dataSet = this.GetDataSet(nombreProducto, etiquetaVersion, nombreDataSet);
            TryExiteDataSet(dataSet);
            return dataSet.GetRegistros().FirstOrDefault(r => r.nombreVariable == nombreRegistro);
        }

        private void TryExiteDataSet(DataSet dataSet)
        {
           if(dataSet == null)
            {
                throw new ProductoServiceException("ERROR: DataSet no existe");
            }
        }

        private void TryDatosNuevosVersion(String nombreProducto, String etiquetaNueva, String estado, DateTime fecha)
        {
            Producto prod = this.listaProductos.FirstOrDefault(p => p.nombre == nombreProducto);
            TryFechaCreacion(prod, fecha, "Error: La fecha debe ser posterior o igual a la del producto");
            Dominio.Version v = new Dominio.Version(etiquetaNueva, estado, prod, fecha);
        }
        public float GetPromedioRegistro(String nombreProducto, String etiquetaVersion, String nombreDataSet, String nombreRegistro)
        {
            VariablesDataSet variableDataSet = GetRegistro(nombreProducto, etiquetaVersion, nombreDataSet, nombreRegistro);
            return variableDataSet.datosRegistro.Average();
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
            if (GetVersion(this.listaProductos.FirstOrDefault(p => p.nombre == nombreProducto), etiquetaNueva) != null)
            {
                throw new VersionException("Error: ya existe una Version para este producto con esa etiqueta");
            }
        }

        private void ModificarDatosVersion(String nombreProducto, String etiquetaVieja, String etiquetaNueva, String estado, DateTime fecha)
        {
            Dominio.Version v = GetVersion(this.listaProductos.FirstOrDefault(p => p.nombre == nombreProducto), etiquetaVieja);
            v.estado = estado;
            v.etiqueta = etiquetaNueva;
            v.fechaCreacion = fecha;
        }
        public float GetMinimoRegistro(String nombreProducto, String etiquetaVersion, String nombreDataSet, String nombreRegistro)
        {
            VariablesDataSet variableDataSet = GetRegistro(nombreProducto, etiquetaVersion, nombreDataSet, nombreRegistro);
            return variableDataSet.datosRegistro.Min();
        }
        public float GetMaximoRegistro(String nombreProducto, String etiquetaVersion, String nombreDataSet, String nombreRegistro)
        {
            VariablesDataSet variableDataSet = GetRegistro(nombreProducto, etiquetaVersion, nombreDataSet, nombreRegistro);
            return variableDataSet.datosRegistro.Max();
        }

    }
}
