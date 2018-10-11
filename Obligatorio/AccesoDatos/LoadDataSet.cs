using Dominio;
using InterfazAccesoDatos;
using System;
using System.Collections.Generic;

namespace AccesoDatos
{
   public class LoadDataSet: ILoadDataSet
    {
        private FileReader reader;
        private ValidatorFormat validatorFormat;
        private Creator creator;
        private String path;

        public LoadDataSet(String path)
        {
            validatorFormat = new ValidatorFormat();
            creator = new Creator(path);
        }

        public DataSet CargarDataSet()
        {
            OpenFile(path);
            CargarVARDEF();

            return null;
        }


       private  void OpenFile(string path)
        {
            reader = new FileReader();
            reader.OpenFile(path);
        }

        private void CargarVARDEF()
        {
            String line = reader.getNextLine();
            validatorFormat.ValidarPrimeraLinea(line);
            creator.cargarRegistrosVARDEF(line);

        }
       
        private void CargarRegistros()
        {

        }

        private void CargarRegistro()
        {


        }


        private void ObtenerRegistro()
        {
            String line = reader.getNextLine();
            while (line != null)
            {
                validatorFormat.ValidarRegistro(line);

                line = reader.getNextLine();
            }
        }

    }
}
