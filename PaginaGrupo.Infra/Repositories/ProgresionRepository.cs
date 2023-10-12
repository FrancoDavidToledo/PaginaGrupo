using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class ProgresionRepository : IProgresionRepository
    {

        private readonly PaginaGrupoContext _context;
        public ProgresionRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<Progresion>> GetProgresiones()
        {
            var progresiones =await _context.Progresiones.ToListAsync();
            
            return progresiones;
        }

        //devuelve un usuario
        public async Task<Progresion> GetProgresion(int id)
        {
            var progresion = await _context.Progresiones.FirstOrDefaultAsync(x=> x.Id == id);

            return progresion;
        }

    }
}
