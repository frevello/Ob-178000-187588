
using Dominio;

namespace InterfazAccesoDatos
{
    public interface ILoadDataSet
    {
        DataSet CargarDataSet();
        void ValidarFormatoDataSet();
    }
}
