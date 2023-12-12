using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface INoticiasRepository : IRepository<Noticias>
    {
        IEnumerable<Noticias> GetNoticiasEstado(int estado);
        IEnumerable<Noticias> GetNoticiasEstadoFiltrado(int estado, string? filtro);
    }
}
