using Dominio;
using InterfazServiceUI;
using Logica;
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
    public partial class Form1 : Form
    {
        private IUsuarioService IUsuarioService;
        public Form1()
        {
            this.CenterToScreen();
            InitializeComponent();
            IUsuarioService = new UsuarioService();
        }

        private void textTitulo_Click(object sender, EventArgs e)
        {

        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarDatosLogIn();
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

        private void ValidarDatosLogIn()
        {
            if (IUsuarioService.LogIn(this.textBoxNombreUsuario.Text, this.textBoxContraseña.Text))
            {
                IngresarUsuarioSistema();
            }
        }

        private void IngresarUsuarioSistema()
        {
            if (this.textBoxNombreUsuario.Text.Equals("Admin"))
            {
                IngresarAdmin();
            }
            else
            {
                IngresarDesarollador();
            }

        }

        private void IngresarAdmin()
        {
            this.Hide();
            var MenuAdministrador = new MenuAdmin(IUsuarioService);
            MenuAdministrador.Closed += (s, args) => this.Close();
            MenuAdministrador.Show();
        }

        private void IngresarDesarollador()
        {
            IUsuarioService.SetUltimoIngreso(DateTime.Now, this.textBoxNombreUsuario.Text);
            this.Hide();
            var MenuDesarollador = new MenuDesarollador(IUsuarioService.GetUsuario(this.textBoxNombreUsuario.Text));
            MenuDesarollador.Closed += (s, args) => this.Close();
            MenuDesarollador.Show();
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                TryCargarDatos();
                MessageBox.Show("Datos cargados al sistema");
            }
            catch (UsuarioServiceException m)
            {
                MessageBox.Show("Ya fueron cargados los datos");
            }
            
            
        }

        private void TryCargarDatos()
        {
            IUsuarioService.AltaUsuario("Frevello", "Facundo", "1234", "Revello", "Desarollador");
            IUsuarioService.AltaUsuario("Sgarcia", "Sofia", "1234", "Garcia", "Desarollador");
        }
    }
}
