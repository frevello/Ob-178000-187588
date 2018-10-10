using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AccesoDatos
{
    public class FileReader
    {
        private StreamReader reader;
        private List<string> variables = new List<string>();
        private int nroLinea = 1;

        private const String TIME = "TIME";
        private const String VARDEF = "VARDEF";
        private const String FIN_REGISTRO = "#";

        public void OpenFile(string path)
        {
            try
            {
                TryOpenFile(path);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileReaderException(ex);
            }
        }

        private void TryOpenFile(string path)
        {
             reader = new StreamReader(path);
        }


        public void ValidarFormatoArchivo()
        {
            ValidarPrimeraLinea();
            ValidarRegistros();
        }

        private void ValidarPrimeraLinea()
        {
            String linea = reader.ReadLine();
            ValidarLineaContieneVARDEF(linea);
            ValidarLineaContieneTIME(linea);
            CargarVariablesPrimeraLinea(linea);       
        }

        private void ValidarRegistros()
        {
            String linea = reader.ReadLine();
            nroLinea++;
            while (linea != null)
            {
                ValidarRegistro(linea);
                linea = reader.ReadLine();
                nroLinea++;
            }
        }

        private void ValidarLineaContieneVARDEF(String line)
        {
            if (!line.StartsWith(VARDEF))
            {
                throw new FileReaderException("ERROR: en linea " + nroLinea + " falta VARDEF");
            }
        }

        private void ValidarLineaContieneTIME(String line)
        {
            if (!line.Contains(TIME))
            {
                throw new FileReaderException("ERROR: en linea " + nroLinea + " falta TIME");
            }
        }

        private void CargarVariablesPrimeraLinea(String linea)
        {
            String[] vars = ObtenerVariablesPrimeraLinea(linea);
            for (int i = 0; i < vars.Length; i++)
            {
                variables.Add(vars[i]);
            }
        }

        private String[] ObtenerVariablesPrimeraLinea(String linea)
        {
            linea = EliminarDeLineaVARDEF(linea);
            return linea.Split(',');
        }

        private String EliminarDeLineaVARDEF(String linea)
        {
            String[] lineaSplitIgual = linea.Split('=');
            return lineaSplitIgual[1];
        }

        private void ValidarRegistro(String linea)
        {
            
            List<string> variablesRegistro = new List<string>();
            while (linea != null && !linea.Equals(FIN_REGISTRO))
            {
                ValidarLineaContieneIgual(linea);
                String[] vars = SepararVariableDeDato(linea);
                String var = vars[0];
                String dato = vars[1];
                ValidarVariableExistaVARDEF(var);
                ValidarVariableNoExistaEnRegistro(var, variablesRegistro);
                ValidarFormatoDato(dato);
                /////// AGREGAR EN DATA SETTT /////

                variablesRegistro.Add(var);
                linea = reader.ReadLine();
                nroLinea++;
                
            }

            if(linea == null)
            {
                throw new FileReaderException("ERROR: en linea " + nroLinea + " falta fin del registro");
            }

        }

        private void ValidarVariableExistaVARDEF(String variable)
        {
            if (!variables.Contains(variable))
            {
                throw new FileReaderException("ERROR: en linea " + nroLinea + " variable no definida");
            }
        }

        private void ValidarVariableNoExistaEnRegistro(String variable, List<string> variablesRegistro)
        {
            if (variablesRegistro.Contains(variable))
            {
                throw new FileReaderException("ERROR: en linea " + nroLinea + " variable repetida en registro");
            }
        }
        private void ValidarFormatoDato(string dato)
        {
            try
            {
                float fltDato = float.Parse(dato);
            }
            catch (Exception e)
            {
                throw new FileReaderException("ERROR: en la linea " + nroLinea + " formato del dato incorrecto");
            }
        }
        private void ValidarVariablesDeRegistroExisteTIME(List<string> variablesRegistro)
        {
            if (!variablesRegistro.Contains(TIME))
            {
                throw new FileReaderException("ERROR: en linea " + nroLinea + " variable TIME no definida");
            }
        }

        private void ValidarLineaContieneIgual(String linea)
        {
            if (!linea.Contains('='))
            {
                throw new FileReaderException("ERROR: en linea " + nroLinea + " falta simbolo =");
            }
        }

       
        private String[] SepararVariableDeDato(String linea)
        {
            String[] datos = linea.Split('=');
            if (datos.Length != 2)
            {
                throw new FileReaderException("ERROR: en linea " + nroLinea);
            }
            return datos;
        }
       
    }
}
