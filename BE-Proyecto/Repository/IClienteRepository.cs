using BE_Proyecto.Models;

namespace BE_Proyecto.Repository
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetListCliente();
        Task<Cliente> GetCliente(int id);

        Task DeleteCliente(Cliente cliente);

        Task<Cliente> AddCliente(Cliente cliente);

        Task UpdateCliente(Cliente cliente);
    }
}
