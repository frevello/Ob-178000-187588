using Dominio;
using InterfazAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosCsv
{
    public class LoadCsvDataSet : ILoadDataSet
    {
        public LoadCsvDataSet(String pathDataSet)
        {
           /* validatorFormat = new ValidatorFormat();
            path = pathDataSet;
            creator = new Creator(path);*/
        }
        public DataSet CargarDataSet()
        {
            throw new NotImplementedException();
        }

        public void ValidarFormatoDataSet()
        {
            throw new NotImplementedException();
        }
    }
}
