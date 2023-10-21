using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginaGrupo.Core.QueryFilters
{
    public class NoticiasQueryFilter
    {
        public int? IdUsuario { get; set; }
        public DateTime? FechaNoticia { get; set; }
        public string? Titulo { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set;}



    }
}
