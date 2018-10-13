using InterfazServiceUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_de_usuario
{
    public partial class MenuAdmin : Form
    {
        private IUsuarioService IUService;
        public MenuAdmin(IUsuarioService IUsuarioService)
        {
            InitializeComponent();
            IUService = IUsuarioService;
        }

        private void botonDatosUsuario_Click(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            panelPrincipal.Controls.Clear();
            DatosUsuariosAdministrador datosUsuario = new DatosUsuariosAdministrador(IUService);
            panelPrincipal.Controls.Add(datosUsuario);
        }

        private void botonAltaUsuario_Click(object sender, EventArgs e)
        {
            CargarAltaUsuario();
        }

        private void CargarAltaUsuario()
        {
            panelPrincipal.Controls.Clear();
            AltaUsuario altaUsuario = new AltaUsuario(IUService);
            panelPrincipal.Controls.Add(altaUsuario);
        }

        private void botonEditarUsuario_Click(object sender, EventArgs e)
        {
            CargarEditarUsuario();
        }

        private void CargarEditarUsuario()
        {
            panelPrincipal.Controls.Clear();
            EditarUsuario editarUsuario = new EditarUsuario(IUService);
            panelPrincipal.Controls.Add(editarUsuario);
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonAltaProducto_Click(object sender, EventArgs e)
        {
            CargarAltaProducto();
        }

        private void CargarAltaProducto()
        {
            panelPrincipal.Controls.Clear();
            AltaProducto altaProducto = new AltaProducto();
            panelPrincipal.Controls.Add(altaProducto);
        }

        private void botonEditarProducto_Click(object sender, EventArgs e)
        {
            CargarEditarProducto();
        }

        private void CargarEditarProducto()
        {
            panelPrincipal.Controls.Clear();
            EditarProductos editarProducto = new EditarProductos();
            panelPrincipal.Controls.Add(editarProducto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarProductoVersiones();
        }

        private void CargarProductoVersiones()
        {
            panelPrincipal.Controls.Clear();
            ProductoVersiones productoVersiones = new ProductoVersiones();
            panelPrincipal.Controls.Add(productoVersiones);
        }
    }
    
}
