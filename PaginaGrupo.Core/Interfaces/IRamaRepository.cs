using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IRamaRepository
    {
        Task<IEnumerable<Rama>> GetRamas();
        Task<Rama> GetRama(string codigo);
    }
}
