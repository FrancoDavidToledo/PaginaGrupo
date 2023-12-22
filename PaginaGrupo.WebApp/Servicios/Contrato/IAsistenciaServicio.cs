using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.WebApp.Servicios.Contrato
{

    public interface IAsistenciaServicio
    {
        Task<ResponseDTO<char>> ObtenerAsistencia(int fecha, int idScout, string token);

        Task<ResponseDTO<IEnumerable<AsistenciaView>>> ObtenerAsistenciaFiltrada(string codigo, char estado, short anio, string token);
        Task<ResponseDTO<IEnumerable<ScoutAsistenciaDto>>> ObtenerListadoScouts(string? codigo, char? estado, int idFecha, string token);
    }
}
