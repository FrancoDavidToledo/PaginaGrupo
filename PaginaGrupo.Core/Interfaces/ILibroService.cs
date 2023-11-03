using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.Core.Interfaces
{
    public interface ILibroService
    {
        PagesList<Libro> GetLibros(LibrosQueryFilter filters);
    }
}