using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IAutorService
    {
        IEnumerable<Autores> GetAutores();

    }
}