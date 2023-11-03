using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Core.Services
{
    public class AutorService : IAutorService
    {

        private readonly IUnitOfWork _unitOfWork;

        public AutorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Autores> GetAutores()
        {
            var autores =  _unitOfWork.AutoresRepository.GetAll();

            return autores;
        }
    }
}
