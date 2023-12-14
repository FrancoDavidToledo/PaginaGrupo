using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.WebApp.Servicios.Contrato
{ 

    public interface IScoutServicio
    {
        Task<ResponseDTO<ScoutDto>> ObtenerById(int id,string token);
        Task<ResponseDTO<ScoutNombreDto>> ObtenerScoutNombre(int id, string token);
        Task<ResponseDTO<ScoutDto>> Crear(ScoutDto modelo, string token);
        Task<ResponseDTO<bool>> Editar(ScoutDto modelo, string token);
        Task<ResponseDTO<IEnumerable<ScoutDto>>> ObtenerListadoScouts(string? codigo, char? estado, string token);
        Task<ResponseDTO<bool>> Eliminar(int idScout, string token);
        Task<ResponseDTO<bool>> Rehabilitar(int idScout, string token);
        Task<ResponseDTO<bool>> Migrar(ScoutDto modelo, string token);

    }
}
