using Dominio;
using InterfazAccesoDatos;
using System.Collections.Generic;

namespace AccesoDatos
{
   public class LoadDataSet: ILoadDataSet
    {
        private DataSet dataSet;
        private FileReader reader;

        public DataSet CargarDataSet(string path)
        {
            OpenFile(path);


            return dataSet;
        }


       private  void OpenFile(string path)
        {
            reader = new FileReader();
            reader.OpenFile(path);
        }



    }
}
