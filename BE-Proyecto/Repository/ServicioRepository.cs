using BE_Proyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Proyecto.Repository
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly AplicationDbContext _context;
        public ServicioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Servicio> AddServicio(Servicio servicio)
        {
            _context.Add(servicio);
            await _context.SaveChangesAsync();
            return servicio;
        }

        public async Task DeleteServicio(Servicio servicio)
        {
            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Servicio>> GetListServicio()
        {
            return await _context.Servicios.ToListAsync();
        }

        public async Task<Servicio> GetServicio(int id)
        {

            return await _context.Servicios.FindAsync(id);
        }

        public async Task UpdateServicio(Servicio servicio)
        {
            var servicioItem = await _context.Servicios.FirstOrDefaultAsync(x => x.Id == servicio.Id);
            if (servicioItem != null)
            {
                servicioItem.Cedula = servicio.Cedula;
                servicioItem.Nombre = servicio.Nombre;
                servicioItem.Apellido = servicio.Apellido;
                servicioItem.Correo = servicio.Correo;
                servicioItem.Tipo_vehiculo = servicio.Tipo_vehiculo;
                servicioItem.Marca_Modelo = servicio.Marca_Modelo;
                servicioItem.Fecha_Inicio = servicio.Fecha_Inicio;
                servicioItem.Fecha_Fin = servicio.Fecha_Fin;

                await _context.SaveChangesAsync();
            }

        }
    }
}
