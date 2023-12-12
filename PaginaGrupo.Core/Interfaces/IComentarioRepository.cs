using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IComentarioRepository : IRepository<Comentario>
    {
        Task<IEnumerable<Comentario>> GetComentariosNoticiasActivas(int idNoticia);
        Task<IEnumerable<Comentario>> GetComentariosEstado(int estado);
        Task<IEnumerable<Comentario>> GetComentariosEstadoFiltrado(int estado, string filtro);

    }
}
