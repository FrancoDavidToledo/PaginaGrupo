using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface ICategoriasRepository
    {
        Task<IEnumerable<Categoria>> GetCategorias();
        Task<Categoria> GetCategoria(int id);
    }
}
