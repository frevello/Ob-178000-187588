using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazServiceUI
{
    public interface IProductoService
    {
        void AltaProducto(String nombre, DateTime fecha);
        Producto GetProducto(String nombre);
        List<Producto> GetListaProducto();
        Boolean ExisteProducto(String nombre);
        void AltaVersion(String nombreProducto, String etiqueta, String estado, DateTime fecha);
        Dominio.Version GetVersionProducto(String nombre, String etiqueta);
        IEnumerable<Dominio.Version> GetListaVersionesVersionProducto(String nombre);
        void ModificarProducto(String nombreProductoViejo, String nombreProductoNuevo, DateTime nuevaFecha);
        void ModificarVersion(String nombreProducto, String etiquetaVieja, String etiquetaNueva, String estado, DateTime fecha);
        void AddDataSet(String nombreProducto, String etiquetaVersion, DataSet dataSet);
        Dominio.DataSet GetDataSet(String nombreProducto, String etiquetaVersion, String nombreDataSet);
        IEnumerable<DataSet> GetDataSets(String nombreProducto, String etiquetaVersion);
    }
}
