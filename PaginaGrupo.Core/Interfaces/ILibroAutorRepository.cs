using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface ILibroAutorRepository
    {
        Task<IEnumerable<LibroAutor>> GetLibrosAutores();
        Task<LibroAutor> GetLibroAutor(int id);
        Task<LibroAutor> InsertarLibroAutor(LibroAutor libroAutor);
    }
}
