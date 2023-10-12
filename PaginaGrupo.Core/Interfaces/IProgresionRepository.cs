using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IProgresionRepository
    {
        Task<IEnumerable<Progresion>> GetProgresiones();
        Task<Progresion> GetProgresion(int id);
    }
}
