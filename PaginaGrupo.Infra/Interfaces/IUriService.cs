using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.Infra.Interfaces
{
    public interface IUriService
    {
        Uri GetNoticiaPaginationUri(NoticiasQueryFilter filter, string actionUrl);
    }
}
