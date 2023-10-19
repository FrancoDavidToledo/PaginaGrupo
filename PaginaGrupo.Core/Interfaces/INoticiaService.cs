using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface INoticiasService
    {
    
        Task<IEnumerable<Noticias>> GetNoticias();
        Task<Noticias> GetNoticia(int id);
        Task<Noticias> InsertarNoticia(Noticias noticia);
        Task<bool> ActualizarNoticia(Noticias noticia);
        Task<bool> BorrarNoticia(int id);
    }
}