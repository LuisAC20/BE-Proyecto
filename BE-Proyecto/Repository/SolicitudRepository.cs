using BE_Proyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Proyecto.Repository
{
    public class SolicitudRepository : ISolicitudRepository
    {
        private readonly AplicationDbContext _context;
        public SolicitudRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Solicitud> AddSolicitud(Solicitud solicitud)
        {
            _context.Add(solicitud);
            await _context.SaveChangesAsync();
            return solicitud;
        }

        public async Task DeleteSolicitud(Solicitud solicitud)
        {
            _context.Solicitudes.Remove(solicitud);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Solicitud>> GetListSolicitudes()
        {
            return await _context.Solicitudes.ToListAsync();
        }

        public async Task<Solicitud> GetSolicitud(int id)
        {

            return await _context.Solicitudes.FindAsync(id);
        }

        public async Task UpdateSolicitud(Solicitud solicitud)
        {
            var solicitudItem = await _context.Solicitudes.FirstOrDefaultAsync(x => x.Id == solicitud.Id);

            if (solicitudItem != null)
            {
                solicitudItem.Cedula = solicitud.Cedula;
                solicitudItem.Nombre = solicitud.Nombre;
                solicitudItem.Apellido = solicitud.Apellido;
                solicitudItem.Correo = solicitud.Correo;
                solicitudItem.Tipo_vehiculo = solicitud.Tipo_vehiculo;
                solicitudItem.Marca_Modelo = solicitud.Marca_Modelo;


                await _context.SaveChangesAsync();
            }

        }
    }
}
