using BE_Proyecto.Models;

namespace BE_Proyecto.Repository
{
    public interface ISolicitudRepository
    {
        Task<List<Solicitud>> GetListSolicitudes();
        Task<Solicitud> GetSolicitud(int id);

        Task DeleteSolicitud(Solicitud solicitud);

        Task<Solicitud> AddSolicitud(Solicitud solicitud);

        Task UpdateSolicitud(Solicitud solicitud);
    }
}
