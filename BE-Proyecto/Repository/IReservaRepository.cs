using BE_Proyecto.Models;

namespace BE_Proyecto.Repository
{
    public interface IReservaRepository
    {
        Task<List<Reserva>> GetListReservas();
        Task<Reserva> GetReserva(int id);

        Task DeleteReserva(Reserva reserva);

        Task<Reserva> AddReserva(Reserva reserva);

        Task UpdateReserva(Reserva reserva);

        //Task<int> CantidadReservas(DateTime horas);

        Task<int> CantidadReservas();

        Task<int> CantidadTotalReservas();
    }
}
