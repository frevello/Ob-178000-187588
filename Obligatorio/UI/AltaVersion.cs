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
    public partial class AltaVersion : UserControl
    {
        private IProductoService IPService;
        private BindingList<String> listaProductos;
        private Producto productoSeleccionado;
        public AltaVersion(IProductoService IProductoService)
        {
            InitializeComponent();
            IPService = IProductoService;
            listaProductos = new BindingList<String>();
            productoSeleccionado = null;
            CargarDatos();
        }

        private void CargarDatos()
        {
            CargarListaProductos();
            SetListaUsuarios();
        }

        private void CargarListaProductos()
        {
            for (int i = 0; i < IPService.GetListaProducto().Count; i++)
            {
                listaProductos.Add(IPService.GetListaProducto()[i].nombre);
            }
        }

        private void SetListaUsuarios()
        {
            this.listBoxProductos.DataSource = listaProductos;
        }

        private void botonSeleccionarProducto_Click(object sender, EventArgs e)
        {
            String producto = this.listBoxProductos.GetItemText(this.listBoxProductos.SelectedItem);
            productoSeleccionado = IPService.GetProducto(producto);
            String mensaje = "Producto seleccionado ";
            mensaje += productoSeleccionado.nombre;
            MessageBox.Show(mensaje);
        }

        private void botonIngresarVersion_Click(object sender, EventArgs e)
        {
            try
            {
                TryProductoSeleccionado("Error: No se selecciono un producto");
                TryAltaVersion();
                MessageBox.Show("Usuario actualizado correctamente");
                VaciarCampos();
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }  

        private void TryProductoSeleccionado(String mensaje)
        {
            if (productoSeleccionado == null)
            {
                throw new Exception(mensaje);
            }
        }

        private void TryAltaVersion()
        {
            IPService.AltaVersion(productoSeleccionado.nombre, this.textEtiqueta.Text, this.comboBoxTipoVersion.Text, this.dateTimeFechaCreacion.Value);
        }

        private void VaciarCampos()
        {
            productoSeleccionado = null;
            this.textEtiqueta.Text = "";
            this.dateTimeFechaCreacion.Value = DateTime.Now;
        }
    }
}
