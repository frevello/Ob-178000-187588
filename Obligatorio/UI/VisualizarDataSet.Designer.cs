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
            this.btnSelect = new System.Windows.Forms.Button();
            this.listBoxNombresRegistros = new System.Windows.Forms.ListBox();
            this.textTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 20);
            this.label4.TabIndex = 78;
            this.label4.Text = "Seleccionar Variable";
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(30, 300);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(110, 31);
            this.btnSelect.TabIndex = 77;
            this.btnSelect.Text = "Seleccionar";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // listBoxNombresRegistros
            // 
            this.listBoxNombresRegistros.FormattingEnabled = true;
            this.listBoxNombresRegistros.ItemHeight = 16;
            this.listBoxNombresRegistros.Location = new System.Drawing.Point(30, 96);
            this.listBoxNombresRegistros.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxNombresRegistros.Name = "listBoxNombresRegistros";
            this.listBoxNombresRegistros.Size = new System.Drawing.Size(110, 196);
            this.listBoxNombresRegistros.TabIndex = 76;
            // 
            // textTitulo
            // 
            this.textTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitulo.Location = new System.Drawing.Point(0, 19);
            this.textTitulo.Margin = new System.Windows.Forms.Padding(4, 12, 4, 0);
            this.textTitulo.Name = "textTitulo";
            this.textTitulo.Size = new System.Drawing.Size(593, 34);
            this.textTitulo.TabIndex = 75;
            this.textTitulo.Text = "Visualizacion DataSet";
            this.textTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(174, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 285);
            this.panel1.TabIndex = 79;
            // 
            // VisualizarDataSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.listBoxNombresRegistros);
            this.Controls.Add(this.textTitulo);
            this.Name = "VisualizarDataSet";
            this.Size = new System.Drawing.Size(593, 369);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ListBox listBoxNombresRegistros;
        private System.Windows.Forms.Label textTitulo;
        private System.Windows.Forms.Panel panel1;
    }
}
