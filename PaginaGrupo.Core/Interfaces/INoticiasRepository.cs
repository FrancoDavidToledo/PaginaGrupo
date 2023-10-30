using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface INoticiasRepository : IRepository<Noticias>
    {
        IEnumerable<Noticias> GetNoticiasEstado(int estado);
    }
}
