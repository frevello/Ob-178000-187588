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
    public partial class VisualizarDataSet : UserControl
    {
        private IProductoService productoService;
        private IDataSetService dataSetService;
        private List<String> nombresRegistros;
        private List<String> dataSets;
        private String nombreProducto;
        private String etiquetaVersion;
        private String nombreDataSet;
        private Panel panelPrincipal;

        private const String REGISTRO_TIME = "TIME"; 

        public VisualizarDataSet(IProductoService iProductoService, String nombreProducto, String etiquetaVersion, Panel panelPrincipal, IDataSetService iDataSetService)
        {
            productoService = iProductoService;
            dataSetService = iDataSetService;
            this.panelPrincipal = panelPrincipal;
            this.nombreProducto = nombreProducto;
            this.etiquetaVersion = etiquetaVersion;
            this.dataSets = new List<string>();
            nombresRegistros = new List<string>();
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
            for (int i = 0; i < productoService.GetVersionProducto(nombreProducto, etiquetaVersion).dataset.Count; i++)
            {
                dataSets.Add(productoService.GetVersionProducto(nombreProducto, etiquetaVersion).dataset[i].GetNombre());
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
            for (int i = 0; i < dataSetService.GetCantidadRegistros(dataSet); i++)
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
            String nombreRegistro = listBoxNombresRegistros.GetItemText(listBoxNombresRegistros.SelectedItem);
            Dominio.DataSet dataSet = productoService.GetDataSet(nombreProducto, etiquetaVersion, nombreDataSet);
            VariablesDataSet registroVar = dataSetService.GetRegistro(dataSet, nombreRegistro);
            VariablesDataSet registroTiempo = dataSetService.GetRegistro(dataSet, REGISTRO_TIME);
            
            Grafica grafica = new Grafica(registroTiempo.datosRegistro, registroVar.datosRegistro, registroTiempo.nombreVariable, registroVar.nombreVariable);
            grafica.Show();
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
