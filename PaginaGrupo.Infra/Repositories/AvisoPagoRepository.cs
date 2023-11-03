using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;

namespace PaginaGrupo.Infra.Repositories
{
    public class AvisoPagoRepository : BaseRepository<AvisoPago>, IAvisoPagoRepository
    {

        public AvisoPagoRepository(PaginaGrupoContext context) : base(context) { }

        //devuelve todos los usuarios
        public async Task<IEnumerable<AvisoPago>> GetAvisosPagosUsuario(int idUsuario)
        {
            var avisosPagos = await _entities.Where(x => x.IdUsuario == idUsuario).ToListAsync();

            return avisosPagos;
        }

    }
}
