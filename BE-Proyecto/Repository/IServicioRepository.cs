using BE_Proyecto.Models;

namespace BE_Proyecto.Repository
{
    public interface IServicioRepository
    {
        Task<List<Servicio>> GetListServicio();
        Task<Servicio> GetServicio(int id);
        Task DeleteServicio(Servicio servicio);
        Task<Servicio> AddServicio(Servicio servicio);
        Task UpdateServicio(Servicio servicio);
    }
}
