namespace BE_Proyecto.Models.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public int Cedula { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Correo { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
    }
}
