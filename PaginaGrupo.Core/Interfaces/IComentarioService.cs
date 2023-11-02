using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IComentarioService
    {
        Task<IEnumerable<Comentario>> GetComentariosNoticiasActivas(int idNoticia);
        Task<IEnumerable<Comentario>> GetComentariosEstado(int estado);
    }
}