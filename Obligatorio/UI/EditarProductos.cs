﻿using System;
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
    public partial class EditarProductos : UserControl
    {
        private IProductoService IPService;
        private BindingList<String> listaProductos;
        private Producto productoSeleccionado;
        public EditarProductos(IProductoService IProductoService)
        {
            InitializeComponent();
            IPService = IProductoService;
            listaProductos = new BindingList<string>();
            productoSeleccionado = null;
            CargarDatos();
        }

        private void CargarDatos()
        {
            listaProductos.Clear();
            CargarListaUsuarios();
            SetListaUsuarios();
        }

        private void CargarListaUsuarios()
        {
            for (int i = 0; i < IPService.GetListaProducto().Count; i++)
            {
                listaProductos.Add(IPService.GetListaProducto()[i].nombre);
            }
        }

        private void SetListaUsuarios()
        {
            this.listBoxProductos.DataSource = listaProductos;
        }

        private void botonSeleccionarProducto_Click(object sender, EventArgs e)
        {
            String producto = this.listBoxProductos.GetItemText(this.listBoxProductos.SelectedItem);
            productoSeleccionado = IPService.GetProducto(producto);
            CargarDatosProductos();
        }

        private void CargarDatosProductos()
        {
            this.textNombreUsuario.Text = productoSeleccionado.nombre;
            this.dateTimeFechaCreacion.Value = productoSeleccionado.fechaInicial;
        }

        private void butonActualizarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                TryProductoSeleccionado("Error: No se selecciono un producto");
                TryModificarProducto();
                SetDatosFinales();
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void TryProductoSeleccionado(String mensaje)
        {
            if (productoSeleccionado == null)
            {
                throw new Exception(mensaje);
            }
        }

        private void TryModificarProducto()
        {
            IPService.ModificarProducto(productoSeleccionado.nombre, this.textNombreUsuario.Text, this.dateTimeFechaCreacion.Value);
            //modificar fecha version igual a la del producto
        }

        private void SetDatosFinales()
        {
            MessageBox.Show("Producto actualizado correctamente");
            productoSeleccionado = null;
            CargarDatos();
            VaciarCampos();
        }

        private void VaciarCampos()
        {
            this.textNombreUsuario.Text = "";
        }
    }
}
