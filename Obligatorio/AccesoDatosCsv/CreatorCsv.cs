using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosCsv
{
    public class CreatorCsv
    {
        private DataSet dataSet;
        public CreatorCsv(String path)
        {
            dataSet = new DataSet(path);
        }

    }
}
