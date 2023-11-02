using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Core.Services
{
    public class AdjuntoService : IAdjuntoService
    {

        private readonly IUnitOfWork _unitOfWork;

        public AdjuntoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Adjuntos>> GetAdjuntosNoticia(int idNoticia)
        {
            var Adjuntos = await _unitOfWork.AdjuntosRepository.GetAdjuntosNoticia(idNoticia);

            return Adjuntos;
        }

    }
}
