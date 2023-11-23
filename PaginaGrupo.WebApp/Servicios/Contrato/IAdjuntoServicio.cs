using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.WebApp.Servicios.Contrato
{ 

    public interface IAdjuntoServicio
    {

        Task<ResponseDTO<string>> InsertarAdjunto(Adjuntos adjunto);
    }
}
