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
using Logica;

namespace Interfaz_de_usuario
{
    public partial class EditarUsuario : UserControl
    {
        private IUsuarioService IUService;
        private BindingList<String> listaUsuarios;
        private Usuario usuario;
        public EditarUsuario(IUsuarioService IUsuarioService)
        {
            IUService = IUsuarioService;
            listaUsuarios = new BindingList<string>();
            usuario = null;
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            listaUsuarios.Clear();
            CargarListaUsuarios();
            SetListaUsuarios();
        }

        private void CargarListaUsuarios()
        {
            List<Usuario> usuarios = IUService.GetListaUsuarios();
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (!usuarios[i].nombreUsuario.Equals("Admin"))
                {
                    listaUsuarios.Add(usuarios[i].nombreUsuario);
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

        private void botonActualizarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                TryActualizarUsuarioMetodoGeneral();
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void TryActualizarUsuarioMetodoGeneral()
        {
            TryUsuarioSeleccionado("Error: No se selecciono un usuario");
            TryActualizarUsuario();
            MessageBox.Show("Usuario actualizado correctamente");
        }

        private void TryActualizarUsuario()
        {
            Usuario u = new Usuario(usuario.nombreUsuario, this.textNombre.Text, this.textContraseña.Text, this.textApellido.Text, "Desarollador");
            IUService.ModificarUsuario(u);
            VaciarCampos();
        }

        private void VaciarCampos()
        {
            this.textNombreUsuario.Text = "";
            this.textNombre.Text = "";
            this.textApellido.Text = "";
            this.textContraseña.Text = "";
            this.textFechaUltimoIngreso.Text = "";
            this.textFechaRegistro.Text = "";
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                TryEliminarUsuarioMetodoGeneral();
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void TryEliminarUsuarioMetodoGeneral()
        {
            TryUsuarioSeleccionado("Error: No se selecciono un usuario");
            TryDarBajaUsuario();
            SetDatosFinales();
        }

        private void TryUsuarioSeleccionado(String mensaje)
        {
            if (usuario == null)
            {
                throw new Exception(mensaje);
            }
        }

        private void TryDarBajaUsuario()
        {
            Usuario u = new Usuario(this.textNombreUsuario.Text, this.textNombre.Text, this.textContraseña.Text, this.textApellido.Text, "Desarollador");
            IUService.BajaUsuario(u);
            VaciarCampos();
        }

        private void SetDatosFinales()
        {
            MessageBox.Show("Usuario eliminado exitosamente");
            CargarDatos();
            usuario = null;
        } 
    }
}
