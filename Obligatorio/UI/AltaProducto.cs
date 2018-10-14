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
using Logica;
using Dominio;

namespace Interfaz_de_usuario
{
    public partial class AltaProducto : UserControl
    {
        private IProductoService IPService;
        public AltaProducto(IProductoService IProductoService)
        {
            InitializeComponent();
            IPService = IProductoService;
        }

        private void botonIngresarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                TryIngresarProducto();
                MessageBox.Show("Producto ingresado correctamente");
                VaciarCampos();
            }
            catch (Exception m)
            {
                TryIngresarVersionPorDefecto(m.Message);
            }
        }
        private void TryIngresarVersionPorDefecto(String m)
        {
            try {
                IPService.AltaVersion(this.textNombreProducto.Text, "1.00.000", "interno", DateTime.Now);
                MessageBox.Show("Producto ingresado correctamente con version por defecto 1.00.000");
                VaciarCampos();
            }
            catch (Exception)
            {
                MessageBox.Show(m);
            }
        }
        private void VaciarCampos()
        {
            this.textBoxEtiquetaVersion.Text = "";
            this.textNombreProducto.Text = "";
            this.textNombreProducto.Text = "";
        }

        private void TryIngresarProducto()
        {
            TryProducto();
            TryVersion();       
        }

        private void TryProducto()
        {
            IPService.AltaProducto(this.textNombreProducto.Text, this.dateTimeFechaLanzamiento.Value);
        }

        private void TryVersion()
        {
            IPService.AltaVersion(this.textNombreProducto.Text, this.textBoxEtiquetaVersion.Text, this.comboBoxTipoVersion.Text, this.dateTimeFechaCreacion.Value);
        }
    }
}
