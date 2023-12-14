using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.WebApp.Servicios.Contrato
{ 

    public interface IUnidadServicio
    {
        Task<ResponseDTO<IEnumerable<UnidadDto>>> ObtenerListadoUnidades(string token);

    }
}
