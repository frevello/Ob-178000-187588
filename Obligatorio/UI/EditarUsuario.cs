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
            for (int i = 0; i < IUService.GetListaUsuarios().Count; i++)
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

        private void botonActualizarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                TryUsuarioSeleccionado("Error: No se selecciono un usuario");
                TryActualizarUsuario();
                MessageBox.Show("Usuario actualizado correctamente");
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
            string ultimoIngresoString = "";
            this.textFechaUltimoIngreso.Text = ultimoIngresoString;
            string registroString = "";
            this.textFechaRegistro.Text = registroString;
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                TryUsuarioSeleccionado("Error: No se selecciono un usuario");
                TryEliminarUsuario();
                SetDatosFinales();    
            }
            catch (UsuarioServiceException m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void SetDatosFinales()
        {

            MessageBox.Show("Usuario eliminado exitosamente");
            CargarDatos();
            usuario = null;
        }

        private void TryUsuarioSeleccionado(String mensaje)
        {
            if (usuario == null)
            {
                throw new UsuarioServiceException(mensaje);
            }
        }

        private void TryEliminarUsuario()
        {
            Usuario u = new Usuario(this.textNombreUsuario.Text, this.textNombre.Text, this.textContraseña.Text, this.textApellido.Text, "Desarollador");
            IUService.BajaUsuario(u);
            VaciarCampos();
        }
    }
}
