using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IScoutRepository
    {
        Task<IEnumerable<Scout>> GetScouts();
        Task<Scout> GetScout(int id);
        Task<Scout> InsertarScout(Scout scout);
    }
}
