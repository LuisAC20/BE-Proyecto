namespace BE_Proyecto.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public int Cedula { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Correo { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
