using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class AutorRepository : BaseRepository<Autores>, IAutoresRepository
    {

        public AutorRepository(PaginaGrupoContext context) : base(context) { }

       
    }
}
