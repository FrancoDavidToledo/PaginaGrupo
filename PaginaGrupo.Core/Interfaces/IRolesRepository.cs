using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IRolesRepository
    {
        Task<IEnumerable<Roles>> GetRoles();
        Task<Roles> GetRol(int id);
    }
}
