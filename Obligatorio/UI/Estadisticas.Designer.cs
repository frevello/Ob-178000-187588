namespace Interfaz_de_usuario
{
    partial class Estadisticas
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectVersion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxVersiones = new System.Windows.Forms.ListBox();
            this.listBoxProducto = new System.Windows.Forms.ListBox();
            this.listBoxEstadisticas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxDataSet = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textTitulo
            // 
            this.textTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitulo.Location = new System.Drawing.Point(4, 12);
            this.textTitulo.Margin = new System.Windows.Forms.Padding(4, 12, 4, 0);
            this.textTitulo.Name = "textTitulo";
            this.textTitulo.Size = new System.Drawing.Size(593, 34);
            this.textTitulo.TabIndex = 27;
            this.textTitulo.Text = "Estadísticas";
            this.textTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 80;
            this.label4.Text = "Producto";
            // 
            // btnSelectVersion
            // 
            this.btnSelectVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectVersion.Location = new System.Drawing.Point(415, 216);
            this.btnSelectVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.btnSelectVersion.Name = "btnSelectVersion";
            this.btnSelectVersion.Size = new System.Drawing.Size(147, 31);
            this.btnSelectVersion.TabIndex = 79;
            this.btnSelectVersion.Text = "Estadistica";
            this.btnSelectVersion.UseVisualStyleBackColor = true;
            this.btnSelectVersion.Click += new System.EventHandler(this.btnSelectVersion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(207, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 77;
            this.label2.Text = "Version";
            // 
            // listBoxVersiones
            // 
            this.listBoxVersiones.FormattingEnabled = true;
            this.listBoxVersiones.HorizontalScrollbar = true;
            this.listBoxVersiones.ItemHeight = 16;
            this.listBoxVersiones.Location = new System.Drawing.Point(211, 76);
            this.listBoxVersiones.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxVersiones.Name = "listBoxVersiones";
            this.listBoxVersiones.Size = new System.Drawing.Size(166, 132);
            this.listBoxVersiones.TabIndex = 76;
            this.listBoxVersiones.SelectedIndexChanged += new System.EventHandler(this.listBoxVersiones_SelectedIndexChanged);
            // 
            // listBoxProducto
            // 
            this.listBoxProducto.FormattingEnabled = true;
            this.listBoxProducto.HorizontalScrollbar = true;
            this.listBoxProducto.ItemHeight = 16;
            this.listBoxProducto.Location = new System.Drawing.Point(27, 76);
            this.listBoxProducto.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxProducto.Name = "listBoxProducto";
            this.listBoxProducto.Size = new System.Drawing.Size(166, 132);
            this.listBoxProducto.TabIndex = 75;
            this.listBoxProducto.SelectedIndexChanged += new System.EventHandler(this.listBoxProducto_SelectedIndexChanged);
            // 
            // listBoxEstadisticas
            // 
            this.listBoxEstadisticas.FormattingEnabled = true;
            this.listBoxEstadisticas.HorizontalScrollbar = true;
            this.listBoxEstadisticas.ItemHeight = 16;
            this.listBoxEstadisticas.Location = new System.Drawing.Point(27, 251);
            this.listBoxEstadisticas.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxEstadisticas.Name = "listBoxEstadisticas";
            this.listBoxEstadisticas.Size = new System.Drawing.Size(535, 100);
            this.listBoxEstadisticas.TabIndex = 81;
            this.listBoxEstadisticas.SelectedIndexChanged += new System.EventHandler(this.listBoxEstadisticas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 227);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 82;
            this.label1.Text = "Estadisticas";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBoxDataSet
            // 
            this.listBoxDataSet.FormattingEnabled = true;
            this.listBoxDataSet.HorizontalScrollbar = true;
            this.listBoxDataSet.ItemHeight = 16;
            this.listBoxDataSet.Location = new System.Drawing.Point(396, 76);
            this.listBoxDataSet.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxDataSet.Name = "listBoxDataSet";
            this.listBoxDataSet.Size = new System.Drawing.Size(166, 132);
            this.listBoxDataSet.TabIndex = 83;
            this.listBoxDataSet.SelectedIndexChanged += new System.EventHandler(this.listBoxDataSet_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(392, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 84;
            this.label3.Text = "DataSet";
            // 
            // Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxDataSet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxEstadisticas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSelectVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxVersiones);
            this.Controls.Add(this.listBoxProducto);
            this.Controls.Add(this.textTitulo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Estadisticas";
            this.Size = new System.Drawing.Size(593, 369);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textTitulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelectVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxVersiones;
        private System.Windows.Forms.ListBox listBoxProducto;
        private System.Windows.Forms.ListBox listBoxEstadisticas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxDataSet;
        private System.Windows.Forms.Label label3;
    }
}
