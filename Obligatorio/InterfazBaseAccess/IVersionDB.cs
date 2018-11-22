using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazBaseAccess
{   
    public interface IVersionDB
    {
        void AgregarVersion(Dominio.Version version);
        void ModificarVersion(Dominio.Version version);
        bool ExisteVersion(string etiqueta);
        Dominio.Version GetVersion(string etiqueta);
        List<Dominio.Version> GetListaVersion();
        List<DataSet> GetListaDataSet(string etiqueta);
    }
}
