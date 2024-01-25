namespace BE_Proyecto.Models.DTO
{
    public class TicketDTO
    {
        public int Id { get; set; }

        public String Tipo { get; set; }
        public String Cedula { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }

        public String Correo { get; set; }

        public String Telefono { get; set; }
        public String CategoriaInquietud { get; set; }

        public String Prioridad { get; set; }
        public String MetodoContactoPreferido { get; set; }
        public String Estado { get; set; }

        public String Detalles { get; set; }
    }
}
