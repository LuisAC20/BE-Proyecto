using BE_Proyecto.Models;

namespace BE_Proyecto.Repository
{
    public interface IFacturaLavadoRepository
    {
        Task<List<FacturaAutolavado>> ObtenerListFacturasLavado();

        Task<FacturaAutolavado> ObtenerFacturaLavado(int id);

        Task eliminarFacturaLavado(FacturaAutolavado facturaLavado);

        Task<FacturaAutolavado> agregarFacturaLavado(FacturaAutolavado facturaLavado);

        Task ActualizarFacturaLavado(FacturaAutolavado facturaLavado);
    }
}
