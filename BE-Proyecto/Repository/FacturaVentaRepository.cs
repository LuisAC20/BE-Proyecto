using BE_Proyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Proyecto.Repository
{
    public class FacturaVentaRepository : IFacturaVentaRepository
    {
        private readonly AplicationDbContext _context;

        public FacturaVentaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FacturaVenta>> ObtenerListFacturasVenta()
        {
            return await _context.FacturasVenta.ToListAsync();
        }

        public async Task<FacturaVenta> ObtenerFacturaVenta(int id)
        {
            return await _context.FacturasVenta.FindAsync(id);
        }

        public async Task eliminarFacturaVenta(FacturaVenta facturaVenta)
        {
            _context.FacturasVenta.Remove(facturaVenta);
            await _context.SaveChangesAsync();
        }

        public async Task<FacturaVenta> agregarFacturaVenta(FacturaVenta facturaVenta)
        {
            _context.Add(facturaVenta);
            await _context.SaveChangesAsync();
            return facturaVenta;
        }

        public async Task ActualizarFacturaVenta(FacturaVenta facturaVenta)
        {
            var facturaVItem = await _context.FacturasVenta.FirstOrDefaultAsync(x => x.Id == facturaVenta.Id);

            if (facturaVItem != null)
            {
                //setear todos menos los que no se modifican o los setea auto el back
                facturaVItem.Cedula = facturaVenta.Cedula;
                facturaVItem.Nombre = facturaVenta.Nombre;
                facturaVItem.Apellido = facturaVenta.Apellido;
                facturaVItem.Correo = facturaVenta.Correo;
                facturaVItem.Telefono = facturaVenta.Telefono;
                facturaVItem.TipoVehiculo = facturaVenta.TipoVehiculo;
                facturaVItem.Marca = facturaVenta.Marca;
                facturaVItem.Modelo = facturaVenta.Modelo;
                facturaVItem.Placa = facturaVenta.Placa;
                facturaVItem.Color = facturaVenta.Color;
                facturaVItem.Anio = facturaVenta.Anio;
                facturaVItem.Kilometraje = facturaVenta.Kilometraje;
                facturaVItem.FechaVenta = facturaVenta.FechaVenta;
                facturaVItem.FormaPago = facturaVenta.FormaPago;
                facturaVItem.Precio = facturaVenta.Precio;

                await _context.SaveChangesAsync();
            }

        }

        public async Task<int> CantidadVentasUltimos7D()
        {
            DateTime fechaActual = DateTime.Now;
            DateTime fechaLimite = fechaActual.AddDays(-7);

            return await _context.FacturasVenta
                .Where(x => x.FechaCreacion >= fechaLimite && x.FechaCreacion <= fechaActual)
                .CountAsync();
        }

        public async Task<int> CantidadTotalVentas()
        {
            return await _context.FacturasVenta.CountAsync();
        }
    }
}
