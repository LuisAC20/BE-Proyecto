namespace BE_Proyecto.Models.DTO
{
    public class FacturaVentaDTO
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string TipoVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }
        public int Anio { get; set; }
        public double Kilometraje { get; set; }
        public DateTime FechaVenta { get; set; }
        public string FormaPago { get; set; }
        public double Precio { get; set; }
    }
}
