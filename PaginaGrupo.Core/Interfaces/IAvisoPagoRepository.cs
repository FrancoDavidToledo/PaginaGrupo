using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IAvisoPagoRepository
    {
        Task<IEnumerable<AvisoPago>> GetAvisosPagos();
        Task<AvisoPago> GetAvisoPago(int id);
        Task<AvisoPago> InsertarAvisoPago(AvisoPago avisoPago);
    }
}
