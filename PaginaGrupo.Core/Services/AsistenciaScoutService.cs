using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Exceptions;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Core.Services
{
    public class AsistenciaScoutService : IAsistenciaScoutService
    {

        private readonly IUnitOfWork _unitOfWork;

        public AsistenciaScoutService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<AsistenciaScout> GetAsistenciasScouts(int idFecha)
        {
            var fechasPorAnio = _unitOfWork.AsistenciaScoutRepository.GetByFecha(idFecha);

            return fechasPorAnio;
        }

        public async Task<AsistenciaScout> GetAsistenciaScout(int id)
        {
            return await _unitOfWork.AsistenciaScoutRepository.GetById(id);
        }

        public async Task<AsistenciaScout> InsertarAsistenciaScout(AsistenciaScout asistenciaScout)
        {
            await _unitOfWork.AsistenciaScoutRepository.Add(asistenciaScout);
            await _unitOfWork.SaveChangesAsync();
            return asistenciaScout;
        }

        public async Task<bool> ActualizarAsistenciaScout(AsistenciaScout asistenciaScout)
        {
            _unitOfWork.AsistenciaScoutRepository.Update(asistenciaScout);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
