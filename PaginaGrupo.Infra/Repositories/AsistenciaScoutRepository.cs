using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{

    public class AsistenciaScoutRepository : BaseRepository<AsistenciaScout>, IAsistenciaScoutRepository
    {
        public AsistenciaScoutRepository(PaginaGrupoContext context) : base(context) { }

        public IEnumerable<AsistenciaScout> GetByFecha(int idFecha)
        {
            var asistencia = _entities.Where(x => x.IdFecha == idFecha).ToList();

            return asistencia;
        }

        public async Task<AsistenciaScout> GetByFechaScout(int fecha, int idScout)
        {

            return await _entities.FirstOrDefaultAsync(x => x.IdFecha == fecha && x.IdScout == idScout);
         
        }

    }

}
