namespace Interfaz_de_usuario
{
    partial class AltaVersion
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
            this.listBoxProductos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.botonSeleccionarProducto = new System.Windows.Forms.Button();
            this.comboBoxTipoVersion = new System.Windows.Forms.ComboBox();
            this.labelTipoVesión = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimeFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.textEtiqueta = new System.Windows.Forms.TextBox();
            this.labelEtiqueta = new System.Windows.Forms.Label();
            this.botonIngresarVersion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textoTitulo
            // 
            this.textoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoTitulo.Location = new System.Drawing.Point(0, 10);
            this.textoTitulo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.textoTitulo.Name = "textoTitulo";
            this.textoTitulo.Size = new System.Drawing.Size(445, 23);
            this.textoTitulo.TabIndex = 17;
            this.textoTitulo.Text = "Alta versiones para productos";
            this.textoTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // listBoxProductos
            // 
            this.listBoxProductos.FormattingEnabled = true;
            this.listBoxProductos.Location = new System.Drawing.Point(5, 73);
            this.listBoxProductos.Name = "listBoxProductos";
            this.listBoxProductos.Size = new System.Drawing.Size(437, 69);
            this.listBoxProductos.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 18);
            this.label1.TabIndex = 59;
            this.label1.Text = "Seleccionar Producto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 64;
            this.label3.Text = "Datos versión";
            // 
            // botonSeleccionarProducto
            // 
            this.botonSeleccionarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonSeleccionarProducto.Location = new System.Drawing.Point(289, 155);
            this.botonSeleccionarProducto.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.botonSeleccionarProducto.Name = "botonSeleccionarProducto";
            this.botonSeleccionarProducto.Size = new System.Drawing.Size(153, 25);
            this.botonSeleccionarProducto.TabIndex = 65;
            this.botonSeleccionarProducto.Text = "Seleccionar";
            this.botonSeleccionarProducto.UseVisualStyleBackColor = true;
            this.botonSeleccionarProducto.Click += new System.EventHandler(this.botonSeleccionarProducto_Click);
            // 
            // comboBoxTipoVersion
            // 
            this.comboBoxTipoVersion.FormattingEnabled = true;
            this.comboBoxTipoVersion.Items.AddRange(new object[] {
            "Interna",
            "No Interna"});
            this.comboBoxTipoVersion.Location = new System.Drawing.Point(115, 273);
            this.comboBoxTipoVersion.Name = "comboBoxTipoVersion";
            this.comboBoxTipoVersion.Size = new System.Drawing.Size(106, 21);
            this.comboBoxTipoVersion.TabIndex = 83;
            // 
            // labelTipoVesión
            // 
            this.labelTipoVesión.AutoSize = true;
            this.labelTipoVesión.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoVesión.Location = new System.Drawing.Point(4, 274);
            this.labelTipoVesión.Margin = new System.Windows.Forms.Padding(3, 15, 3, 10);
            this.labelTipoVesión.Name = "labelTipoVesión";
            this.labelTipoVesión.Size = new System.Drawing.Size(86, 16);
            this.labelTipoVesión.TabIndex = 82;
            this.labelTipoVesión.Text = "Tipo versión:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 233);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 81;
            this.label4.Text = "Etiqueta:";
            // 
            // dateTimeFechaCreacion
            // 
            this.dateTimeFechaCreacion.Location = new System.Drawing.Point(115, 193);
            this.dateTimeFechaCreacion.Name = "dateTimeFechaCreacion";
            this.dateTimeFechaCreacion.Size = new System.Drawing.Size(193, 20);
            this.dateTimeFechaCreacion.TabIndex = 80;
            // 
            // textEtiqueta
            // 
            this.textEtiqueta.Location = new System.Drawing.Point(115, 233);
            this.textEtiqueta.Name = "textEtiqueta";
            this.textEtiqueta.Size = new System.Drawing.Size(106, 20);
            this.textEtiqueta.TabIndex = 79;
            // 
            // labelEtiqueta
            // 
            this.labelEtiqueta.AutoSize = true;
            this.labelEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEtiqueta.Location = new System.Drawing.Point(4, 194);
            this.labelEtiqueta.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.labelEtiqueta.Name = "labelEtiqueta";
            this.labelEtiqueta.Size = new System.Drawing.Size(104, 16);
            this.labelEtiqueta.TabIndex = 78;
            this.labelEtiqueta.Text = "Fecha creación:";
            // 
            // botonIngresarVersion
            // 
            this.botonIngresarVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonIngresarVersion.Location = new System.Drawing.Point(289, 273);
            this.botonIngresarVersion.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.botonIngresarVersion.Name = "botonIngresarVersion";
            this.botonIngresarVersion.Size = new System.Drawing.Size(153, 25);
            this.botonIngresarVersion.TabIndex = 84;
            this.botonIngresarVersion.Text = "Ingresar";
            this.botonIngresarVersion.UseVisualStyleBackColor = true;
            this.botonIngresarVersion.Click += new System.EventHandler(this.botonIngresarVersion_Click);
            // 
            // AltaVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.botonIngresarVersion);
            this.Controls.Add(this.comboBoxTipoVersion);
            this.Controls.Add(this.labelTipoVesión);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimeFechaCreacion);
            this.Controls.Add(this.textEtiqueta);
            this.Controls.Add(this.labelEtiqueta);
            this.Controls.Add(this.botonSeleccionarProducto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxProductos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textoTitulo);
            this.Name = "AltaVersion";
            this.Size = new System.Drawing.Size(445, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textoTitulo;
        private System.Windows.Forms.ListBox listBoxProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button botonSeleccionarProducto;
        private System.Windows.Forms.ComboBox comboBoxTipoVersion;
        private System.Windows.Forms.Label labelTipoVesión;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimeFechaCreacion;
        private System.Windows.Forms.TextBox textEtiqueta;
        private System.Windows.Forms.Label labelEtiqueta;
        private System.Windows.Forms.Button botonIngresarVersion;
    }
}
