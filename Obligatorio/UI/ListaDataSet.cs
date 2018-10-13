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
    public partial class ListaDataSet : UserControl
    {
        private IProductoService productoService;
        private List<String> productos;
        private BindingList<String> versiones;
        private BindingList<String> dataSets;
        private String nombreProducto;
        private String etiquetaVersion;

        public ListaDataSet(IProductoService iProductoService)
        {
            productoService = iProductoService;
            productos = new List<string>();
            nombreProducto = null;
            versiones = new BindingList<string>();
            etiquetaVersion = null;
            dataSets = new BindingList<string>();
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDataSet_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectProducto_Click(object sender, EventArgs e)
        {

        }
    }
}
