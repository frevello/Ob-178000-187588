using System;

namespace Dominio
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public String nombreUsuario { get; set; }
        public String nombre { get; set; }
        public String contraseña { get; set; }
        public String apellido { get; set; }
        public String rol { get; set; }
        public DateTime registro { get; set; }
        public DateTime ultimoIngreso { get; set; }

        private const int MIN_LARGO_CONTRASEÑA = 3;

        public Usuario()
        {
            Id = Guid.NewGuid();
        }

        public Usuario(String nombreUsuario, String nombre, String contraseña, String apellido, String rol)
        {
            ValidarNoVacio(nombreUsuario, "ERROR: Nombre usuario vacio");
            ValidarNoVacio(nombre, "ERROR: Nombre vacio");
            ValidarNoVacio(apellido, "ERROR: Apellido vacio");
            ContraseñaCorrecta(contraseña, "ERROR: Contraseña menor a 3");
            Id = Guid.NewGuid();
            this.nombreUsuario = nombreUsuario;
            this.nombre = nombre;
            this.contraseña = contraseña;
            this.apellido = apellido;
            this.registro = DateTime.Now;
            this.ultimoIngreso = DateTime.Now;
            this.rol = rol;
        }

        private void ValidarNoVacio(String campo, String mensaje)
        {
            if(campo.Length == 0)
            {
                throw new LargoDatoNoValidoException(mensaje);
            }
        }

        private void ContraseñaCorrecta(String contraseña, String mensaje)
        {
            if (contraseña.Length < MIN_LARGO_CONTRASEÑA)
            {
                throw new LargoDatoNoValidoException(mensaje);
            }
        }
    }
}
