using BE_Proyecto.Models;

namespace BE_Proyecto.Repository
{
    public interface IVehiculoRepository
    {
        Task<List<Vehiculo>> ObtenerListVehiculos();

        Task<Vehiculo> ObtenerVehiculo(int id);

        Task eliminarVehiculo(Vehiculo vehiculo);

        Task<Vehiculo> AgregarVehiculo(Vehiculo vehiculo);

        Task ActualizarVehiculo(Vehiculo vehiculo);
    }
}
