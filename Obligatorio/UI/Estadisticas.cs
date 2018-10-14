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
using Dominio;

namespace Interfaz_de_usuario
{
    public partial class Estadisticas : UserControl
    {
        private IProductoService productoService;
        private List<String> productos;
        private BindingList<String> versiones;
        private BindingList<String> dataSets;
        private BindingList<String> estadistias;
        private String nombreProducto;
        private String etiquetaVersion;
        private String nombreDataSet;

        public Estadisticas(IProductoService iProductoService)
        {
            productoService = iProductoService;
            productos = new List<string>();
            nombreProducto = null;
            versiones = new BindingList<string>();
            etiquetaVersion = null;
            dataSets = new BindingList<string>();
            nombreDataSet = null;
            estadistias = new BindingList<string>();
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

        private void btnSelectVersion_Click(object sender, EventArgs e)
        {
            CargarEstadisticaSiDatosSeleccionados();
            SetListaEstadisticas();
        }

        private void CargarEstadisticaSiDatosSeleccionados()
        {
            nombreDataSet = listBoxDataSet.GetItemText(listBoxDataSet.SelectedItem);
            if (nombreProducto != null && etiquetaVersion != null && nombreDataSet != null)
            {
                CargarEstadisticas();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un producto, una version y un dataSet");
            }
        }
        private void CargarEstadisticas()
        {
            Dominio.DataSet dataSet = productoService.GetDataSet(nombreProducto, etiquetaVersion, nombreDataSet);
            estadistias.Add("Cantidad de Registros del DataSet: " + dataSet.GetRegistros().Count());
            for (int i = 0; i < dataSet.GetRegistros().Count(); i++)
            {
                VariablesDataSet variables = dataSet.GetRegistros().ElementAt(i);
                float promedio = productoService.GetPromedioRegistro(nombreProducto, etiquetaVersion, nombreDataSet, variables.nombreVariable);
                float minimo = productoService.GetMinimoRegistro(nombreProducto, etiquetaVersion, nombreDataSet, variables.nombreVariable);
                float maximo = productoService.GetMaximoRegistro(nombreProducto, etiquetaVersion, nombreDataSet, variables.nombreVariable);
                estadistias.Add(variables.nombreVariable + " Promedio: " + promedio + " Minimo: " + minimo + " Maximo: " + maximo);

            }
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void listBoxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreProducto = listBoxProducto.GetItemText(listBoxProducto.SelectedItem);
            CargarListBoxVersiones();
        }

        private void listBoxVersiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            etiquetaVersion = listBoxVersiones.GetItemText(listBoxVersiones.SelectedItem);
            CargarListBoxDataSets();
        }
        private void CargarListBoxDataSets()
        {
            CargarListaDataSets();
            SetListaDataSets();
        }
        private void CargarListaDataSets()
        {
            for (int i = 0; i < productoService.GetVersionProducto(nombreProducto, etiquetaVersion).dataset.Count; i++)
            {
                dataSets.Add(productoService.GetVersionProducto(nombreProducto, etiquetaVersion).dataset[i].GetNombre());
            }
        }
        private void SetListaDataSets()
        {
            this.listBoxDataSet.DataSource = dataSets;
        }
        private void SetListaEstadisticas()
        {
            this.listBoxEstadisticas.DataSource = estadistias;
        }
        private void listBoxDataSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEstadisticaSiDatosSeleccionados();
            SetListaEstadisticas();
        }
    }
}
