using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;

namespace PaginaGrupo.Core.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetCategorias();

    }
}