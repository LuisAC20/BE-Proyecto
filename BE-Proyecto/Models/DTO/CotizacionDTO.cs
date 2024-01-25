namespace BE_Proyecto.Models.DTO
{
    public class CotizacionDTO
    {
        public int Id { get; set; }

        public String tipo { get; set; }
        public String Cedula { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }

        public String Correo { get; set; }

        public String Telefono { get; set; }
        public String TipoVehiculo { get; set; }
        public String Vehiculo { get; set; }

        public String MetodoPago { get; set; }

        public DateTime FechaEstimadaCompraAlquiler { get; set; }
        public DateTime FechaRecogida { get; set; }

        public DateTime FechaDevolucion { get; set; }
    }
}
