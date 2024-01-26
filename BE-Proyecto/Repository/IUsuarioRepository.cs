using BE_Proyecto.Models;

namespace BE_Proyecto.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetListUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task DeleteUsuario(Usuario usuario);
        Task<Usuario> AddUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
    }
}
