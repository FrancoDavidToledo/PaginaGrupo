using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IProgresionScoutRepository
    {
        Task<IEnumerable<ProgresionScout>> GetProgresionesScouts();
        Task<ProgresionScout> GetProgresionScout(int id);
        Task<ProgresionScout> InsertarProgresionScout(ProgresionScout progresionScout);
    }
}
