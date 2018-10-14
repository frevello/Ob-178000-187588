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
        private String nombreProducto;
        private String etiquetaVersion;
        private Panel panelPrincipal;

        public ListaDataSet(IProductoService iProductoService, Panel panelpricipal)
        {
            productoService = iProductoService;
            this.panelPrincipal = panelpricipal;
            productos = new List<string>();
            nombreProducto = null;
            versiones = new BindingList<string>();
            etiquetaVersion = null;
            InitializeComponent();
            CargarListBoxProductos();
        }

        private void CargarListBoxProductos()
        {
            productos.Clear();
            CargarListaProductos();
            SetListaProductos();
        }

        private void CargarListaProductos()
        {
            for (int i = 0; i < productoService.GetListaProducto().Count; i++)
            {
                productos.Add(productoService.GetListaProducto()[i].nombre);
            }
        }

        private void SetListaProductos()
        {
            this.listBoxProducto.DataSource = productos;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void btnSelectProducto_Click(object sender, EventArgs e)
        {
            nombreProducto = listBoxProducto.GetItemText(listBoxProducto.SelectedItem);
            CargarListBoxVersiones();
        }
        private void CargarListBoxVersiones()
        {
            versiones.Clear();
            CargarListaVersiones();
            SetListaVersiones();
        }
        private void CargarListaVersiones()
        {
            for (int i = 0; i < productoService.GetListaVersionesVersionProducto(nombreProducto).Count; i++)
            {
                 versiones.Add(productoService.GetListaVersionesVersionProducto(nombreProducto)[i].etiqueta);
            }
        }
        private void SetListaVersiones()
        {
            this.listBoxVersiones.DataSource = versiones;
        }

        private void btnSelectVersion_Click(object sender, EventArgs e)
        {
            etiquetaVersion = listBoxVersiones.GetItemText(listBoxVersiones.SelectedItem);
            if (nombreProducto != null && etiquetaVersion != null)
            {
                IrAVisualizarDataSet();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un producto, una version y un dataSet");
            }
        }
        

        private void IrAVisualizarDataSet()
        {
            VisualizarDataSet visualiar = new VisualizarDataSet(productoService,nombreProducto, etiquetaVersion, panelPrincipal);
            this.panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(visualiar);
        }

        private void textTitulo_Click(object sender, EventArgs e)
        {

        }

        private void listBoxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreProducto = listBoxProducto.GetItemText(listBoxProducto.SelectedItem);
            CargarListBoxVersiones();
        }
    }
}
