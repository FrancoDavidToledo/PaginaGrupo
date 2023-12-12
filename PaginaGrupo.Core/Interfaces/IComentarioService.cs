using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IComentarioService
    {
        Task<Comentario> GetComentario(int id);
        Task<IEnumerable<Comentario>> GetComentariosNoticiasActivas(int idNoticia);
        Task<IEnumerable<Comentario>> GetComentariosEstado(int estado, int? idNoticia);
        Task<IEnumerable<Comentario>> GetComentariosEstadoFiltrado(int estado, string filtro);
        Task<Comentario> InsertarComentario(Comentario comentario);
        Task<bool> ActualizarComentario(Comentario comentario);
    }
}