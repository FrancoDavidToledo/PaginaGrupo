using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.WebApp.Servicios.Contrato
{ 

    public interface ITipoNombreServicio
    { 
        Task<ResponseDTO<IEnumerable<TipoNombreDto>>> ObtenerTipoNombres(string token);
    }
}
