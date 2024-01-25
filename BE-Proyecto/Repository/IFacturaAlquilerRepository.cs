using BE_Proyecto.Models;

namespace BE_Proyecto.Repository
{
    public interface IFacturaAlquilerRepository
    {
        Task<List<FacturaAlquiler>> ObtenerListFacturasAlquiler();

        Task<FacturaAlquiler> ObtenerFacturaAlquiler(int id);

        Task eliminarFacturaAlquiler(FacturaAlquiler facturaAlquiler);

        Task<FacturaAlquiler> agregarFacturaAlquiler(FacturaAlquiler facturaAlquiler);

        Task ActualizarFacturaAlquiler(FacturaAlquiler facturaAlquiler);
    }
}
