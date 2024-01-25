using Microsoft.EntityFrameworkCore;
namespace BE_Proyecto.Models
{
    public class AplicationDbContext:DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Solicitud> Solicitudes { get; set; }

        public DbSet<Cotizacion> Cotizaciones { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<FacturaAutolavado> FacturasAutolavado { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Servicio> Servicios { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<FacturaVenta> FacturasVenta { get; set; }

        public DbSet<FacturaAlquiler> FacturasAlquiler { get; set; }


    }
}
