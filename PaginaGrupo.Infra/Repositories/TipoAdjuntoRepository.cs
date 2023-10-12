using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class TipoAdjuntoRepository : ITipoAdjuntoRepository
    {

        private readonly PaginaGrupoContext _context;
        public TipoAdjuntoRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<TipoAdjunto>> GetTiposAdjuntos()
        {
            var tiposAdjuntos =await _context.TipoAdjuntos.ToListAsync();
            
            return tiposAdjuntos;
        }

        //devuelve un usuario
        public async Task<TipoAdjunto> GetTipoAdjunto(int id)
        {
            var tipoAdjunto = await _context.TipoAdjuntos.FirstOrDefaultAsync(x=> x.Id == id);

            return tipoAdjunto;
        }


    }
}
