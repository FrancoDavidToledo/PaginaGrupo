using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Exceptions;
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

        public async Task<Adjuntos> InsertarAdjunto(Adjuntos adjunto)
        {
            //aca hacer validaciones
            if (adjunto.Adjunto == null)
            {
                throw new BusinessException("Error al guardar el adjunto.");
            }
            else
            {
                

                await _unitOfWork.AdjuntosRepository.Add(adjunto);
                await _unitOfWork.SaveChangesAsync();
                return adjunto;
            }
        }


    }
}
