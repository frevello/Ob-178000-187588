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
            List<Producto> productos = IPService.GetListaProducto();
            for (int i = 0; i < productos.Count; i++)
            {
                listaProductos.Add(productos[i].nombre);
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
        }

        private void botonIngresarVersion_Click(object sender, EventArgs e)
        {
            try
            {
                TryIngresarVersionMetodoGeneral();     
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }  

        private void TryIngresarVersionMetodoGeneral()
        {
            TryProductoSeleccionado("Error: No se selecciono un producto");
            TryAltaVersion();
            MessageBox.Show("Usuario actualizado correctamente");
            VaciarCampos();
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
