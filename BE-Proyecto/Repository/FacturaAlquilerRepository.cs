using BE_Proyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Proyecto.Repository
{
    public class FacturaAlquilerRepository : IFacturaAlquilerRepository
    {
        private readonly AplicationDbContext _context;

        public FacturaAlquilerRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FacturaAlquiler>> ObtenerListFacturasAlquiler()
        {
            return await _context.FacturasAlquiler.ToListAsync();
        }

        public async Task<FacturaAlquiler> ObtenerFacturaAlquiler(int id)
        {
            return await _context.FacturasAlquiler.FindAsync(id);
        }

        public async Task eliminarFacturaAlquiler(FacturaAlquiler facturaAlquiler)
        {
            _context.FacturasAlquiler.Remove(facturaAlquiler);
            await _context.SaveChangesAsync();
        }

        public async Task<FacturaAlquiler> agregarFacturaAlquiler(FacturaAlquiler facturaAlquiler)
        {
            _context.Add(facturaAlquiler);
            await _context.SaveChangesAsync();
            return facturaAlquiler;
        }

        public async Task ActualizarFacturaAlquiler(FacturaAlquiler facturaAlquiler)
        {
            var facturaAItem = await _context.FacturasAlquiler.FirstOrDefaultAsync(x => x.Id == facturaAlquiler.Id);

            if (facturaAItem != null)
            {
                //setear todos menos los que no se modifican o los setea auto el back
                facturaAItem.Cedula = facturaAlquiler.Cedula;
                facturaAItem.Nombre = facturaAlquiler.Nombre;
                facturaAItem.Apellido = facturaAlquiler.Apellido;
                facturaAItem.Correo = facturaAlquiler.Correo;
                facturaAItem.Telefono = facturaAlquiler.Telefono;
                facturaAItem.TipoVehiculo = facturaAlquiler.TipoVehiculo;
                facturaAItem.Marca = facturaAlquiler.Marca;
                facturaAItem.Modelo = facturaAlquiler.Modelo;
                facturaAItem.Placa = facturaAlquiler.Placa;
                facturaAItem.Color = facturaAlquiler.Color;
                facturaAItem.Anio = facturaAlquiler.Anio;
                facturaAItem.Kilometraje = facturaAlquiler.Kilometraje;
                facturaAItem.FechaInicio = facturaAlquiler.FechaInicio;
                facturaAItem.FechaDevolucion = facturaAlquiler.FechaDevolucion;
                facturaAItem.FormaPago = facturaAlquiler.FormaPago;
                facturaAItem.Precio = facturaAlquiler.Precio;

                await _context.SaveChangesAsync();
            }

        }
    }
}
