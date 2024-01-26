using BE_Proyecto.Models;

namespace BE_Proyecto.Repository
{
    public interface IFacturaVentaRepository
    {
        Task<List<FacturaVenta>> ObtenerListFacturasVenta();

        Task<FacturaVenta> ObtenerFacturaVenta(int id);

        Task eliminarFacturaVenta(FacturaVenta facturaVenta);

        Task<FacturaVenta> agregarFacturaVenta(FacturaVenta facturaVenta);

        Task ActualizarFacturaVenta(FacturaVenta facturaVenta);

        Task<int> CantidadVentasUltimos7D();

        Task<int> CantidadTotalVentas();
    }
}
