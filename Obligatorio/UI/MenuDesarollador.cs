using Dominio;
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
    public partial class MenuDesarollador : Form
    {
        private Usuario usuario;
        public MenuDesarollador(Usuario u)
        {
            InitializeComponent();
            this.usuario = u;
        }

        private void botonDatosUsuario_Click(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            panelPrincipal.Controls.Clear();
            DatosUsuario datosUsuario = new DatosUsuario(usuario);
            panelPrincipal.Controls.Add(datosUsuario);
        }

        private void botonCargarArchivo_Click(object sender, EventArgs e)
        {
            CargarArchivo();
        }

        private void CargarArchivo()
        {
            panelPrincipal.Controls.Clear();
            CargarArchivo cargarArchivo = new CargarArchivo();
            panelPrincipal.Controls.Add(cargarArchivo);
        }

        private void botonListaDataSets_Click(object sender, EventArgs e)
        {
            CargarListaDataSet();
        }

        private void CargarListaDataSet()
        {
            panelPrincipal.Controls.Clear();
            ListaDataSet listaDataSet = new ListaDataSet();
            panelPrincipal.Controls.Add(listaDataSet);
        }

        private void botonEstadisticas_Click(object sender, EventArgs e)
        {
            CargarEstadisticas();
        }

        private void CargarEstadisticas()
        {
            panelPrincipal.Controls.Clear();
            Estadisticas estadisticas = new Estadisticas();
            panelPrincipal.Controls.Add(estadisticas);
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }   
}
