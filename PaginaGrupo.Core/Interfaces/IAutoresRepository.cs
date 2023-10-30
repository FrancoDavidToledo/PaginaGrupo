using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IAutoresRepository
    {
        Task<IEnumerable<Autores>> GetAutores();
        Task<Autores> GetAutor(int id);
        Task<Autores> InsertarAutor(Autores noticia);
    }
}
