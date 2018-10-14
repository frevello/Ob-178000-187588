using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Interfaz_de_usuario
{
    public partial class DatosUsuario : UserControl
    {
        private Usuario usuario;
        public DatosUsuario(Usuario u)
        {
            InitializeComponent();
            this.usuario = u;
            SetDatosUsuario();
        }

        private void SetDatosUsuario()
        {
            this.textBoxNombreUsuario.Text = usuario.nombreUsuario;
            this.textBoxNombre.Text = usuario.nombre;
            this.textBoxApellido.Text = usuario.apellido;
            this.textBoxContraseña.Text = usuario.contraseña;
            string ultimoIngresoString = usuario.ultimoIngreso.ToString("MM/dd/yyyy HH:mm:ss.fff");
            this.textBoxFechaUltimoIngreso.Text = ultimoIngresoString;
            string registroString = usuario.registro.ToString("MM/dd/yyyy HH:mm:ss.fff");
            this.textBoxFechaIngreso.Text = registroString;
        }
    }
}
