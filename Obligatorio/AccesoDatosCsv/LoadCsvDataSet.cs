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
        private CsvReader reader;
        private ValidatorFormatCsv validatorFormat;
        private CreatorCsv creator;
        private String path;

        public LoadCsvDataSet(String pathDataSet)
        {
            validatorFormat = new ValidatorFormatCsv();
            path = pathDataSet;
            creator = new CreatorCsv(path);
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
                validatorFormat.ValidarRegistro(line);
                line = ObtenerNextLine();
                countGruposRegistros++;
            }
            reader.EndReading();
            validatorFormat.ValidarFinArchivo(countGruposRegistros);
        }
        
        public DataSet CargarDataSet()
        {
            ValidarFormatoDataSet();
            OpenFile(path);
            CargarVARDEF();
            CargarGruposRegistros();
            return creator.DevolverDataSet();
        }
        private void OpenFile(String path)
        {
            reader = new CsvReader();
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
            creator.AddGrupoRegistro(line);
            creator.FinGrupoRegistro();
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
    }
}
