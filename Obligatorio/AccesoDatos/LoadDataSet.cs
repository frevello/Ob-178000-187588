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

        public LoadDataSet(String pathDataSet)
        {
            validatorFormat = new ValidatorFormat();
            path = pathDataSet;
            creator = new Creator(path);
        }

        public DataSet CargarDataSet()
        {
            OpenFile(path);
            CargarVARDEF();
            CargarGruposRegistros();
            return creator.DevolverDataSet();
        }

       private  void OpenFile(String path)
        {
            reader = new FileReader();
            reader.OpenFile(path);
        }

        private void CargarVARDEF()
        {
            String line = ObtenerNextLine();
            validatorFormat.ValidarPrimeraLinea(line);
            creator.CargarRegistrosVARDEF(line);
        }
       
        private void CargarGruposRegistros()
        {
            String line = ObtenerNextLine();
            while (validatorFormat.ExisteLinea(line))
            {
                CargarGrupoRegistro(line);
                line = ObtenerNextLine();
            }
            EndDataSet();
        }

        private void CargarGrupoRegistro(String line)
        {
            creator.IniciaGrupoRegistro();
            while (validatorFormat.ExisteLinea(line) && !validatorFormat.EsFinGrupoRegistro(line))
            {
                ValidarYCargarRegistro(line);
                line = ObtenerNextLine();
            }
            validatorFormat.ValidarFinRegistroCorrecto(line);
            creator.FinGrupoRegistro();
        }


        private void ValidarYCargarRegistro(String line)
        {
            validatorFormat.ValidarRegistro(line);
            creator.CargarRegistro(line);
        }

        private String ObtenerNextLine()
        {
            return reader.GetNextLine();
        }

        private void EndDataSet()
        {
            reader.EndReading();
        }

    }
}
