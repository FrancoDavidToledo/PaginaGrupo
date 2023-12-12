using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IAdjuntoService
    {
        Task<IEnumerable<Adjuntos>> GetAdjuntosNoticia(int idNoticia);
        Task<Adjuntos> InsertarAdjunto(Adjuntos adjunto);
        Task<string> GetAdjuntoPrincipal(int idNoticia);
        Task<bool> EliminarAdjunto(int id);
    }
}