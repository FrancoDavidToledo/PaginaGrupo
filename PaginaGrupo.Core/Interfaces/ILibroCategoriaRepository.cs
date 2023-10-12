using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface ILibroCategoriaRepository
    {
        Task<IEnumerable<LibroCategoria>> GetLibrosCategorias();
        Task<LibroCategoria> GetLibroCategoria(int id);
        Task<LibroCategoria> InsertarLibroCategoria(LibroCategoria libroCategoria);
    }
}
