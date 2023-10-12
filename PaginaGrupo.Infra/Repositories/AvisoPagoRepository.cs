using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class AvisoPagoRepository : IAvisoPagoRepository
    {

        private readonly PaginaGrupoContext _context;
        public AvisoPagoRepository(PaginaGrupoContext context) {

            _context = context;
        }

        //devuelve todos los usuarios
        public async Task<IEnumerable<AvisoPago>> GetAvisosPagos()
        {
            var avisosPagos =await _context.AvisoPagos.ToListAsync();
            
            return avisosPagos;
        }

        //devuelve un usuario
        public async Task<AvisoPago> GetAvisoPago(int id)
        {
            var avisoPago = await _context.AvisoPagos.FirstOrDefaultAsync(x=> x.Id == id);

            return avisoPago;
        }

        //Crea un usuario
        public async Task<AvisoPago> InsertarAvisoPago(AvisoPago avisoPago)
        {
            _context.AvisoPagos.AddAsync(avisoPago);
            await _context.SaveChangesAsync();
            return avisoPago;
        }
    }
}
