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
        public Form1()
        {
            this.CenterToScreen();
            InitializeComponent();
        }

        private void textTitulo_Click(object sender, EventArgs e)
        {

        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {

            //verificar usuario y ver cual se llama
            this.Hide();
            var MenuAdministrador = new MenuAdmin();
            MenuAdministrador.Closed += (s, args) => this.Close();
            MenuAdministrador.Show();
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
