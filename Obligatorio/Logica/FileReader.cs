using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Logica
{
    public class FileReader
    {
        private StreamReader reader;

        private Dictionary<String, int> variables;

        private const String TIME = "TIME";
        private const String VARDEF = "VARDEF=";
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

        public Boolean ValidarFormatoArchivo()
        {
            LeerPrimeraLinea();
            String linea = reader.ReadLine();
            int nroLinea = 0;
            while (linea != null )
            {

                
            }

            return false;
        }

        private void LeerPrimeraLinea()
        {
            String linea = reader.ReadLine();
            ValidarLineaContieneVARDEF(linea, 1);
            ValidarLineaContieneTIME(linea, 1);
            CargarVariablesPrimeraLinea(linea);       
        }

        private void ValidarLineaContieneVARDEF(String line, int nroLinea)
        {
            if (!line.StartsWith(VARDEF))
            {
                throw new FileReaderException("ERROR: en linea " + nroLinea + " falta VARDEF");
            }
        }

        private void ValidarLineaContieneTIME(String line, int nroLinea)
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
                variables.Add(vars[i], 0);
            }
        }

        private String[] ObtenerVariablesPrimeraLinea(String linea)
        {
            EliminarDeLineaVARDEF(linea);
            return linea.Split(',');
        }

        private String EliminarDeLineaVARDEF(String linea)
        {
            String[] lineaSplitIgual = linea.Split('=');
            return lineaSplitIgual[1];
        }

        private void LeerRegistro()
        {
            String linea = reader.ReadLine();
            int nroLinea = 1;
            while (linea != null)
            {
                ValidarLineaContieneIgual(linea, nroLinea);
                String[] var = SepararVariableDeDato(linea, nroLinea);
                
            }
        }

        private void ValidarVariableExista()
        {
            // validar que exista variable en variables
        }

        private void ValidarLineaContieneIgual(String linea, int nroLinea)
        {
            if (!linea.Contains('='))
            {
                throw new FileReaderException("ERROR: en linea " + nroLinea);
            }
        }

       
        private String[] SepararVariableDeDato(String linea, int nroLinea)
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
