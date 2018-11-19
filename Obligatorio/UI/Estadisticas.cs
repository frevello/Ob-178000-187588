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
using InterfazUI;
using Logica;

namespace Interfaz_de_usuario
{
    public partial class Estadisticas : UserControl
    {
        private IProductoService productoService;
        private IDataSetService dataSetService;
        private IEstadisticosService estadisticosService;
        private List<String> productos;
        private BindingList<String> versiones;
        private BindingList<String> dataSets;
        private BindingList<String> estadistias;
        private String nombreProducto;
        private String etiquetaVersion;
        private String nombreDataSet;

        public Estadisticas(IProductoService iProductoService, IDataSetService iDataSetService)
        {
            estadisticosService = new EstadisticosService();
            productoService = iProductoService;
            dataSetService = iDataSetService;
            productos = new List<string>();
            nombreProducto = null;
            versiones = new BindingList<String>();
            etiquetaVersion = null;
            dataSets = new BindingList<String>();
            nombreDataSet = null;
            estadistias = new BindingList<String>();
            InitializeComponent();
            CargarListBoxProductos();
        }

        private void CargarListBoxProductos()
        {
            etiquetaVersion = null;
            nombreProducto = null;
            ClearListBoxDataSet();
            ClearListBoxEstadisticas();
            productos.Clear();
            CargarListaProductos();
            SetListaProductos();
        }
        private void ClearListBoxDataSet()
        {
            nombreDataSet = null;
            dataSets.Clear();
            SetListaDataSets();
        }
        private void ClearListBoxEstadisticas()
        {
            estadistias.Clear();
            SetListaEstadisticas();
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

        private void btnSelectVersion_Click(object sender, EventArgs e)
        {
            CargarListBoxEstadisticas();
        }

        private void CargarEstadisticaSiDatosSeleccionados()
        {
            nombreDataSet = listBoxDataSet.GetItemText(listBoxDataSet.SelectedItem);
            if (nombreProducto != null && etiquetaVersion != null && nombreDataSet != null && !etiquetaVersion.Equals("") && !nombreDataSet.Equals("") && !nombreProducto.Equals(""))
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
            if(dataSet != null && dataSet.GetRegistros() != null)
            {
                CargarListBoxEstadistica(dataSet);
            }
        }

        private void CargarListBoxEstadistica(Dominio.DataSet dataSet)
        {
            estadistias.Add("Cantidad de Registros del DataSet: " + estadisticosService.GetCantidadRegistros(dataSet));
            for (int i = 0; i < estadisticosService.GetCantidadRegistros(dataSet); i++)
            {
                VariablesDataSet variables = dataSetService.GetRegistroAtIndex(dataSet, i);
                float promedio = estadisticosService.GetPromedioRegistro(dataSet, variables.GetNombreVariable());
                float minimo = estadisticosService.GetMinimoRegistro(dataSet, variables.GetNombreVariable());
                float maximo = estadisticosService.GetMaximoRegistro(dataSet, variables.GetNombreVariable());
                estadistias.Add(variables.GetNombreVariable() + " Promedio: " + promedio + " Minimo: " + minimo + " Maximo: " + maximo);
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
            etiquetaVersion = null;
            nombreDataSet = null;
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

        private void listBoxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreProducto = listBoxProducto.GetItemText(listBoxProducto.SelectedItem);
            CargarListBoxVersiones();
        }
  
        private void listBoxVersiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearListBoxDataSet();
            ClearListBoxEstadisticas();
            etiquetaVersion = listBoxVersiones.GetItemText(listBoxVersiones.SelectedItem);
            if(etiquetaVersion!= null && !etiquetaVersion.Equals(""))
            {
                CargarListBoxDataSets();
            }

        }
        private void CargarListBoxDataSets()
        {
            nombreDataSet = null;
            dataSets.Clear();
            CargarListaDataSets();
            SetListaDataSets();
        }

        private void CargarListaDataSets()
        {
            IEnumerable<Dominio.DataSet> dataSetsVersion = productoService.GetDataSets(nombreProducto, etiquetaVersion);
            for (int i = 0; i < dataSetsVersion.Count(); i++)
            {
                dataSets.Add(dataSetService.GetNombreDataSet(dataSetsVersion.ElementAt(i)));
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
        }

        private void CargarListBoxEstadisticas()
        {
            estadistias.Clear();
            CargarEstadisticaSiDatosSeleccionados();
            SetListaEstadisticas();
        }

        private void listBoxEstadisticas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
