namespace Interfaz_de_usuario
{
    partial class EditarProductos
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textTitulo = new System.Windows.Forms.Label();
            this.labelDatosProducto = new System.Windows.Forms.Label();
            this.listBoxProductos = new System.Windows.Forms.ListBox();
            this.labelFechaLanzamiento = new System.Windows.Forms.Label();
            this.textNombreUsuario = new System.Windows.Forms.TextBox();
            this.labelNombreProducto = new System.Windows.Forms.Label();
            this.labelProductoSeleccionado = new System.Windows.Forms.Label();
            this.botonSeleccionarProducto = new System.Windows.Forms.Button();
            this.butonActualizarProducto = new System.Windows.Forms.Button();
            this.dateTimeFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // textTitulo
            // 
            this.textTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitulo.Location = new System.Drawing.Point(0, 10);
            this.textTitulo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.textTitulo.Name = "textTitulo";
            this.textTitulo.Size = new System.Drawing.Size(445, 23);
            this.textTitulo.TabIndex = 15;
            this.textTitulo.Text = "Editar Productos";
            this.textTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelDatosProducto
            // 
            this.labelDatosProducto.AutoSize = true;
            this.labelDatosProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatosProducto.Location = new System.Drawing.Point(3, 57);
            this.labelDatosProducto.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelDatosProducto.Name = "labelDatosProducto";
            this.labelDatosProducto.Size = new System.Drawing.Size(157, 18);
            this.labelDatosProducto.TabIndex = 58;
            this.labelDatosProducto.Text = "Seleccionar productos";
            // 
            // listBoxProductos
            // 
            this.listBoxProductos.FormattingEnabled = true;
            this.listBoxProductos.Location = new System.Drawing.Point(5, 88);
            this.listBoxProductos.Name = "listBoxProductos";
            this.listBoxProductos.Size = new System.Drawing.Size(437, 82);
            this.listBoxProductos.TabIndex = 59;
            // 
            // labelFechaLanzamiento
            // 
            this.labelFechaLanzamiento.AutoSize = true;
            this.labelFechaLanzamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaLanzamiento.Location = new System.Drawing.Point(3, 245);
            this.labelFechaLanzamiento.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.labelFechaLanzamiento.Name = "labelFechaLanzamiento";
            this.labelFechaLanzamiento.Size = new System.Drawing.Size(124, 16);
            this.labelFechaLanzamiento.TabIndex = 64;
            this.labelFechaLanzamiento.Text = "Fecha lanzamiento:";
            // 
            // textNombreUsuario
            // 
            this.textNombreUsuario.Location = new System.Drawing.Point(137, 208);
            this.textNombreUsuario.Name = "textNombreUsuario";
            this.textNombreUsuario.Size = new System.Drawing.Size(200, 20);
            this.textNombreUsuario.TabIndex = 63;
            // 
            // labelNombreProducto
            // 
            this.labelNombreProducto.AutoSize = true;
            this.labelNombreProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreProducto.Location = new System.Drawing.Point(2, 209);
            this.labelNombreProducto.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.labelNombreProducto.Name = "labelNombreProducto";
            this.labelNombreProducto.Size = new System.Drawing.Size(116, 16);
            this.labelNombreProducto.TabIndex = 62;
            this.labelNombreProducto.Text = "Nombre producto:";
            // 
            // labelProductoSeleccionado
            // 
            this.labelProductoSeleccionado.AutoSize = true;
            this.labelProductoSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductoSeleccionado.Location = new System.Drawing.Point(3, 178);
            this.labelProductoSeleccionado.Margin = new System.Windows.Forms.Padding(3, 8, 3, 10);
            this.labelProductoSeleccionado.Name = "labelProductoSeleccionado";
            this.labelProductoSeleccionado.Size = new System.Drawing.Size(161, 18);
            this.labelProductoSeleccionado.TabIndex = 61;
            this.labelProductoSeleccionado.Text = "Producto seleccionado";
            // 
            // botonSeleccionarProducto
            // 
            this.botonSeleccionarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonSeleccionarProducto.Location = new System.Drawing.Point(292, 171);
            this.botonSeleccionarProducto.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.botonSeleccionarProducto.Name = "botonSeleccionarProducto";
            this.botonSeleccionarProducto.Size = new System.Drawing.Size(153, 25);
            this.botonSeleccionarProducto.TabIndex = 60;
            this.botonSeleccionarProducto.Text = "Seleccionar";
            this.botonSeleccionarProducto.UseVisualStyleBackColor = true;
            this.botonSeleccionarProducto.Click += new System.EventHandler(this.botonSeleccionarProducto_Click);
            // 
            // butonActualizarProducto
            // 
            this.butonActualizarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonActualizarProducto.Location = new System.Drawing.Point(289, 271);
            this.butonActualizarProducto.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.butonActualizarProducto.Name = "butonActualizarProducto";
            this.butonActualizarProducto.Size = new System.Drawing.Size(153, 25);
            this.butonActualizarProducto.TabIndex = 66;
            this.butonActualizarProducto.Text = "Actualizar";
            this.butonActualizarProducto.UseVisualStyleBackColor = true;
            this.butonActualizarProducto.Click += new System.EventHandler(this.butonActualizarProducto_Click);
            // 
            // dateTimeFechaCreacion
            // 
            this.dateTimeFechaCreacion.Location = new System.Drawing.Point(137, 245);
            this.dateTimeFechaCreacion.Name = "dateTimeFechaCreacion";
            this.dateTimeFechaCreacion.Size = new System.Drawing.Size(200, 20);
            this.dateTimeFechaCreacion.TabIndex = 67;
            // 
            // EditarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimeFechaCreacion);
            this.Controls.Add(this.butonActualizarProducto);
            this.Controls.Add(this.labelFechaLanzamiento);
            this.Controls.Add(this.textNombreUsuario);
            this.Controls.Add(this.labelNombreProducto);
            this.Controls.Add(this.labelProductoSeleccionado);
            this.Controls.Add(this.botonSeleccionarProducto);
            this.Controls.Add(this.listBoxProductos);
            this.Controls.Add(this.labelDatosProducto);
            this.Controls.Add(this.textTitulo);
            this.Name = "EditarProductos";
            this.Size = new System.Drawing.Size(445, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textTitulo;
        private System.Windows.Forms.Label labelDatosProducto;
        private System.Windows.Forms.ListBox listBoxProductos;
        private System.Windows.Forms.Label labelFechaLanzamiento;
        private System.Windows.Forms.TextBox textNombreUsuario;
        private System.Windows.Forms.Label labelNombreProducto;
        private System.Windows.Forms.Label labelProductoSeleccionado;
        private System.Windows.Forms.Button botonSeleccionarProducto;
        private System.Windows.Forms.Button butonActualizarProducto;
        private System.Windows.Forms.DateTimePicker dateTimeFechaCreacion;
    }
}
