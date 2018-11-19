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
    public partial class EditarVersiones : UserControl
    {
        private IProductoService IPService;
        private Producto productoSeleccionado;
        private Dominio.Version versionSeleccionada;
        private BindingList<String> listaProductos;
        private BindingList<String> listaVersiones;
        public EditarVersiones(IProductoService IProductoService)
        {
            InitializeComponent();
            IPService = IProductoService;
            productoSeleccionado = null;
            versionSeleccionada = null;
            listaProductos = new BindingList<String>();
            listaVersiones = new BindingList<String>();
            CargarDatos();
        }
        private void CargarDatos()
        {
            CargarListaProductos();
            SetListaProductos();
        }

        private void CargarListaProductos()
        {
            for (int i = 0; i < IPService.GetListaProducto().Count; i++)
            {
                listaProductos.Add(IPService.GetListaProducto()[i].GetNombre());
            }
        }

        private void SetListaProductos()
        {
            this.listBoxProductos.DataSource = listaProductos;
        }

        private void botonSeleccionarVersión_Click(object sender, EventArgs e)
        {
            try
            {
                TrySeleccionarVersionMetodoGeneral();
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void TrySeleccionarVersionMetodoGeneral()
        {
            TryProductoSeleccionado("Error: No se selecciono un producto");
            SetDatosVersiones();
        }

        private void TryProductoSeleccionado(String mensaje)
        {
            if (productoSeleccionado == null)
            {
                throw new Exception(mensaje);
            }
        }

        private void SetDatosVersiones()
        {
            String version = this.listBoxVersiones.GetItemText(this.listBoxVersiones.SelectedItem);
            versionSeleccionada = IPService.GetVersionProducto(productoSeleccionado.GetNombre(), version);
            SetDatos();
        }

        private void SetDatos()
        {
            this.textEtiqueta.Text = versionSeleccionada.etiqueta;
            this.dateTimeFechaCreacion.Value = versionSeleccionada.fechaCreacion;
            this.comboBoxTipoVersion.Text = versionSeleccionada.estado;
        }

        private void botonSeleccionarProducto_Click(object sender, EventArgs e)
        {
            String producto = this.listBoxProductos.GetItemText(this.listBoxProductos.SelectedItem);
            productoSeleccionado = IPService.GetProducto(producto);
            CargarDatosVersiones();
        }

        private void CargarDatosVersiones()
        {
            listaVersiones.Clear();
            CargarListaVersiones();
            SetListaVersiones();
        }

        private void CargarListaVersiones()
        {
            Producto p = IPService.GetProducto(productoSeleccionado.GetNombre());
            for (int i = 0; i < p.GetVersiones().Count(); i++)
            {
                listaVersiones.Add(p.GetVersiones().ElementAt(i).etiqueta);
            }
        }

        private void SetListaVersiones()
        {
            this.listBoxVersiones.DataSource = listaVersiones;
        }
        
       

        

        private void botonIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                TryModificarVersion();
                MessageBox.Show("Version actualizado correctamente");
                SetVariablesVacias();
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }   
        }

        private void SetVariablesVacias()
        {
            productoSeleccionado = null;
            versionSeleccionada = null;
            this.textEtiqueta.Text = "";
        }

        private void TryModificarVersion()
        {
            IPService.ModificarVersion(productoSeleccionado.GetNombre(), versionSeleccionada.etiqueta, this.textEtiqueta.Text, this.comboBoxTipoVersion.Text, this.dateTimeFechaCreacion.Value);
        }
    }
}
