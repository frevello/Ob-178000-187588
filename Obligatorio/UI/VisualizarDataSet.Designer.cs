namespace Interfaz_de_usuario
{
    partial class VisualizarDataSet
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
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxNombresRegistros = new System.Windows.Forms.ListBox();
            this.textTitulo = new System.Windows.Forms.Label();
            this.btnVizualizarDataSet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.listBoxDataSet = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 179);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 20);
            this.label4.TabIndex = 78;
            this.label4.Text = "Seleccionar Variable";
            // 
            // listBoxNombresRegistros
            // 
            this.listBoxNombresRegistros.FormattingEnabled = true;
            this.listBoxNombresRegistros.ItemHeight = 16;
            this.listBoxNombresRegistros.Location = new System.Drawing.Point(6, 203);
            this.listBoxNombresRegistros.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxNombresRegistros.Name = "listBoxNombresRegistros";
            this.listBoxNombresRegistros.Size = new System.Drawing.Size(578, 84);
            this.listBoxNombresRegistros.TabIndex = 76;
            this.listBoxNombresRegistros.SelectedIndexChanged += new System.EventHandler(this.listBoxNombresRegistros_SelectedIndexChanged);
            // 
            // textTitulo
            // 
            this.textTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitulo.Location = new System.Drawing.Point(0, 12);
            this.textTitulo.Margin = new System.Windows.Forms.Padding(4, 12, 4, 0);
            this.textTitulo.Name = "textTitulo";
            this.textTitulo.Size = new System.Drawing.Size(593, 34);
            this.textTitulo.TabIndex = 75;
            this.textTitulo.Text = "Visualizacion DataSet";
            this.textTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnVizualizarDataSet
            // 
            this.btnVizualizarDataSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVizualizarDataSet.Location = new System.Drawing.Point(380, 316);
            this.btnVizualizarDataSet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.btnVizualizarDataSet.Name = "btnVizualizarDataSet";
            this.btnVizualizarDataSet.Size = new System.Drawing.Size(204, 31);
            this.btnVizualizarDataSet.TabIndex = 81;
            this.btnVizualizarDataSet.Text = "Graficar";
            this.btnVizualizarDataSet.UseVisualStyleBackColor = true;
            this.btnVizualizarDataSet.Click += new System.EventHandler(this.btnVizualizarDataSet_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 20);
            this.label3.TabIndex = 80;
            this.label3.Text = "Seleccionar DataSet";
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(8, 316);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(147, 31);
            this.btnVolver.TabIndex = 82;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // listBoxDataSet
            // 
            this.listBoxDataSet.FormattingEnabled = true;
            this.listBoxDataSet.ItemHeight = 16;
            this.listBoxDataSet.Location = new System.Drawing.Point(6, 78);
            this.listBoxDataSet.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxDataSet.Name = "listBoxDataSet";
            this.listBoxDataSet.Size = new System.Drawing.Size(578, 84);
            this.listBoxDataSet.TabIndex = 79;
            this.listBoxDataSet.SelectedIndexChanged += new System.EventHandler(this.listBoxDataSet_SelectedIndexChanged);
            // 
            // VisualizarDataSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnVizualizarDataSet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxDataSet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxNombresRegistros);
            this.Controls.Add(this.textTitulo);
            this.Name = "VisualizarDataSet";
            this.Size = new System.Drawing.Size(593, 369);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxNombresRegistros;
        private System.Windows.Forms.Label textTitulo;
        private System.Windows.Forms.Button btnVizualizarDataSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ListBox listBoxDataSet;
    }
}
