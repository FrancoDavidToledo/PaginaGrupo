using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.WebApp.Servicios.Contrato
{ 

    public interface INoticiaServicio
    {

       // Task<ResponseDTO<List<NoticiaDto>>> Lista(string rol,string buscar);
        Task<ResponseDTO<NoticiaAltaDto>> ObtenerById(int id,string token);
        Task<ResponseDTO<NoticiaAltaDto>> Obtener(int id);
        Task<ResponseDTO<NoticiaAltaDto>> Crear(NoticiaAltaDto modelo, string token);
        Task<ResponseDTO<bool>> Editar(NoticiaAltaDto modelo, string token);
        Task<ResponseDTO<IEnumerable<NoticiaDto>>> ObtenerListadoNoticias(int estado, string token);
        Task<ApiResponse<IEnumerable<NoticiaActivaImagenDto>>> ObtenerNoticiasActivas(NoticiasQueryFilter filters);
        Task<ResponseDTO<bool>> Eliminar(NoticiaDto modelo, string token);

        Task<ResponseDTO<bool>> Publicar(NoticiaDto modelo, string token);

        Task<ResponseDTO<bool>> Autorizar(NoticiaDto modelo, string token);
        //Task<ResponseDTO<bool>> Eliminar(int id);

    }
}
