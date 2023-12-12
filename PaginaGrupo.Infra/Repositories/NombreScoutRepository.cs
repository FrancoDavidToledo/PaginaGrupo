using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class NombreScoutRepository : BaseRepository<NombreScout>, INombreScoutRepository
    {
        public NombreScoutRepository(PaginaGrupoContext context) : base(context) { }

        public IEnumerable<NombreScout> GetNombresScout(int idScout)
        {
            var nombreScout = _entities.Where(x => x.IdScout == idScout).ToList();

            return nombreScout;
        }

    }
}
