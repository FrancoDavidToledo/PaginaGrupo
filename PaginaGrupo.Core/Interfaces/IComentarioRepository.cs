using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IComentarioRepository
    {
        Task<IEnumerable<Comentario>> GetComentarios();
        Task<Comentario> GetComentario(int id);
        Task<Comentario> InsertarComentario(Comentario comentario);
    }
}
