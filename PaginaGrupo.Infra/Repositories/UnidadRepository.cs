using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class UnidadRepository : IUnidadRepository
    {

        private readonly PaginaGrupoContext _context;
        public UnidadRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<Unidad>> GetUnidades()
        {
            var unidades =await _context.Unidades.ToListAsync();
            
            return unidades;
        }

        //devuelve un usuario
        public async Task<Unidad> GetUnidad(string codigo)
        {
            var unidad = await _context.Unidades.FirstOrDefaultAsync(x=> x.Codigo == codigo);

            return unidad;
        }


    }
}
