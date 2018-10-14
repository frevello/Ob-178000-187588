namespace Interfaz_de_usuario
{
    partial class EditarVersiones
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
            this.textoTitulo = new System.Windows.Forms.Label();
            this.botonSeleccionarProducto = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxProductos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxVersiones = new System.Windows.Forms.ListBox();
            this.comboBoxTipoVersion = new System.Windows.Forms.ComboBox();
            this.labelTipoVesión = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimeFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.textEtiqueta = new System.Windows.Forms.TextBox();
            this.labelEtiqueta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.botonSeleccionarVersión = new System.Windows.Forms.Button();
            this.botonActualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textoTitulo
            // 
            this.textoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoTitulo.Location = new System.Drawing.Point(0, 10);
            this.textoTitulo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.textoTitulo.Name = "textoTitulo";
            this.textoTitulo.Size = new System.Drawing.Size(445, 23);
            this.textoTitulo.TabIndex = 18;
            this.textoTitulo.Text = "Editar Versiones";
            this.textoTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // botonSeleccionarProducto
            // 
            this.botonSeleccionarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonSeleccionarProducto.Location = new System.Drawing.Point(289, 103);
            this.botonSeleccionarProducto.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.botonSeleccionarProducto.Name = "botonSeleccionarProducto";
            this.botonSeleccionarProducto.Size = new System.Drawing.Size(153, 25);
            this.botonSeleccionarProducto.TabIndex = 69;
            this.botonSeleccionarProducto.Text = "Seleccionar";
            this.botonSeleccionarProducto.UseVisualStyleBackColor = true;
            this.botonSeleccionarProducto.Click += new System.EventHandler(this.botonSeleccionarProducto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 18);
            this.label3.TabIndex = 68;
            this.label3.Text = "Seleccionar Versión";
            // 
            // listBoxProductos
            // 
            this.listBoxProductos.FormattingEnabled = true;
            this.listBoxProductos.Location = new System.Drawing.Point(5, 54);
            this.listBoxProductos.Name = "listBoxProductos";
            this.listBoxProductos.Size = new System.Drawing.Size(437, 43);
            this.listBoxProductos.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 18);
            this.label1.TabIndex = 66;
            this.label1.Text = "Seleccionar Producto";
            // 
            // listBoxVersiones
            // 
            this.listBoxVersiones.FormattingEnabled = true;
            this.listBoxVersiones.Location = new System.Drawing.Point(6, 130);
            this.listBoxVersiones.Name = "listBoxVersiones";
            this.listBoxVersiones.Size = new System.Drawing.Size(437, 56);
            this.listBoxVersiones.TabIndex = 70;
            // 
            // comboBoxTipoVersion
            // 
            this.comboBoxTipoVersion.FormattingEnabled = true;
            this.comboBoxTipoVersion.Items.AddRange(new object[] {
            "Interna",
            "No Interna"});
            this.comboBoxTipoVersion.Location = new System.Drawing.Point(106, 275);
            this.comboBoxTipoVersion.Name = "comboBoxTipoVersion";
            this.comboBoxTipoVersion.Size = new System.Drawing.Size(106, 21);
            this.comboBoxTipoVersion.TabIndex = 89;
            // 
            // labelTipoVesión
            // 
            this.labelTipoVesión.AutoSize = true;
            this.labelTipoVesión.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoVesión.Location = new System.Drawing.Point(3, 279);
            this.labelTipoVesión.Margin = new System.Windows.Forms.Padding(3, 15, 3, 10);
            this.labelTipoVesión.Name = "labelTipoVesión";
            this.labelTipoVesión.Size = new System.Drawing.Size(88, 16);
            this.labelTipoVesión.TabIndex = 88;
            this.labelTipoVesión.Text = "Tipo Version:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 249);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 87;
            this.label4.Text = "Etiqueta:";
            // 
            // dateTimeFechaCreacion
            // 
            this.dateTimeFechaCreacion.Location = new System.Drawing.Point(106, 223);
            this.dateTimeFechaCreacion.Name = "dateTimeFechaCreacion";
            this.dateTimeFechaCreacion.Size = new System.Drawing.Size(193, 20);
            this.dateTimeFechaCreacion.TabIndex = 86;
            // 
            // textEtiqueta
            // 
            this.textEtiqueta.Location = new System.Drawing.Point(106, 249);
            this.textEtiqueta.Name = "textEtiqueta";
            this.textEtiqueta.Size = new System.Drawing.Size(106, 20);
            this.textEtiqueta.TabIndex = 85;
            // 
            // labelEtiqueta
            // 
            this.labelEtiqueta.AutoSize = true;
            this.labelEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEtiqueta.Location = new System.Drawing.Point(2, 223);
            this.labelEtiqueta.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.labelEtiqueta.Name = "labelEtiqueta";
            this.labelEtiqueta.Size = new System.Drawing.Size(106, 16);
            this.labelEtiqueta.TabIndex = 84;
            this.labelEtiqueta.Text = "Fecha Creación:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 195);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 90;
            this.label2.Text = "Datos versión";
            // 
            // botonSeleccionarVersión
            // 
            this.botonSeleccionarVersión.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonSeleccionarVersión.Location = new System.Drawing.Point(289, 192);
            this.botonSeleccionarVersión.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.botonSeleccionarVersión.Name = "botonSeleccionarVersión";
            this.botonSeleccionarVersión.Size = new System.Drawing.Size(153, 25);
            this.botonSeleccionarVersión.TabIndex = 91;
            this.botonSeleccionarVersión.Text = "Seleccionar";
            this.botonSeleccionarVersión.UseVisualStyleBackColor = true;
            this.botonSeleccionarVersión.Click += new System.EventHandler(this.botonSeleccionarVersión_Click);
            // 
            // botonActualizar
            // 
            this.botonActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonActualizar.Location = new System.Drawing.Point(289, 270);
            this.botonActualizar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.botonActualizar.Name = "botonActualizar";
            this.botonActualizar.Size = new System.Drawing.Size(153, 25);
            this.botonActualizar.TabIndex = 92;
            this.botonActualizar.Text = "Actualizar";
            this.botonActualizar.UseVisualStyleBackColor = true;
            this.botonActualizar.Click += new System.EventHandler(this.botonIngresar_Click);
            // 
            // EditarVersiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.botonActualizar);
            this.Controls.Add(this.botonSeleccionarVersión);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTipoVersion);
            this.Controls.Add(this.labelTipoVesión);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimeFechaCreacion);
            this.Controls.Add(this.textEtiqueta);
            this.Controls.Add(this.labelEtiqueta);
            this.Controls.Add(this.listBoxVersiones);
            this.Controls.Add(this.botonSeleccionarProducto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxProductos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textoTitulo);
            this.Name = "EditarVersiones";
            this.Size = new System.Drawing.Size(445, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textoTitulo;
        private System.Windows.Forms.Button botonSeleccionarProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxVersiones;
        private System.Windows.Forms.ComboBox comboBoxTipoVersion;
        private System.Windows.Forms.Label labelTipoVesión;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimeFechaCreacion;
        private System.Windows.Forms.TextBox textEtiqueta;
        private System.Windows.Forms.Label labelEtiqueta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button botonSeleccionarVersión;
        private System.Windows.Forms.Button botonActualizar;
    }
}
