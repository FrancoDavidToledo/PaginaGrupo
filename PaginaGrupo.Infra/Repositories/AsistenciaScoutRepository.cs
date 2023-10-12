using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class AsistenciaScoutRepository : IAsistenciaScoutRepository
    {

        private readonly PaginaGrupoContext _context;
        public AsistenciaScoutRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos las asistenciasScouts
        public async Task<IEnumerable<AsistenciaScout>> GetAsistenciasScouts()
        {
            var asistenciasScouts = await _context.AsistenciaScouts.ToListAsync();
            
            return asistenciasScouts;
        }

        //devuelve una asistenciaScouts
        public async Task<AsistenciaScout> GetAsistenciaScout(int id)
        {
            var asistenciaScout = await _context.AsistenciaScouts.FirstOrDefaultAsync(x=> x.Id == id);

            return asistenciaScout;
        }

        //carga una asistenciaScouts
        public async Task<AsistenciaScout> InsertarAsistenciaScout(AsistenciaScout asistenciaScout)
        {
            _context.AsistenciaScouts.AddAsync(asistenciaScout);
            await _context.SaveChangesAsync();
            return asistenciaScout;
        }
    }
}
