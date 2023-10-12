using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IUnidadRepository
    {
        Task<IEnumerable<Unidad>> GetUnidades();
        Task<Unidad> GetUnidad(string codigo);
    }
}
