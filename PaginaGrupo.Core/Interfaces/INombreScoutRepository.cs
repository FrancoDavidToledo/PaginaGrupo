using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface INombreScoutRepository : IRepository<NombreScout>
    {
        IEnumerable<NombreScout> GetNombresScout(int idScout);
        //Task<IEnumerable<NombreScout>> GetNombresScouts();
        //Task<NombreScout> GetNombreScout(int id);
        //Task<NombreScout> InsertarNombreScout(NombreScout nombreScout);
    }
}
