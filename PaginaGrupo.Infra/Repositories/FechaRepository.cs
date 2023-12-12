using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class FechaRepository : BaseRepository<Fechas>, IFechaRepository
    {
        public FechaRepository(PaginaGrupoContext context) : base(context) { }


        public IEnumerable<Fechas> GetByAnio(int anio)
        {
            var fechas = _entities.Where(x => x.AnioScout == anio).ToList();

            return fechas;
        }
    }
}
