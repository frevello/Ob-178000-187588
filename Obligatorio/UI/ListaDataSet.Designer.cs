namespace Interfaz_de_usuario
{
    partial class ListaDataSet
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
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxProducto = new System.Windows.Forms.ListBox();
            this.listBoxVersiones = new System.Windows.Forms.ListBox();
            this.btnSelectVersion = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textTitulo
            // 
            this.textTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitulo.Location = new System.Drawing.Point(4, 16);
            this.textTitulo.Margin = new System.Windows.Forms.Padding(4, 12, 4, 0);
            this.textTitulo.Name = "textTitulo";
            this.textTitulo.Size = new System.Drawing.Size(593, 34);
            this.textTitulo.TabIndex = 28;
            this.textTitulo.Text = "Visualizacion DataSet";
            this.textTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.textTitulo.Click += new System.EventHandler(this.textTitulo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 187);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 67;
            this.label2.Text = "Seleccionar Version";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // listBoxProducto
            // 
            this.listBoxProducto.FormattingEnabled = true;
            this.listBoxProducto.ItemHeight = 16;
            this.listBoxProducto.Location = new System.Drawing.Point(4, 78);
            this.listBoxProducto.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxProducto.Name = "listBoxProducto";
            this.listBoxProducto.Size = new System.Drawing.Size(581, 84);
            this.listBoxProducto.TabIndex = 64;
            this.listBoxProducto.SelectedIndexChanged += new System.EventHandler(this.listBoxProducto_SelectedIndexChanged);
            // 
            // listBoxVersiones
            // 
            this.listBoxVersiones.FormattingEnabled = true;
            this.listBoxVersiones.ItemHeight = 16;
            this.listBoxVersiones.Location = new System.Drawing.Point(4, 211);
            this.listBoxVersiones.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxVersiones.Name = "listBoxVersiones";
            this.listBoxVersiones.Size = new System.Drawing.Size(581, 84);
            this.listBoxVersiones.TabIndex = 66;
            // 
            // btnSelectVersion
            // 
            this.btnSelectVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectVersion.Location = new System.Drawing.Point(381, 316);
            this.btnSelectVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.btnSelectVersion.Name = "btnSelectVersion";
            this.btnSelectVersion.Size = new System.Drawing.Size(204, 31);
            this.btnSelectVersion.TabIndex = 71;
            this.btnSelectVersion.Text = "Continuar";
            this.btnSelectVersion.UseVisualStyleBackColor = true;
            this.btnSelectVersion.Click += new System.EventHandler(this.btnSelectVersion_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 20);
            this.label4.TabIndex = 74;
            this.label4.Text = "Seleccionar Producto";
            // 
            // ListaDataSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSelectVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxVersiones);
            this.Controls.Add(this.listBoxProducto);
            this.Controls.Add(this.textTitulo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListaDataSet";
            this.Size = new System.Drawing.Size(593, 369);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxProducto;
        private System.Windows.Forms.ListBox listBoxVersiones;
        private System.Windows.Forms.Button btnSelectVersion;
        private System.Windows.Forms.Label label4;
    }
}
