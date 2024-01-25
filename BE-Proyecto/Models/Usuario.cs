namespace BE_Proyecto.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Cedula { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Sexo { get; set; }
        public String Correo { get; set; }
        public String Telefono { get; set; }
        public String Domicilio { get; set; }
        public String Rol { get; set; }
        public String Area { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public DateTime fechaRegistro { get; set; }
        public String Estado { get; set; }
    }
}
