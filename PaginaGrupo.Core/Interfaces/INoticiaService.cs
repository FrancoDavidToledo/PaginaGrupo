using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.Core.Interfaces
{
    public interface INoticiasService
    {

        PagesList<Noticias> GetNoticias(NoticiasQueryFilter filters);
        PagesList<Noticias> GetNoticiasActivas(NoticiasQueryFilter filters);
        PagesList<Noticias> GetNoticiasActivasAdjunto(NoticiasQueryFilter filters);
        Task<Noticias> GetNoticia(int id);
        Task<Noticias> GetNoticiaActiva(int id);
        Task<Noticias> InsertarNoticia(Noticias noticia);
        Task<bool> ActualizarNoticia(Noticias noticia);
        Task<bool> BorrarNoticia(int id);
        IEnumerable<Noticias> GetNoticiasEstado(int estado);
        IEnumerable<Noticias> GetNoticiasEstadoFiltrado(int estado, string? filtro);
    }
}