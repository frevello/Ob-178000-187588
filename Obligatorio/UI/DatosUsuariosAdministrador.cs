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
    public partial class DatosUsuariosAdministrador : UserControl
    {
        private IUsuarioService IUService;
        private List<String> listaUsuarios;
        private Usuario usuario;
        public DatosUsuariosAdministrador(IUsuarioService IUsuarioService)
        {
            InitializeComponent();
            IUService = IUsuarioService;
            listaUsuarios = new List<string>();
            usuario = null;
            CargarListaUsuarios();
            SetListaUsuarios();
        }

        private void CargarListaUsuarios()
        {
            for(int i = 0; i<IUService.GetListaUsuarios().Count; i++)
            {
                if (!IUService.GetListaUsuarios()[i].nombreUsuario.Equals("Admin"))
                {
                    listaUsuarios.Add(IUService.GetListaUsuarios()[i].nombreUsuario);
                }              
            }         
        }

        private void SetListaUsuarios()
        {
            this.listBoxDesarolladores.DataSource = listaUsuarios;
        }

        private void botonIngresarUsuario_Click(object sender, EventArgs e)
        {
            String usuarioSeleccionado = listBoxDesarolladores.GetItemText(listBoxDesarolladores.SelectedItem);
            usuario = IUService.GetUsuario(usuarioSeleccionado);
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            this.textNombreUsuario.Text = usuario.nombreUsuario;
            this.textNombre.Text = usuario.nombre;
            this.textApellido.Text = usuario.apellido;
            this.textContraseña.Text = usuario.contraseña;
            string ultimoIngresoString = usuario.ultimoIngreso.ToString("MM/dd/yyyy HH:mm:ss.fff");
            this.textFechaUltimoIngreso.Text = ultimoIngresoString;
            string registroString = usuario.registro.ToString("MM/dd/yyyy HH:mm:ss.fff");
            this.textFechaRegistro.Text = registroString;
        }
    }
}
