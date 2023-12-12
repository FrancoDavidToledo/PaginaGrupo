using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Exceptions;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Core.Services
{
    public class NombreScoutService : INombreScoutService
    {

        private readonly IUnitOfWork _unitOfWork;

        public NombreScoutService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<NombreScout> GetNombreScout(int idScout)
        {

            var listadoNombres = _unitOfWork.NombreScoutRepository.GetNombresScout(idScout);
            listadoNombres = listadoNombres.OrderBy(x => x.Fecha);

            return listadoNombres;
        }

        public async Task<NombreScout> GetNombreScoutById(int id)
        {
            return await _unitOfWork.NombreScoutRepository.GetById(id);
        }

        public async Task<NombreScout> InsertarNombreScout(NombreScout nombreScout)
        {
            //aca hacer validaciones
            await _unitOfWork.NombreScoutRepository.Add(nombreScout);
            await _unitOfWork.SaveChangesAsync();
            return nombreScout;
        }

        public async Task<bool> ActualizarNombreScout(NombreScout nombreScout)
        {
            _unitOfWork.NombreScoutRepository.Update(nombreScout);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BorrarNombreScout(int id)
        {
            await _unitOfWork.NombreScoutRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
