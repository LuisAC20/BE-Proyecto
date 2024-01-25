using BE_Proyecto.Models;

namespace BE_Proyecto.Repository
{
    public interface ICotizacionRepository
    {
        Task<List<Cotizacion>> ObtenerListaCotizaciones();
        Task<Cotizacion> ObtenerCotizacion(int id);

        Task EliminarCotizacion(Cotizacion cotizacion);

        Task<Cotizacion> AgregarCotizacion(Cotizacion cotizacion);

        Task ActualizarCotizacion(Cotizacion cotizacion);
    }
}
