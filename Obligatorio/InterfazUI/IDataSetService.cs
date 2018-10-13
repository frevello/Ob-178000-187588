using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazServiceUI
{
    public interface IDataSetService
    {
        DataSet CargarDataSet(String path);
    }
}
