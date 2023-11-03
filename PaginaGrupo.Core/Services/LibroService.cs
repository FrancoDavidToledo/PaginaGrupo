using Microsoft.Extensions.Options;
using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Exceptions;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.Core.Services
{
    public class LibroService : ILibroService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly PaginationOptions _paginationOptions;
        public LibroService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PagesList<Libro> GetLibros(LibrosQueryFilter filters)
        {
            var Libro = _unitOfWork.LibroRepository.GetAll();

            //paginado
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            if (filters.Autor != null)
            {
               // Libro = Libro.Where(x => x.LibroAutor. == filters.Autor);
            }

            if (filters.Categoria != null)
            {
                //Libro = Libro.Where(x => x.LibroCategoria == filters.Categoria);
            }

            if (filters.Nombre != null)
            {
                Libro = Libro.Where(x => x.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
            }

            if (filters.Idioma != null)
            {
                Libro = Libro.Where(x => x.Idioma.ToLower() == filters.Idioma.ToLower());
            }

            //la paginacion va despues de los filtros
            var noticiaPaginada = PagesList<Libro>.Create(Libro, filters.PageNumber, filters.PageSize);


            return noticiaPaginada;
        }

    }
}
