using PaginaGrupo.Core.QueryFilters;
using PaginaGrupo.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginaGrupo.Infra.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService (string baseUri)
        {
            _baseUri = baseUri;
        }
        public Uri GetNoticiaPaginationUri (NoticiasQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{ _baseUri}{ actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
