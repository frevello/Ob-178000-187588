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
    public partial class VisualizarDataSet : UserControl
    {
        private IProductoService productoService;
        private IDataSetService dataSetService;
        private IEstadisticosService estadisticosService;
        private BindingList<String> nombresRegistros;
        private List<String> dataSets;
        private String nombreProducto;
        private String etiquetaVersion;
        private String nombreDataSet;
        private Panel panelPrincipal;

        private const String REGISTRO_TIME = "TIME"; 

        public VisualizarDataSet(IProductoService iProductoService, String nombreProducto, String etiquetaVersion, Panel panelPrincipal, IDataSetService iDataSetService)
        {
            estadisticosService = new EstadisticosService();
            productoService = iProductoService;
            dataSetService = iDataSetService;
            this.panelPrincipal = panelPrincipal;
            this.nombreProducto = nombreProducto;
            this.etiquetaVersion = etiquetaVersion;
            this.dataSets = new List<string>();
            nombresRegistros = new BindingList<String>();
            InitializeComponent();
            CargarListBoxDataSets();
        }

        private void CargarListBoxDataSets()
        {
            CargarListaDataSets();
            SetListaDataSets();
        }
        private void CargarListaDataSets()
        {
            for (int i = 0; i < productoService.GetVersionProducto(nombreProducto, etiquetaVersion).GetDataSets().Count(); i++)
            {
                dataSets.Add(productoService.GetVersionProducto(nombreProducto, etiquetaVersion).GetDataSets().ElementAt(i).GetNombre());
            }
        }
        private void SetListaDataSets()
        {
            this.listBoxDataSet.DataSource = dataSets;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            nombreDataSet = listBoxDataSet.GetItemText(listBoxDataSet.SelectedItem);
            CargarListBoxNombresRegistros();
        }
        private void CargarListBoxNombresRegistros()
        {
            nombresRegistros.Clear();
            CargarListaNombresRegistros();
            SetListaNombresRegistros();
        }

        private void CargarListaNombresRegistros()
        {
            Dominio.DataSet dataSet = productoService.GetDataSet(nombreProducto, etiquetaVersion, nombreDataSet);
            for (int i = 0; i < estadisticosService.GetCantidadRegistros(dataSet); i++)
            {
                if (!dataSetService.GetNombreRegistroAtIndex(dataSet, i).Equals("TIME"))
                {
                    nombresRegistros.Add(dataSetService.GetNombreRegistroAtIndex(dataSet, i));
                }
           }
        }

        private void SetListaNombresRegistros()
        {
            this.listBoxNombresRegistros.DataSource = nombresRegistros;
        }
        private void listBoxNombresRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {
         
          
        }
        private void btnVizualizarDataSet_Click(object sender, EventArgs e)
        {
            Dominio.DataSet dataSet = productoService.GetDataSet(nombreProducto, etiquetaVersion, nombreDataSet);
            List<List<float>> registros = new List<List<float>>();
            List<String> nombresEjeY = new List<string>();
            for (int i = 0; i < listBoxNombresRegistros.SelectedItems.Count; i++)
            {
                String nombreRegistro = listBoxNombresRegistros.GetItemText(listBoxNombresRegistros.SelectedItems[i]);
                VariablesDataSet registroVar = dataSetService.GetRegistro(dataSet, nombreRegistro);
                List<float> datos = CreateList(registroVar.GetDatosRegistro());
                registros.Add(datos);
                nombresEjeY.Add(registroVar.GetNombreVariable());
            }

            
            VariablesDataSet registroTiempo = dataSetService.GetRegistro(dataSet, REGISTRO_TIME);
            
            Grafica grafica = new Grafica(registroTiempo.GetDatosRegistro(), registros, registroTiempo.GetNombreVariable(), nombresEjeY);
            grafica.Show();
        }
        private List<float> CreateList(IEnumerable<float> lista)
        {
            List<float> ret = new List<float>();
            for(int i = 0; i < lista.Count(); i++)
            {
                ret.Add(lista.ElementAt(i));
            }
            return ret;
        }
       
        private void listBoxDataSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreDataSet = listBoxDataSet.GetItemText(listBoxDataSet.SelectedItem);
            CargarListBoxNombresRegistros();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            ListaDataSet lista = new ListaDataSet(productoService, panelPrincipal, dataSetService);
            this.panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(lista);
        }
    }
}
