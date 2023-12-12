using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.QueryFilters;
using PaginaGrupo.Api.Responses;

namespace PaginaGrupo.WebApp.Servicios.Contrato
{ 

    public interface IAdjuntoServicio
    {

        Task<ResponseDTO<string>> InsertarAdjunto(Adjuntos adjunto, string token);

        Task<ApiResponse<IEnumerable<AdjuntosDto>>> GetAdjuntosNoticia(int idNoticia);
        Task<bool> EliminarAdjuntos(int idAdjunto, string token);
    }
}
