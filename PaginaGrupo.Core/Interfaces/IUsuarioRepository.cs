using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetLoginByCredentials(UserLogin login);
        Task<IEnumerable<Usuario>> GetUsuariosRol(RolType rol);
    }
}