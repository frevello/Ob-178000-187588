namespace Interfaz_de_usuario
{
    partial class ValidarArchivo
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
            this.btnBuscarArchivo = new System.Windows.Forms.Button();
            this.textTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBuscarArchivo
            // 
            this.btnBuscarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarArchivo.Location = new System.Drawing.Point(180, 165);
            this.btnBuscarArchivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.Size = new System.Drawing.Size(204, 31);
            this.btnBuscarArchivo.TabIndex = 64;
            this.btnBuscarArchivo.Text = "Buscar Archivo";
            this.btnBuscarArchivo.UseVisualStyleBackColor = true;
            this.btnBuscarArchivo.Click += new System.EventHandler(this.btnBuscarArchivo_Click);
            // 
            // textTitulo
            // 
            this.textTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitulo.Location = new System.Drawing.Point(0, 17);
            this.textTitulo.Margin = new System.Windows.Forms.Padding(4, 12, 4, 0);
            this.textTitulo.Name = "textTitulo";
            this.textTitulo.Size = new System.Drawing.Size(593, 34);
            this.textTitulo.TabIndex = 63;
            this.textTitulo.Text = "Validar Archivo";
            this.textTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ValidarArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBuscarArchivo);
            this.Controls.Add(this.textTitulo);
            this.Name = "ValidarArchivo";
            this.Size = new System.Drawing.Size(593, 369);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarArchivo;
        private System.Windows.Forms.Label textTitulo;
    }
}
