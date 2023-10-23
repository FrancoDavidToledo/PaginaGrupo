using PaginaGrupo.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginaGrupo.Infra.Interfaces
{
    public interface IUriService
    {
        Uri GetNoticiaPaginationUri(NoticiasQueryFilter filter, string actionUrl);
    }
}
