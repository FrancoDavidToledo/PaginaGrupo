using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Core.Services
{
    public class CategoriaService : ICategoriaService
    {

        private readonly IUnitOfWork _unitOfWork;

        public CategoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    
        public   IEnumerable<Categoria> GetCategorias()
        {
            var categorias =  _unitOfWork.CategoriasRepository.GetAll();

            return categorias;
        }

    }
}
