using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Usuario usuario);
        IEnumerable<Usuario> GetUsuarios();
        Task<Usuario> GetUsuario(int id);

        Task<IEnumerable<Usuario>> GetUsuariosRol(RolType rol);
    }
}