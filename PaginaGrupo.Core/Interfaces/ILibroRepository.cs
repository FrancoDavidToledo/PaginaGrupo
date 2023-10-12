using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface ILibroRepository
    {
        Task<IEnumerable<Libro>> GetLibros();
        Task<Libro> GetLibro(int id);
        Task<Libro> InsertarLibro(Libro libro);
    }
}
