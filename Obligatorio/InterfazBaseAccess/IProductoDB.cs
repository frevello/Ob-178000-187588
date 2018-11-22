using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazBaseAccess
{ 
    public interface IProductoDB
    {
        void AgregarProducto(Producto producto);
        void ModificarProducto(Producto producto);
        bool ExisteProducto(string nombreProducto);
        Producto GetProducto(string nombreProducto);
        List<Producto> GetListaProductos();
        List<Dominio.Version> GetListaVersionesProducto(string nombreProducto);
        void AgregarVersionProducto(Producto producto, Dominio.Version version);
        void EliminarVersionProducto(Producto producto, Dominio.Version version);
    }
}
