using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Exceptions;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.Core.Services
{
    public class NoticiasService : INoticiasService
    {
        //private readonly IRepository<Noticias> _noticiaRepository;
        //private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        //public NoticiasService(IRepository<Noticias> noticiaRepository, IRepository<Usuario> usuarioRepository)
        //{
        //    _noticiaRepository = noticiaRepository;
        //    _usuarioRepository = usuarioRepository;
        //}

        public NoticiasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<Noticias> GetNoticia(int id)
        {
            return await _unitOfWork.NoticiasRepository.GetById(id);
        }

        public PagesList<Noticias> GetNoticias(NoticiasQueryFilter filters)
        {
            var noticias = _unitOfWork.NoticiasRepository.GetAll();
            if (filters.IdUsuario != null)
            {
                noticias = noticias.Where(x => x.IdUsuario == filters.IdUsuario);
            }

            if (filters.FechaNoticia != null)
            {
                noticias = noticias.Where(x => x.FechaNoticia.ToShortDateString() == filters.FechaNoticia?.ToShortDateString());
            }

            if (filters.Titulo != null)
            {
                noticias = noticias.Where(x => x.Titulo.ToLower().Contains(filters.Titulo.ToLower()));
            }

            //la paginacion va despues de los filtros
            var noticiaPaginada = PagesList<Noticias>.Create(noticias, filters.PageNumber, filters.PageSize);


            return noticiaPaginada;
        }

        //Crea una noticia
        public async Task<Noticias> InsertarNoticia(Noticias noticia)
        {
            //aca hacer validaciones
            var user = await _unitOfWork.UsuarioRepository.GetById(noticia.IdUsuario);
            if (user == null)
            {
                throw new BusinessException("El usuario no existe");
            }
            await _unitOfWork.NoticiasRepository.Add(noticia);
            await _unitOfWork.SaveChangesAsync();
            return noticia;
        }

        public async Task<bool> ActualizarNoticia(Noticias noticia)
        {
            //await _unitOfWork.NoticiasRepository.Update(noticia);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BorrarNoticia(int id)
        {
             await _unitOfWork.NoticiasRepository.Delete(id);
            return true;
        }

        public  IEnumerable<Noticias> GetNoticiasEstado(int estado)
        {

            var listadoNoticias =  _unitOfWork.NoticiasRepository.GetNoticiasEstado(estado);
            return listadoNoticias;
        }
    }
}
