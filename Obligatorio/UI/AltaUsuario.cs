using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Dominio;
using InterfazServiceUI;

namespace Interfaz_de_usuario
{
    public partial class AltaUsuario : UserControl
    {
        private IUsuarioService IUService;
        public AltaUsuario(IUsuarioService IUsuarioService)
        {
            InitializeComponent();
            IUService = IUsuarioService;
        }

        private void botonIngresarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                IngresarUsuario();
                MessageBox.Show("Usuario ingresado correctamente");
                VaciarCampos();
            }
            catch (UsuarioServiceException m)
            {
                MessageBox.Show(m.Message);
            }
            catch (LargoDatoNoValidoException m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void IngresarUsuario()
        {
            IUService.AltaUsuario(this.textBoxNombreUsuario.Text, this.textBoxNombre.Text, this.textBoxContraseña.Text, this.textBoxApellido.Text, "Desarollador");
        }

        private void VaciarCampos()
        {
            this.textBoxNombreUsuario.Text = "";
            this.textBoxNombre.Text = "";
            this.textBoxApellido.Text = "";
            this.textBoxContraseña.Text = "";
            string ultimoIngresoString = "";
        }
    }
}
