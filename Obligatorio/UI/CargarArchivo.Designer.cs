namespace Interfaz_de_usuario
{
    partial class CargarArchivo
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxProducto = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxVersiones = new System.Windows.Forms.ListBox();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.btnSelectProducto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textTitulo
            // 
            this.textTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitulo.Location = new System.Drawing.Point(0, 12);
            this.textTitulo.Margin = new System.Windows.Forms.Padding(4, 12, 4, 0);
            this.textTitulo.Name = "textTitulo";
            this.textTitulo.Size = new System.Drawing.Size(593, 34);
            this.textTitulo.TabIndex = 28;
            this.textTitulo.Text = "Cargar Archivo";
            this.textTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 59;
            this.label1.Text = "Seleccionar Producto";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBoxProducto
            // 
            this.listBoxProducto.FormattingEnabled = true;
            this.listBoxProducto.ItemHeight = 16;
            this.listBoxProducto.Location = new System.Drawing.Point(4, 75);
            this.listBoxProducto.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxProducto.Name = "listBoxProducto";
            this.listBoxProducto.Size = new System.Drawing.Size(581, 84);
            this.listBoxProducto.TabIndex = 58;
            this.listBoxProducto.SelectedIndexChanged += new System.EventHandler(this.listBoxDesarolladores_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 61;
            this.label2.Text = "Seleccionar Version";
            // 
            // listBoxVersiones
            // 
            this.listBoxVersiones.FormattingEnabled = true;
            this.listBoxVersiones.ItemHeight = 16;
            this.listBoxVersiones.Location = new System.Drawing.Point(4, 210);
            this.listBoxVersiones.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxVersiones.Name = "listBoxVersiones";
            this.listBoxVersiones.Size = new System.Drawing.Size(581, 84);
            this.listBoxVersiones.TabIndex = 60;
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarArchivo.Location = new System.Drawing.Point(381, 316);
            this.btnCargarArchivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(204, 31);
            this.btnCargarArchivo.TabIndex = 62;
            this.btnCargarArchivo.Text = "Cargar Archivo";
            this.btnCargarArchivo.UseVisualStyleBackColor = true;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
            // 
            // btnSelectProducto
            // 
            this.btnSelectProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectProducto.Location = new System.Drawing.Point(381, 163);
            this.btnSelectProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.btnSelectProducto.Name = "btnSelectProducto";
            this.btnSelectProducto.Size = new System.Drawing.Size(204, 31);
            this.btnSelectProducto.TabIndex = 63;
            this.btnSelectProducto.Text = "Seleccionar Producto";
            this.btnSelectProducto.UseVisualStyleBackColor = true;
            this.btnSelectProducto.Click += new System.EventHandler(this.btnSelectProducto_Click);
            // 
            // CargarArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelectProducto);
            this.Controls.Add(this.btnCargarArchivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxVersiones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxProducto);
            this.Controls.Add(this.textTitulo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CargarArchivo";
            this.Size = new System.Drawing.Size(593, 369);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxVersiones;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.Button btnSelectProducto;
    }
}
