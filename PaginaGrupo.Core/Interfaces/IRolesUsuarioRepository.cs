using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IRolesUsuarioRepository
    {
        Task<IEnumerable<RolesUsuario>> GetRolesUsuarios();
        Task<RolesUsuario> GetRolUsuario(int id);
        Task<RolesUsuario> InsertarRolesUsuario(RolesUsuario rolesUsuario);
    }
}
