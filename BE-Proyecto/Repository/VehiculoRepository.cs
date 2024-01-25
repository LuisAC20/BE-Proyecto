using BE_Proyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Proyecto.Repository
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly AplicationDbContext _context;

        public VehiculoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vehiculo>> ObtenerListVehiculos()
        {
            return await _context.Vehiculos.ToListAsync();
        }

        public async Task<Vehiculo> ObtenerVehiculo(int id)
        {
            return await _context.Vehiculos.FindAsync(id);
        }

        public async Task eliminarVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
        }

        public async Task<Vehiculo> AgregarVehiculo(Vehiculo vehiculo)
        {
            _context.Add(vehiculo);
            await _context.SaveChangesAsync();
            return vehiculo;
        }

        public async Task ActualizarVehiculo(Vehiculo vehiculo)
        {
            var vehiculoAnt = await _context.Vehiculos.FirstOrDefaultAsync(x => x.Id == vehiculo.Id);

            if (vehiculoAnt != null)
            {
                //setear todos menos los q no se modifican o los setea auto el back
                vehiculoAnt.Disponibilidad = vehiculo.Disponibilidad;
                vehiculoAnt.Marca = vehiculo.Marca;
                vehiculoAnt.Modelo = vehiculo.Modelo;
                vehiculoAnt.Tipo = vehiculo.Tipo;
                vehiculoAnt.Anio = vehiculo.Anio;
                vehiculoAnt.Kilometraje = vehiculo.Kilometraje;
                vehiculoAnt.Estado = vehiculo.Estado;
                vehiculoAnt.Color = vehiculo.Color;
                vehiculoAnt.Placa = vehiculo.Placa;
                vehiculoAnt.Precio = vehiculo.Precio;

                await _context.SaveChangesAsync();
            }

        }
    }
}
