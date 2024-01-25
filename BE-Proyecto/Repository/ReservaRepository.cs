using BE_Proyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Proyecto.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AplicationDbContext _context;

        public ReservaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reserva> AddReserva(Reserva reserva)
        {
            _context.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }


        public async Task DeleteReserva(Reserva reserva)
        {
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reserva>> GetListReservas()
        {
            return await _context.Reservas.ToListAsync();
        }

        public async Task<Reserva> GetReserva(int id)
        {

            return await _context.Reservas.FindAsync(id);
        }

        public async Task UpdateReserva(Reserva reserva)
        {
            var reservaItem = await _context.Reservas.FirstOrDefaultAsync(x => x.Id == reserva.Id);
            if (reservaItem != null)
            {
                reservaItem.Cedula = reserva.Cedula;
                reservaItem.Nombre = reserva.Nombre;
                reservaItem.Apellido = reserva.Apellido;
                reservaItem.Correo = reserva.Correo;
                reservaItem.Tipo_vehiculo = reserva.Tipo_vehiculo;
                reservaItem.Marca_Modelo = reserva.Marca_Modelo;
                reservaItem.Fecha_Inicio = reserva.Fecha_Inicio;
                reservaItem.Fecha_Fin = reserva.Fecha_Fin;

                await _context.SaveChangesAsync();
            }

        }

        public async Task<int> CantidadReservas()
        {
            DateTime fechaActual = DateTime.Now;
            DateTime fechaLimite = fechaActual.AddDays(7);

            return await _context.Reservas
                .Where(x => x.Fecha_Inicio >= fechaActual && x.Fecha_Inicio <= fechaLimite)
                .CountAsync();
        }

        public async Task<int> CantidadTotalReservas()
        {
            return await _context.Reservas.CountAsync();
        }


    }
}
