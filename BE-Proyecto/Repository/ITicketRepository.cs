using BE_Proyecto.Models;

namespace BE_Proyecto.Repository
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> ObtenerListadoTickets();

        Task<Ticket> ObtenerTicket(int id);

        Task EliminarTicket(Ticket ticket);

        Task<Ticket> AgregarTicket(Ticket ticket);

        Task ActualizarTicket(Ticket ticket);

    }
}
