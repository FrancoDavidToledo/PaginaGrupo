using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Core.Services
{
    public class ComentarioService : IComentarioService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ComentarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Comentario>> GetComentariosNoticiasActivas(int idNoticia)
        {
            var comentarios = await _unitOfWork.ComentarioRepository.GetComentariosNoticiasActivas(idNoticia);

            return comentarios;
        }

        public async Task<IEnumerable<Comentario>> GetComentariosEstado(int estado)
        {
            var comentarios = await _unitOfWork.ComentarioRepository.GetComentariosEstado(estado);

            return comentarios;
        }
    }
}
