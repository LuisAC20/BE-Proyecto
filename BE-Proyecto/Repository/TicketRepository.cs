using BE_Proyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Proyecto.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AplicationDbContext _context;

        public TicketRepository(AplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Ticket>> ObtenerListadoTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> ObtenerTicket(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task EliminarTicket(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task<Ticket> AgregarTicket(Ticket ticket)
        {
            _context.Add(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        public async Task ActualizarTicket(Ticket ticket)
        {
            var ticketAnt = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == ticket.Id);

            if (ticketAnt != null)
            {
                //setear todos menos los q no se modifican o los setea auto el back
                ticketAnt.Tipo = ticket.Tipo;
                ticketAnt.Cedula = ticket.Cedula;
                ticketAnt.Nombres = ticket.Nombres;
                ticketAnt.Apellidos = ticket.Apellidos;
                ticketAnt.Correo = ticket.Correo;
                ticketAnt.Telefono = ticket.Telefono;
                ticketAnt.CategoriaInquietud = ticket.CategoriaInquietud;
                ticketAnt.Prioridad = ticket.Prioridad;
                ticketAnt.MetodoContactoPreferido = ticket.MetodoContactoPreferido;
                ticketAnt.Detalles = ticket.Detalles;
                ticketAnt.Estado = ticket.Estado;

                await _context.SaveChangesAsync();
            }


        }
    }
}
