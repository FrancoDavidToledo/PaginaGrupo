using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Core.Services
{
    public class NoticiasService : INoticiasService
    {
        private readonly INoticiasRepository _noticiaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public NoticiasService(INoticiasRepository noticiaRepository, IUsuarioRepository usuarioRepository)
        {
            _noticiaRepository = noticiaRepository;
            _usuarioRepository = usuarioRepository;
        }


        public async Task<Noticias> GetNoticia(int id)
        {
            return await _noticiaRepository.GetNoticia(id);
        }

        public async Task<IEnumerable<Noticias>> GetNoticias()
        {
            return await _noticiaRepository.GetNoticias();
        }

        //Crea una noticia
        public async Task<Noticias> InsertarNoticia(Noticias noticia)
        {
            //aca hacer validaciones
            var user = await _usuarioRepository.GetUsuario(noticia.IdUsuario);
            if (user == null)
            {
                throw new Exception("El usuario no existe");
            }
            return await _noticiaRepository.InsertarNoticia(noticia);
        }

        public async Task<bool> ActualizarNoticia(Noticias noticia)
        {
           return await _noticiaRepository.ActualizarNoticia(noticia);
        }

        public async Task<bool> BorrarNoticia(int id)
        {
            return await _noticiaRepository.BorrarNoticia(id);
        }

    }
}
