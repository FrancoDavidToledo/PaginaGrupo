using Microsoft.Extensions.Options;
using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
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

        private readonly PaginationOptions _paginationOptions;

        public NoticiasService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }



        public async Task<Noticias> GetNoticia(int id)
        {
            return await _unitOfWork.NoticiasRepository.GetById(id);
        }

        public async Task<Noticias> GetNoticiaActiva(int id)
        {
            var noticia = await _unitOfWork.NoticiasRepository.GetById(id);


            if (noticia == null)
            {
                return null;
            }

            if (noticia.Estado == Convert.ToInt16(EstadoNoticias.Autorizado))
            {
                return noticia;
            }
            else
            {
                return null;
            }

        }

        public PagesList<Noticias> GetNoticias(NoticiasQueryFilter filters)
        {
            var noticias = _unitOfWork.NoticiasRepository.GetAll();

            //paginado
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

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


        public PagesList<Noticias> GetNoticiasActivas(NoticiasQueryFilter filters)
        {
            var noticias = _unitOfWork.NoticiasRepository.GetNoticiasEstado(Convert.ToInt32(EstadoNoticias.Autorizado));

            //paginado
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

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
            noticias = noticias.OrderByDescending(x => x.FechaNoticia);

            //la paginacion va despues de los filtros
            var noticiaPaginada = PagesList<Noticias>.Create(noticias, filters.PageNumber, filters.PageSize);


            return noticiaPaginada;
        }


        public PagesList<Noticias> GetNoticiasActivasAdjunto(NoticiasQueryFilter filters)
        {
            var noticias = _unitOfWork.NoticiasRepository.GetNoticiasEstado(Convert.ToInt32(EstadoNoticias.Autorizado));

            //paginado
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

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
            noticias = noticias.OrderByDescending(x => x.FechaNoticia);

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
            noticia.Estado = 1;
            await _unitOfWork.NoticiasRepository.Add(noticia);
            await _unitOfWork.SaveChangesAsync();
            return noticia;
        }

        public async Task<bool> ActualizarNoticia(Noticias noticia)
        {
             _unitOfWork.NoticiasRepository.Update(noticia);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BorrarNoticia(int id)
        {
            await _unitOfWork.NoticiasRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Noticias> GetNoticiasEstado(int estado)
        {

            var listadoNoticias = _unitOfWork.NoticiasRepository.GetNoticiasEstado(estado);
            return listadoNoticias;
        }
    }
}
