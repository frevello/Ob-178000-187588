namespace Interfaz_de_usuario
{
    partial class Form1
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
            this.botonIngresar = new System.Windows.Forms.Button();
            this.textTitulo = new System.Windows.Forms.Label();
            this.botonSalir = new System.Windows.Forms.Button();
            this.textNombreDeUsuario = new System.Windows.Forms.Label();
            this.textContraseña = new System.Windows.Forms.Label();
            this.textBoxNombreUsuario = new System.Windows.Forms.TextBox();
            this.textBoxContraseña = new System.Windows.Forms.TextBox();
            this.CargarDatos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonIngresar
            // 
            this.botonIngresar.Location = new System.Drawing.Point(88, 306);
            this.botonIngresar.Name = "botonIngresar";
            this.botonIngresar.Size = new System.Drawing.Size(100, 25);
            this.botonIngresar.TabIndex = 0;
            this.botonIngresar.Text = "Ingresar";
            this.botonIngresar.UseVisualStyleBackColor = true;
            this.botonIngresar.Click += new System.EventHandler(this.botonIngresar_Click);
            // 
            // textTitulo
            // 
            this.textTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitulo.Location = new System.Drawing.Point(0, 35);
            this.textTitulo.Name = "textTitulo";
            this.textTitulo.Size = new System.Drawing.Size(433, 31);
            this.textTitulo.TabIndex = 1;
            this.textTitulo.Text = "Inicio de Sesión";
            this.textTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.textTitulo.Click += new System.EventHandler(this.textTitulo_Click);
            // 
            // botonSalir
            // 
            this.botonSalir.Location = new System.Drawing.Point(242, 306);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(100, 25);
            this.botonSalir.TabIndex = 2;
            this.botonSalir.Text = "Salir";
            this.botonSalir.UseVisualStyleBackColor = true;
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // textNombreDeUsuario
            // 
            this.textNombreDeUsuario.AutoSize = true;
            this.textNombreDeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombreDeUsuario.Location = new System.Drawing.Point(72, 158);
            this.textNombreDeUsuario.Name = "textNombreDeUsuario";
            this.textNombreDeUsuario.Size = new System.Drawing.Size(159, 20);
            this.textNombreDeUsuario.TabIndex = 3;
            this.textNombreDeUsuario.Text = "Nombre de Usuario:";
            // 
            // textContraseña
            // 
            this.textContraseña.AutoSize = true;
            this.textContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textContraseña.Location = new System.Drawing.Point(72, 238);
            this.textContraseña.Name = "textContraseña";
            this.textContraseña.Size = new System.Drawing.Size(100, 20);
            this.textContraseña.TabIndex = 4;
            this.textContraseña.Text = "Contraseña:";
            // 
            // textBoxNombreUsuario
            // 
            this.textBoxNombreUsuario.Location = new System.Drawing.Point(242, 158);
            this.textBoxNombreUsuario.Name = "textBoxNombreUsuario";
            this.textBoxNombreUsuario.Size = new System.Drawing.Size(120, 20);
            this.textBoxNombreUsuario.TabIndex = 5;
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Location = new System.Drawing.Point(241, 240);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.Size = new System.Drawing.Size(120, 20);
            this.textBoxContraseña.TabIndex = 6;
            // 
            // CargarDatos
            // 
            this.CargarDatos.Location = new System.Drawing.Point(167, 100);
            this.CargarDatos.Name = "CargarDatos";
            this.CargarDatos.Size = new System.Drawing.Size(100, 25);
            this.CargarDatos.TabIndex = 7;
            this.CargarDatos.Text = "Cargar Datos";
            this.CargarDatos.UseVisualStyleBackColor = true;
            this.CargarDatos.Click += new System.EventHandler(this.CargarDatos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 361);
            this.Controls.Add(this.CargarDatos);
            this.Controls.Add(this.textBoxContraseña);
            this.Controls.Add(this.textBoxNombreUsuario);
            this.Controls.Add(this.textContraseña);
            this.Controls.Add(this.textNombreDeUsuario);
            this.Controls.Add(this.botonSalir);
            this.Controls.Add(this.textTitulo);
            this.Controls.Add(this.botonIngresar);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Obligatorio DA 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonIngresar;
        private System.Windows.Forms.Label textTitulo;
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.Label textNombreDeUsuario;
        private System.Windows.Forms.Label textContraseña;
        private System.Windows.Forms.TextBox textBoxNombreUsuario;
        private System.Windows.Forms.TextBox textBoxContraseña;
        private System.Windows.Forms.Button CargarDatos;
    }
}

