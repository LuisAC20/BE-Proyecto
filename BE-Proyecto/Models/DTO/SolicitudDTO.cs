﻿namespace BE_Proyecto.Models.DTO
{
    public class SolicitudDTO
    {
        public int Id { get; set; }
        public int Cedula { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }

        public String Correo { get; set; }
        public String Tipo_vehiculo { get; set; }
        public String Marca_Modelo { get; set; }
    }
}
