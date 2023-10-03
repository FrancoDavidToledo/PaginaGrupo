using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface INoticiasRepository
    {
        Task<IEnumerable<Noticia>> GetNoticias();
        Task<Noticia> GetNoticia(int id);
    }
}
