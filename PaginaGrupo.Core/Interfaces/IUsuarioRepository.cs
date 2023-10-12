using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> InsertarUsuario(Usuario usuario);
    }
}
