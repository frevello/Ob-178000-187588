using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfazServiceUI;
using Logica;
using Dominio;
using System.Diagnostics;

namespace Interfaz_de_usuario
{
   

    public partial class CargarArchivo : UserControl
    {
        private IDataSetService dataSetService;
        private IProductoService productoService;
        private List<String> productos;
        private BindingList<String> versiones;
        private String nombreProducto;
        private String etiquetaVersion;

        public CargarArchivo(IProductoService iProductoService, IDataSetService iDataSetService)
        {
            dataSetService = iDataSetService;
            productoService = iProductoService;
            productos = new List<string>();
            nombreProducto = null;
            versiones = new BindingList<string>();
            etiquetaVersion = null;
            InitializeComponent();
            CargarLitBoxProductos();
        }


        private void CargarLitBoxProductos()
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
        private void CargarLitBoxVersiones(String nombreProducto)
        {
            versiones.Clear();
            CargarListaVersiones(nombreProducto);
            SetListaVersiones();
        }
        private void CargarListaVersiones(String nombreProducto)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBoxDesarolladores_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreProducto = listBoxProducto.GetItemText(listBoxProducto.SelectedItem);
            CargarLitBoxVersiones(nombreProducto);
        }

        private void btnSelectProducto_Click(object sender, EventArgs e)
        {
            nombreProducto = listBoxProducto.GetItemText(listBoxProducto.SelectedItem);
            CargarLitBoxVersiones(nombreProducto);
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            
            etiquetaVersion = listBoxVersiones.GetItemText(listBoxVersiones.SelectedItem);
            if(nombreProducto != null && etiquetaVersion != null && !nombreProducto.Equals("") && !etiquetaVersion.Equals(""))
            {
                String path = GetPathDataSet();
                TryCargarYAddDataSet(path);
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un producto y una version");
            }
        }

        private String GetPathDataSet()
        {
            String path ="";
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = "./";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                }
            }
            return path;
        }
        private void TryCargarYAddDataSet(String path)
        {
            try
            {
                Dominio.DataSet dataset = dataSetService.CargarDataSet(path);
                productoService.AddDataSet(nombreProducto, etiquetaVersion, dataset);
                MessageBox.Show("Se cargo correctamente");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        
        }
    }
}
