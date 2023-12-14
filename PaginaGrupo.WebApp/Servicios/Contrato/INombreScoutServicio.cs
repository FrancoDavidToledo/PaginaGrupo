using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.WebApp.Servicios.Contrato
{ 

    public interface INombreScoutServicio
    {
        Task<ResponseDTO<NombreScoutDto>> ObtenerById(int id, string token);
        Task<ResponseDTO<NombreScoutDto>> Crear(NombreScoutDto modelo, string token);
        Task<ResponseDTO<bool>> Editar(NombreScoutDto modelo, string token);
        Task<ResponseDTO<IEnumerable<NombreScoutDto>>> ObtenerListadoNombres(int idScout, string token);
        Task<ResponseDTO<bool>> Eliminar(int id, string token);

    }
}
