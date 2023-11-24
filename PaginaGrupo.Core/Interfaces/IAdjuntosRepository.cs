using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IAdjuntosRepository : IRepository<Adjuntos>
    {
        Task<IEnumerable<Adjuntos>> GetAdjuntosNoticia(int idNoticia);
        Task<Adjuntos> GetAdjunto(int idNoticia);

        //Task<Adjuntos> InsertarAdjunto(Adjuntos adjuntos);
    }
}
