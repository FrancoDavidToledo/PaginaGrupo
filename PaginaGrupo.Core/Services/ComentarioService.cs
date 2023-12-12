using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Exceptions;
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

        public async Task<Comentario> GetComentario(int id)
        {
            return await _unitOfWork.ComentarioRepository.GetById(id);
        }

        public async Task<IEnumerable<Comentario>> GetComentariosNoticiasActivas(int idNoticia)
        {
            var comentarios = await _unitOfWork.ComentarioRepository.GetComentariosNoticiasActivas(idNoticia);

            comentarios = comentarios.OrderByDescending(x => x.Id);

            return comentarios;
        }

        public async Task<IEnumerable<Comentario>> GetComentariosEstado(int estado, int? idNoticia)
        {
            var comentarios = await _unitOfWork.ComentarioRepository.GetComentariosEstado(estado);
            
            if (idNoticia != null)
            {
                comentarios = comentarios.Where(x => x.IdNoticia == idNoticia);
            }

            comentarios = comentarios.OrderByDescending(x => x.Id);

            return comentarios;
        }

        public async Task<IEnumerable<Comentario>> GetComentariosEstadoFiltrado(int estado,string filtro)
        {
            var comentarios = await _unitOfWork.ComentarioRepository.GetComentariosEstadoFiltrado(estado,filtro);

            comentarios = comentarios.OrderByDescending(x => x.Id);

            return comentarios;
        }

        //Crea una noticia
        public async Task<Comentario> InsertarComentario(Comentario comentario)
        {
            //aca hacer validaciones
            var user = await _unitOfWork.UsuarioRepository.GetById(comentario.IdUsuario);
            if (user == null)
            {
                throw new BusinessException("El usuario no existe");
            }
            comentario.Estado = 1;
            await _unitOfWork.ComentarioRepository.Add(comentario);
            await _unitOfWork.SaveChangesAsync();
            return comentario;
        }

        public async Task<bool> ActualizarComentario(Comentario comentario)
        {
            _unitOfWork.ComentarioRepository.Update(comentario);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
