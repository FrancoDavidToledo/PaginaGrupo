using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.WebApp.Servicios.Contrato
{ 

    public interface IComentarioServicio
    {
        Task<ResponseDTO<ComentarioDto>> Crear(ComentarioDto modelo, string token);
        Task<ResponseDTO<bool>> Eliminar(ComentarioDto modelo, string token);
        Task<ResponseDTO<bool>> Autorizar(ComentarioDto modelo, string token);
        Task<ResponseDTO<IEnumerable<ComentarioDto>>> ObtenerListadoComentarios(int estado, int? idNoticia, string token);
        Task<ApiResponse<IEnumerable<ComentarioPublicoDto>>> ObtenerComentariosActivos(int idNoticia);

    }
}
