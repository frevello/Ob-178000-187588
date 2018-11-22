using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfazServiceUI;
using InterfazAccesoDatos;
using AccesoDatos;
using AccesoDatosCsv;

namespace Interfaz_de_usuario
{
    public partial class ValidarArchivo : UserControl
    {
        private const String EXT_TXT = "txt";
        private const String EXT_CSV = "csv";

        public ValidarArchivo()
        {
            InitializeComponent();
        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            String path = GetPathDataSet();
            ILoadDataSet l = ExtensionArchivo(path);
            try
            {
                l.ValidarFormatoDataSet();
                MessageBox.Show("Archivo correcto");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private String GetPathDataSet()
        {
            String path = "";
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = "./";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                }
            }
            return path;
        }
        private ILoadDataSet ExtensionArchivo(String path)
        {
            ILoadDataSet l;
            String[] split = path.Split('.');
            String ext = split[split.Length - 1];
            if (ext.Equals(EXT_TXT))
            {
                 l = new LoadDataSet(path);
            }
            else
            {
                 l = new LoadCsvDataSet(path);
            }
            return l;
        }

    }
}
