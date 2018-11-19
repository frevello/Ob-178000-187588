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
using Logica;

namespace Interfaz_de_usuario
{
    public partial class ListaDataSet : UserControl
    {
        private IProductoService productoService;
        private IDataSetService dataSetService;
        private List<String> productos;
        private BindingList<String> versiones;
        private String nombreProducto;
        private String etiquetaVersion;
        private Panel panelPrincipal;

        public ListaDataSet(IProductoService iProductoService, Panel panelpricipal, IDataSetService iDataSetService)
        {
            productoService = iProductoService;
            dataSetService = iDataSetService;
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
                productos.Add(productoService.GetListaProducto()[i].GetNombre());
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
            for (int i = 0; i < productoService.GetListaVersionesVersionProducto(nombreProducto).Count(); i++)
            {
                 versiones.Add(productoService.GetListaVersionesVersionProducto(nombreProducto).ElementAt(i).GetEtiqueta());
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
                SiExistenDataSetsIrAVisualizarDataSets();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un producto, una version y un dataSet");
            }
        }

        private void SiExistenDataSetsIrAVisualizarDataSets()
        {
            if (ExistenDataSets())
            {
                IrAVisualizarDataSet();
            }
        }

        private Boolean ExistenDataSets()
        {
            IEnumerable<Dominio.DataSet> dataSets = GetDataSets();
            if (dataSets == null || dataSets.Count() == 0 )
            {
                MessageBox.Show("No tiene dataSets cargados");
                return false;
            }
            return true;
        }

        private IEnumerable<Dominio.DataSet> GetDataSets()
        {
            if (TryGetDataSets())
            {
                return productoService.GetDataSets(nombreProducto, etiquetaVersion);
            }
            else
            {
                return null;
            }
            
        }
        private Boolean TryGetDataSets()
        {
            try
            {
                IEnumerable<Dominio.DataSet> dataSets = productoService.GetDataSets(nombreProducto, etiquetaVersion);
                return true;
            }catch(VersionException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        private void IrAVisualizarDataSet()
        {
            VisualizarDataSet visualiar = new VisualizarDataSet(productoService,nombreProducto, etiquetaVersion, panelPrincipal, dataSetService);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
