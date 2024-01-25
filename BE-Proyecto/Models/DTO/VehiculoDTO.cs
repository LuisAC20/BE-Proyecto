﻿namespace BE_Proyecto.Models.DTO
{
    public class VehiculoDTO
    {
        public int Id { get; set; }

        public String Disponibilidad { get; set; }

        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Tipo { get; set; }
        public int Anio { get; set; }

        public String Kilometraje { get; set; }

        public String Estado { get; set; }
        public String Color { get; set; }

        public String Placa { get; set; }

        public decimal Precio { get; set; }
    }
}
