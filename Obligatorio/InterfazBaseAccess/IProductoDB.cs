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
        Dominio.Version GetVersion(string etiqueta, string nombreProducto);
        DataSet GetDataSet(string nombreProducto, string etiquetVersion, string nombreDataSet);
        List<Producto> GetListaProductos();
        List<Dominio.Version> GetListaVersionesProducto(string nombreProducto);
        List<DataSet> GetListaDataSetVersion(string nombreProducto, string etiquetaVersion);
        void AgregarVersionProducto(Producto producto, Dominio.Version version);
        void EliminarVersionProducto(Producto producto, Dominio.Version version);
        void AgregarDataSetVersion(Producto producto, Dominio.Version version, DataSet dataSet);
        void AgregarVariableDataSet(DataSet dataSet, VariablesDataSet variableDataSet);
    }
}
