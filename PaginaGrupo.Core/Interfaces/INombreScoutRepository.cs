using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface INombreScoutRepository
    {
        Task<IEnumerable<NombreScout>> GetNombresScouts();
        Task<NombreScout> GetNombreScout(int id);
        Task<NombreScout> InsertarNombreScout (NombreScout nombreScout);
    }
}
