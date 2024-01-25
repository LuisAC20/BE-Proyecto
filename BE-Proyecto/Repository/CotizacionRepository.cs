using BE_Proyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Proyecto.Repository
{
    public class CotizacionRepository : ICotizacionRepository
    {
        private readonly AplicationDbContext _context;

        public CotizacionRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cotizacion>> ObtenerListaCotizaciones()
        {
            return await _context.Cotizaciones.ToListAsync();
        }

        public async Task<Cotizacion> ObtenerCotizacion(int id)
        {
            return await _context.Cotizaciones.FindAsync(id);
        }

        public async Task EliminarCotizacion(Cotizacion cotizacion)
        {
            _context.Cotizaciones.Remove(cotizacion);
            await _context.SaveChangesAsync();
        }

        public async Task<Cotizacion> AgregarCotizacion(Cotizacion cotizacion)
        {
            _context.Add(cotizacion);
            await _context.SaveChangesAsync();

            return cotizacion;
        }

        public async Task ActualizarCotizacion(Cotizacion cotizacion)
        {
            var cotizacionAnt = await _context.Cotizaciones.FirstOrDefaultAsync(x => x.Id == cotizacion.Id);

            if (cotizacionAnt != null)
            {
                //setear todos menos los q no se modifican o los setea auto el back
                cotizacionAnt.tipo = cotizacion.tipo;
                cotizacionAnt.Cedula = cotizacion.Cedula;
                cotizacionAnt.Nombres = cotizacion.Nombres;
                cotizacionAnt.Apellidos = cotizacion.Apellidos;
                cotizacionAnt.Correo = cotizacion.Correo;
                cotizacionAnt.Telefono = cotizacion.Telefono;
                cotizacionAnt.TipoVehiculo = cotizacion.TipoVehiculo;
                cotizacionAnt.Vehiculo = cotizacion.Vehiculo;
                cotizacionAnt.MetodoPago = cotizacion.MetodoPago;
                cotizacionAnt.FechaEstimadaCompraAlquiler = cotizacion.FechaEstimadaCompraAlquiler;
                cotizacionAnt.FechaRecogida = cotizacion.FechaRecogida;
                cotizacionAnt.FechaDevolucion = cotizacion.FechaDevolucion;

                await _context.SaveChangesAsync();
            }

        }
    }
}
