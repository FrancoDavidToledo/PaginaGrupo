using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Exceptions;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.QueryFilters;

namespace PaginaGrupo.Core.Services
{
    public class ScoutService : IScoutService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ScoutService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Scout> GetScout(int id)
        {
            return await _unitOfWork.ScoutRepository.GetById(id);
        }

        //public async Task<IEnumerable<Scout>> GetScoutsNoticiasActivas(int idNoticia)
        //{
        //    var Scouts = await _unitOfWork.ScoutRepository.GetScoutsNoticiasActivas(idNoticia);

        //    Scouts = Scouts.OrderByDescending(x => x.Id);

        //    return Scouts;
        //}

        //public async Task<IEnumerable<Scout>> GetScoutsEstado(int estado, int? idNoticia)
        //{
        //    var Scouts = await _unitOfWork.ScoutRepository.GetScoutsEstado(estado);
            
        //    if (idNoticia != null)
        //    {
        //        Scouts = Scouts.Where(x => x.IdNoticia == idNoticia);
        //    }

        //    Scouts = Scouts.OrderByDescending(x => x.Id);

        //    return Scouts;
        //}

        //Crea una noticia
        public async Task<Scout> InsertarScout(Scout scout)
        {
            scout.Estado = Convert.ToChar("A");
            await _unitOfWork.ScoutRepository.Add(scout);
            await _unitOfWork.SaveChangesAsync();
            return scout;
        }

        public async Task<bool> ActualizarScout(Scout Scout)
        {
            _unitOfWork.ScoutRepository.Update(Scout);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }


        public IEnumerable<Scout> GetScouts(string? codigo, char? estado)
        {
            var scouts = _unitOfWork.ScoutRepository.GetAll();

            if (codigo != null)
            {
                scouts = scouts.Where(x => x.CodigoUnidad == codigo);
            }

            if (estado != null)
            {
                scouts = scouts.Where(x => x.Estado == estado);
            }

            scouts = scouts.OrderBy(x => x.Apellido);
            return scouts;
        }

    }
}
