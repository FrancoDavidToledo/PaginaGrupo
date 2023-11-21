using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.WebApp.Servicios.Contrato
{ 

    public interface INoticiaServicio
    {

       // Task<ResponseDTO<List<NoticiaDto>>> Lista(string rol,string buscar);
        Task<ResponseDTO<NoticiaAltaDto>> Obtener(int id);
        Task<ResponseDTO<NoticiaAltaDto>> Crear(NoticiaAltaDto modelo);
        Task<ResponseDTO<bool>> Editar(NoticiaAltaDto modelo);
        //Task<ResponseDTO<bool>> Eliminar(int id);

    }
}
