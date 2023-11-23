using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.WebApp.Servicios.Contrato
{ 

    public interface INoticiaServicio
    {

       // Task<ResponseDTO<List<NoticiaDto>>> Lista(string rol,string buscar);
        Task<ResponseDTO<NoticiaAltaDto>> ObtenerById(int id);
        Task<ResponseDTO<NoticiaAltaDto>> Obtener(int id);
        Task<ResponseDTO<NoticiaAltaDto>> Crear(NoticiaAltaDto modelo);
        Task<ResponseDTO<bool>> Editar(NoticiaAltaDto modelo);
        Task<ResponseDTO<IEnumerable<NoticiaDto>>> ObtenerListadoNoticias(int estado);
        Task<ResponseDTO<List<NoticiaAltaDto>>> ObtenerNoticiasActivas(NoticiasQueryFilter filter);

        //Task<ResponseDTO<bool>> Eliminar(int id);

    }
}
