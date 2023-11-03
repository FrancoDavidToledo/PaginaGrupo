using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.QueryFilters
{
    public class LibrosQueryFilter
    {
        public int? Autor { get; set; }
        public int? Categoria { get; set; }
        public string? Nombre { get; set; }
        public string? Idioma { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

    }
}
