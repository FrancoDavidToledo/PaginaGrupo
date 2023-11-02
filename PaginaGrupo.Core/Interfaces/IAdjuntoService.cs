using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IAdjuntoService
    {
        Task<IEnumerable<Adjuntos>> GetAdjuntosNoticia(int idNoticia);
    }
}