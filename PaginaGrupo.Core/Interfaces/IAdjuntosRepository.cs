using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IAdjuntosRepository
    {
        Task<IEnumerable<Adjuntos>> GetAdjuntos();
        Task<Adjuntos> GetAdjunto(int id);
        Task<Adjuntos> InsertarAdjunto(Adjuntos adjuntos);
    }
}
