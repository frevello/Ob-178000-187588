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
        void AltaProducto(String nombre);
        Producto GetProducto(String nombre);
        List<Producto> GetListaProducto();
        Boolean ExisteProducto(String nombre);
        void AltaVersion(String nombreProducto, String etiqueta, String estado);
        Dominio.Version GetVersionProducto(String nombre, String etiqueta);
        List<Dominio.Version> GetListaVersionesVersionProducto(String nombre);
        void AddDataSet(String nombreProducto, String etiquetaVersion, DataSet dataSet);
        Dominio.DataSet GetDataSet(String nombreProducto, String etiquetaVersion, String nombreDataSet);
        VariablesDataSet GetRegistro(String nombreProducto, String etiquetaVersion, String nombreDataSet, String nombreRegistro);
        float GetPromedioRegistro(String nombreProducto, String etiquetaVersion, String nombreDataSet, String nombreRegistro);
        float GetMinimoRegistro(String nombreProducto, String etiquetaVersion, String nombreDataSet, String nombreRegistro);
        float GetMaximoRegistro(String nombreProducto, String etiquetaVersion, String nombreDataSet, String nombreRegistro);


    }
}
