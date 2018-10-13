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
            this.btnSelectProducto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxProducto = new System.Windows.Forms.ListBox();
            this.listBoxVersiones = new System.Windows.Forms.ListBox();
            this.listBoxDataSet = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectVersion = new System.Windows.Forms.Button();
            this.btnVizualizarDataSet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
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
            this.textTitulo.Text = "Lista DataSet";
            this.textTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSelectProducto
            // 
            this.btnSelectProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectProducto.Location = new System.Drawing.Point(34, 326);
            this.btnSelectProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.btnSelectProducto.Name = "btnSelectProducto";
            this.btnSelectProducto.Size = new System.Drawing.Size(119, 31);
            this.btnSelectProducto.TabIndex = 68;
            this.btnSelectProducto.Text = "Seleccionar";
            this.btnSelectProducto.UseVisualStyleBackColor = true;
            this.btnSelectProducto.Click += new System.EventHandler(this.btnSelectProducto_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(194, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 67;
            this.label2.Text = "Version";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "Seleccionar:";
            // 
            // listBoxProducto
            // 
            this.listBoxProducto.FormattingEnabled = true;
            this.listBoxProducto.ItemHeight = 16;
            this.listBoxProducto.Location = new System.Drawing.Point(20, 107);
            this.listBoxProducto.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxProducto.Name = "listBoxProducto";
            this.listBoxProducto.Size = new System.Drawing.Size(147, 196);
            this.listBoxProducto.TabIndex = 64;
            // 
            // listBoxVersiones
            // 
            this.listBoxVersiones.FormattingEnabled = true;
            this.listBoxVersiones.ItemHeight = 16;
            this.listBoxVersiones.Location = new System.Drawing.Point(198, 107);
            this.listBoxVersiones.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxVersiones.Name = "listBoxVersiones";
            this.listBoxVersiones.Size = new System.Drawing.Size(147, 196);
            this.listBoxVersiones.TabIndex = 66;
            // 
            // listBoxDataSet
            // 
            this.listBoxDataSet.FormattingEnabled = true;
            this.listBoxDataSet.ItemHeight = 16;
            this.listBoxDataSet.Location = new System.Drawing.Point(378, 107);
            this.listBoxDataSet.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxDataSet.Name = "listBoxDataSet";
            this.listBoxDataSet.Size = new System.Drawing.Size(147, 196);
            this.listBoxDataSet.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(374, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 70;
            this.label3.Text = "DataSet";
            // 
            // btnSelectVersion
            // 
            this.btnSelectVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectVersion.Location = new System.Drawing.Point(214, 326);
            this.btnSelectVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.btnSelectVersion.Name = "btnSelectVersion";
            this.btnSelectVersion.Size = new System.Drawing.Size(119, 31);
            this.btnSelectVersion.TabIndex = 71;
            this.btnSelectVersion.Text = "Seleccionar";
            this.btnSelectVersion.UseVisualStyleBackColor = true;
            // 
            // btnVizualizarDataSet
            // 
            this.btnVizualizarDataSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVizualizarDataSet.Location = new System.Drawing.Point(395, 326);
            this.btnVizualizarDataSet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.btnVizualizarDataSet.Name = "btnVizualizarDataSet";
            this.btnVizualizarDataSet.Size = new System.Drawing.Size(119, 31);
            this.btnVizualizarDataSet.TabIndex = 72;
            this.btnVizualizarDataSet.Text = "Seleccionar";
            this.btnVizualizarDataSet.UseVisualStyleBackColor = true;
            this.btnVizualizarDataSet.Click += new System.EventHandler(this.btnDataSet_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 74;
            this.label4.Text = "Producto";
            // 
            // ListaDataSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnVizualizarDataSet);
            this.Controls.Add(this.btnSelectVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxDataSet);
            this.Controls.Add(this.btnSelectProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxVersiones);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button btnSelectProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxProducto;
        private System.Windows.Forms.ListBox listBoxVersiones;
        private System.Windows.Forms.ListBox listBoxDataSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectVersion;
        private System.Windows.Forms.Button btnVizualizarDataSet;
        private System.Windows.Forms.Label label4;
    }
}
