using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface ITipoAdjuntoRepository
    {
        Task<IEnumerable<TipoAdjunto>> GetTiposAdjuntos();
        Task<TipoAdjunto> GetTipoAdjunto(int id);
    }
}
