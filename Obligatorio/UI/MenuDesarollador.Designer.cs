namespace Interfaz_de_usuario
{
    partial class MenuDesarollador
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.botonSalir = new System.Windows.Forms.Button();
            this.botonEstadisticas = new System.Windows.Forms.Button();
            this.botonListaDataSets = new System.Windows.Forms.Button();
            this.botonCargarArchivo = new System.Windows.Forms.Button();
            this.botonDatosUsuario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Location = new System.Drawing.Point(221, 22);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(445, 300);
            this.panelPrincipal.TabIndex = 26;
            // 
            // botonSalir
            // 
            this.botonSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonSalir.Location = new System.Drawing.Point(52, 297);
            this.botonSalir.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(110, 25);
            this.botonSalir.TabIndex = 25;
            this.botonSalir.Text = "Salir";
            this.botonSalir.UseVisualStyleBackColor = true;
            // 
            // botonEstadisticas
            // 
            this.botonEstadisticas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEstadisticas.Location = new System.Drawing.Point(52, 232);
            this.botonEstadisticas.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.botonEstadisticas.Name = "botonEstadisticas";
            this.botonEstadisticas.Size = new System.Drawing.Size(110, 25);
            this.botonEstadisticas.TabIndex = 24;
            this.botonEstadisticas.Text = "Estadisticas";
            this.botonEstadisticas.UseVisualStyleBackColor = true;
            this.botonEstadisticas.Click += new System.EventHandler(this.botonEstadisticas_Click);
            // 
            // botonListaDataSets
            // 
            this.botonListaDataSets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonListaDataSets.Location = new System.Drawing.Point(52, 179);
            this.botonListaDataSets.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.botonListaDataSets.Name = "botonListaDataSets";
            this.botonListaDataSets.Size = new System.Drawing.Size(110, 25);
            this.botonListaDataSets.TabIndex = 23;
            this.botonListaDataSets.Text = "Lista Data Sets";
            this.botonListaDataSets.UseVisualStyleBackColor = true;
            this.botonListaDataSets.Click += new System.EventHandler(this.botonListaDataSets_Click);
            // 
            // botonCargarArchivo
            // 
            this.botonCargarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonCargarArchivo.Location = new System.Drawing.Point(52, 126);
            this.botonCargarArchivo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.botonCargarArchivo.Name = "botonCargarArchivo";
            this.botonCargarArchivo.Size = new System.Drawing.Size(110, 25);
            this.botonCargarArchivo.TabIndex = 22;
            this.botonCargarArchivo.Text = "Cargar Archivo";
            this.botonCargarArchivo.UseVisualStyleBackColor = true;
            this.botonCargarArchivo.Click += new System.EventHandler(this.botonCargarArchivo_Click);
            // 
            // botonDatosUsuario
            // 
            this.botonDatosUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonDatosUsuario.Location = new System.Drawing.Point(52, 73);
            this.botonDatosUsuario.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.botonDatosUsuario.Name = "botonDatosUsuario";
            this.botonDatosUsuario.Size = new System.Drawing.Size(110, 25);
            this.botonDatosUsuario.TabIndex = 21;
            this.botonDatosUsuario.Text = "Datos Usuario";
            this.botonDatosUsuario.UseVisualStyleBackColor = true;
            this.botonDatosUsuario.Click += new System.EventHandler(this.botonDatosUsuario_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "Menu Principal";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MenuDesarollador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.botonSalir);
            this.Controls.Add(this.botonEstadisticas);
            this.Controls.Add(this.botonListaDataSets);
            this.Controls.Add(this.botonCargarArchivo);
            this.Controls.Add(this.botonDatosUsuario);
            this.Controls.Add(this.label1);
            this.Name = "MenuDesarollador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Obligatorio DA 1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.Button botonEstadisticas;
        private System.Windows.Forms.Button botonListaDataSets;
        private System.Windows.Forms.Button botonCargarArchivo;
        private System.Windows.Forms.Button botonDatosUsuario;
        private System.Windows.Forms.Label label1;
    }
}