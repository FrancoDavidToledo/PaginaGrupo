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
            else if(await VerificarDuplicado(adjunto))
            {
                //TODO manejar el caso en el que el adjunto esté duplicado.
                return adjunto;
            }
            else
            {
                await _unitOfWork.AdjuntosRepository.Add(adjunto);
                await _unitOfWork.SaveChangesAsync();
                return adjunto;
            }
        }
        //public async Task<Adjuntos> InsertarAdjuntoImagen(Adjuntos adjunto)
        //{
        //    //aca hacer validaciones
        //    if (adjunto.Adjunto == null && adjunto.Data == null)
        //    {
        //        throw new BusinessException("Error al guardar el adjunto.");
        //    }
        //    else
        //    {


        //        await _unitOfWork.AdjuntosRepository.Add(adjunto);
        //        await _unitOfWork.SaveChangesAsync();
        //        return adjunto;
        //    }
        //}


        public async Task<string> GetAdjuntoPrincipal(int idNoticia)
        {
            var Adjuntos = await _unitOfWork.AdjuntosRepository.GetAdjunto(idNoticia);

            if (Adjuntos != null)
            {
                return Adjuntos.Adjunto;
            }
            else
            {
                return "https://lh3.googleusercontent.com/u/1/drive-viewer/AK7aPaCTmP4yyIZ7dIIgb3pHkggoxeI6FkLbo90kbGk7pax0ddNdV3juBIMKOnQTsFaNVvCsGsF8GNb6iu3l00eZDdQrrAN0=w1600-h773";
            }
        }

        public async Task<bool> EliminarAdjunto(int id)
        {

            await _unitOfWork.AdjuntosRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;

        }

        private async Task<bool> VerificarDuplicado(Adjuntos adjunto)
        {
            //Verifica si el adjunto ya existe para la noticia. Si existe devuelve true, si no false.

            var adjuntos = await _unitOfWork.AdjuntosRepository.GetAdjuntosNoticia(adjunto.IdNoticia);
            if (adjuntos.Any())
            {
                foreach(var item in adjuntos)
                {
                    if(item.Adjunto.ToLower().Trim()==adjunto.Adjunto.ToLower().Trim())
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
