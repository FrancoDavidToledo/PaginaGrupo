using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class TipoNombreRepository : ITipoNombreRepository
    {

        private readonly PaginaGrupoContext _context;
        public TipoNombreRepository(PaginaGrupoContext context)
        {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<TipoNombre>> GetTiposNombres()
        {
            var tipoNombres = await _context.TipoNombres.ToListAsync();

            return tipoNombres;
        }

        //devuelve un usuario
        public async Task<TipoNombre> GetTipoNombre(int id)
        {
            var tipoNombre = await _context.TipoNombres.FirstOrDefaultAsync(x => x.Id == id);

            return tipoNombre;
        }


    }
}
