using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface ITipoNombreRepository
    {
        Task<IEnumerable<TipoNombre>> GetTiposNombres();
        Task<string> GetTipoNombre(int id);
    }
}
