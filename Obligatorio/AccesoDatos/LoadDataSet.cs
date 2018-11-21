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
            
            ValidarFormatoDataSet();
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
                CargarRegistro(line);
                line = ObtenerNextLine();
            }
            creator.FinGrupoRegistro();
        }


        private void CargarRegistro(String line)
        {
            creator.CargarRegistro(line);
        }

        private String ObtenerNextLine()
        {
            return reader.GetNextLine();
        }

        private void EndDataSet()
        {
            creator.EndDataSet();
            reader.EndReading();
        }

        public void ValidarFormatoDataSet()
        {
            OpenFile(path);
            ValidarPrimeraLinea();
            ValidarGruposRegistros();
        }
       private void ValidarPrimeraLinea()
        {
            String line = ObtenerNextLine();
            validatorFormat.ValidarPrimeraLinea(line);
        }
        private void ValidarGruposRegistros()
        {
            int countGruposRegistros = 0;
            String line = ObtenerNextLine();
            while (validatorFormat.ExisteLinea(line))
            {
                ValidarGrupoRegistro(line);
                line = ObtenerNextLine();
                countGruposRegistros++;
            }
            reader.EndReading();
            validatorFormat.ValidarFinArchivo(countGruposRegistros);
        }

        private void ValidarGrupoRegistro(String line)
        {
            validatorFormat.IniciaGrupoRegistro();
            while (validatorFormat.ExisteLinea(line) && !validatorFormat.EsFinGrupoRegistro(line))
            {
                validatorFormat.ValidarRegistro(line);
                line = ObtenerNextLine();
            }
          
            validatorFormat.FinGrupoRegistro(line);
        }
    
    }
}
