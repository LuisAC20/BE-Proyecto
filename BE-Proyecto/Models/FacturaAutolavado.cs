namespace BE_Proyecto.Models
{
    public class FacturaAutolavado
    {
        public int Id { get; set; }

        public String Cedula { get; set; }

        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String TipoVehiculo { get; set; }
        public String TipoLavado { get; set; }

        public String DetallesServicio { get; set; }

        public float PrecioFinal { get; set; }
        public String MetodoPago { get; set; }

        public DateTime FechaEmision { get; set; }
    }
}
