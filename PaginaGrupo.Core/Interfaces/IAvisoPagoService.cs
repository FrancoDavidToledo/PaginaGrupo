using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IAvisoPagoService
    {
        Task<IEnumerable<AvisoPago>> GetAvisosPagosUsuario(int idUsuario);
    }
}