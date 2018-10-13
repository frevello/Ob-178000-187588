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

namespace Interfaz_de_usuario
{
    public partial class VisualizarDataSet : UserControl
    {
        private IProductoService productoService;
        private List<String> nombresRegistros;
        private Dominio.DataSet dataSet;

        public VisualizarDataSet(IProductoService iProductoService, Dominio.DataSet dataSet)
        {
            productoService = iProductoService;
            this.dataSet = dataSet;
            nombresRegistros = new List<string>();
            InitializeComponent();
        }

        private void CargarListBoxNombresRegistros()
        {
            nombresRegistros.Clear();
            CargarListaNombresRegistros();
            SetListaNombresRegistros();
        }

        private void CargarListaNombresRegistros()
        {
            for (int i = 0; i < dataSet.GetNomresRegistros().Count(); i++)
            {
                nombresRegistros.Add(dataSet.GetNomresRegistros().ElementAt(i));
            }
        }

        private void SetListaNombresRegistros()
        {
            this.listBoxNombresRegistros.DataSource = nombresRegistros;
        }
    }
}
