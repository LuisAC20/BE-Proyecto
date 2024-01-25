using BE_Proyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Proyecto.Repository
{
    public class FacturaLavadoRepository : IFacturaLavadoRepository
    {
        private readonly AplicationDbContext _context;

        public FacturaLavadoRepository(AplicationDbContext context)
        { 
            _context = context;
        }

        public async Task<List<FacturaAutolavado>> ObtenerListFacturasLavado()
        {
            return await _context.FacturasAutolavado.ToListAsync();
        }

        public async Task<FacturaAutolavado> ObtenerFacturaLavado(int id)
        {
            return await _context.FacturasAutolavado.FindAsync(id);
        }

        public async Task eliminarFacturaLavado(FacturaAutolavado facturaLavado)
        {
            _context.FacturasAutolavado.Remove(facturaLavado);
            await _context.SaveChangesAsync();
        }

        public async Task<FacturaAutolavado> agregarFacturaLavado(FacturaAutolavado facturaLavado)
        {
            _context.Add(facturaLavado);
            await _context.SaveChangesAsync();
            return facturaLavado;
        }

        public async Task ActualizarFacturaLavado(FacturaAutolavado facturaLavado)
        {
            var facturaLvdAnt = await _context.FacturasAutolavado.FirstOrDefaultAsync(x => x.Id == facturaLavado.Id);

            if (facturaLvdAnt != null)
            {
                //setear todos menos los q no se modifican o los setea auto el back
                facturaLvdAnt.Cedula = facturaLavado.Cedula;
                facturaLvdAnt.Nombres = facturaLavado.Nombres;
                facturaLvdAnt.Apellidos = facturaLavado.Apellidos;
                facturaLvdAnt.TipoVehiculo = facturaLavado.TipoVehiculo;
                facturaLvdAnt.TipoLavado = facturaLavado.TipoLavado;
                facturaLvdAnt.DetallesServicio = facturaLavado.DetallesServicio;
                facturaLvdAnt.PrecioFinal = facturaLavado.PrecioFinal;
                facturaLvdAnt.MetodoPago = facturaLavado.MetodoPago;

                await _context.SaveChangesAsync();
            }

        }
    }
}
