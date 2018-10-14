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
        private List<String> nombresRegistros;
        private List<String> dataSets;
        private String nombreProducto;
        private String etiquetaVersion;
        private String nombreDataSet;
        private Panel panelPrincipal;

        public VisualizarDataSet(IProductoService iProductoService, String nombreProducto, String etiquetaVersion, Panel panelPrincipal)
        {
            productoService = iProductoService;
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
            for (int i = 0; i < productoService.GetDataSet(nombreProducto, etiquetaVersion, nombreDataSet).GetNomresRegistros().Count(); i++)
            {
                if (!productoService.GetDataSet(nombreProducto, etiquetaVersion, nombreDataSet).GetNomresRegistros().ElementAt(i).Equals("TIME"))
                {
                    nombresRegistros.Add(productoService.GetDataSet(nombreProducto, etiquetaVersion, nombreDataSet).GetNomresRegistros().ElementAt(i));
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
            VariablesDataSet registroVar = productoService.GetRegistro(nombreProducto, etiquetaVersion, nombreDataSet, nombreRegistro);
            VariablesDataSet registroTiempo = productoService.GetRegistro(nombreProducto, etiquetaVersion, nombreDataSet, "TIME");
            
            Grafica grafica = new Grafica(registroTiempo.datosRegistro, registroVar.datosRegistro);
            grafica.Show();
        }

        private void listBoxDataSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreDataSet = listBoxDataSet.GetItemText(listBoxDataSet.SelectedItem);
            CargarListBoxNombresRegistros();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            ListaDataSet lista = new ListaDataSet(productoService, panelPrincipal);
            this.panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(lista);
        }
    }
}
