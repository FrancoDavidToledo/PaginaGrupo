using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Core.Services
{
    public class AvisoPagoService : IAvisoPagoService
    {

        private readonly IUnitOfWork _unitOfWork;

        public AvisoPagoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AvisoPago>> GetAvisosPagosUsuario(int idUsuario)
        {
            var avisoPagos = await _unitOfWork.AvisoPagoRepository.GetAvisosPagosUsuario(idUsuario);

            return avisoPagos;
        }
    }
}
