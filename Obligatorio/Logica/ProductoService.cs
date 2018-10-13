using Dominio;
using InterfazServiceUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{ 
    public class ProductoService: IProductoService
    {
        private List<Producto> listaProductos;

        public ProductoService()
        {
            this.listaProductos = new List<Producto>();
        }

        public void AltaProducto(String nombre)
        {
            if (!ExisteProducto(nombre))
            {
                AgregarProducto(nombre);
            }
            else
            {
                throw new ProductoServiceException("Error: Ya existe producto con el mismo nombre");
            }
        }

        private void AgregarProducto(String nombre)
        {
            Producto producto = new Producto(nombre);
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
            if (this.listaProductos.FirstOrDefault(p => p.nombre == nombre) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AltaVersion(String nombreProducto, String etiqueta, String estado)
        {
            TryProductoInexistente(nombreProducto, "Error: No existe el producto");
            Producto producto = this.listaProductos.FirstOrDefault(p => p.nombre == nombreProducto);
            TryVersionUnica(producto, etiqueta, "Error: Ya existe esa version para el producto");
            AgregarVersion(producto, etiqueta, estado);
        }

        private void TryVersionUnica(Producto producto, String etiqueta, String mensaje)
        {
            if (producto.GetVersiones().FirstOrDefault(v => v.etiqueta == etiqueta) != null)
            {
                throw new VersionException(mensaje);
            }
        }

        private void AgregarVersion(Producto producto, String etiqueta, String estado)
        {
            Dominio.Version version = new Dominio.Version(etiqueta, estado, producto);
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

        public Dominio.Version GetVersion(Producto producto, String etiqueta)
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

        public void ModificarProducto()
        {

        }

        public void AddDataSet(String nombreProducto, String etiquetaVersion, DataSet dataSet)
        {
            TryProductoInexistente(nombreProducto, "Error: No existe el producto");
            Producto producto = this.listaProductos.FirstOrDefault(p => p.nombre == nombreProducto);
            TryExisteVersion(producto, etiquetaVersion, "Error: No existe la version");
            Dominio.Version version = GetVersion(producto, etiquetaVersion);
            version.dataset.Add(dataSet);
        }

       
    }
}
