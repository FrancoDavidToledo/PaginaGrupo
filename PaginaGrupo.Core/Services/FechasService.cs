using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Exceptions;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Core.Services
{
    public class FechasService : IFechasService
    {

        private readonly IUnitOfWork _unitOfWork;

        public FechasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Fechas> GetFechas(int anio)
        {
            var fechasPorAnio = _unitOfWork.FechaRepository.GetByAnio(anio);

            fechasPorAnio = fechasPorAnio.OrderBy(x => x.Fecha);
            return fechasPorAnio;
        }


        //public async Task<IEnumerable<Fechas>> GetFechassNoticiasActivas(int idNoticia)
        //{
        //    var Fechass = await _unitOfWork.FechasRepository.GetFechassNoticiasActivas(idNoticia);

        //    Fechass = Fechass.OrderByDescending(x => x.Id);

        //    return Fechass;
        //}

        //public async Task<IEnumerable<Fechas>> GetFechassEstado(int estado, int? idNoticia)
        //{
        //    var Fechass = await _unitOfWork.FechasRepository.GetFechassEstado(estado);

        //    if (idNoticia != null)
        //    {
        //        Fechass = Fechass.Where(x => x.IdNoticia == idNoticia);
        //    }

        //    Fechass = Fechass.OrderByDescending(x => x.Id);

        //    return Fechass;
        //}

        ////Crea una noticia
        //public async Task<Fechas> InsertarFechas(Fechas Fechas)
        //{
        //    //aca hacer validaciones
        //    var user = await _unitOfWork.UsuarioRepository.GetById(Fechas.IdUsuario);
        //    if (user == null)
        //    {
        //        throw new BusinessException("El usuario no existe");
        //    }
        //    Fechas.Estado = 1;
        //    await _unitOfWork.FechaRepository.Add(Fechas);
        //    await _unitOfWork.SaveChangesAsync();
        //    return Fechas;
        //}

        //public async Task<bool> ActualizarFechas(Fechas Fechas)
        //{
        //    _unitOfWork.FechaRepository.Update(Fechas);
        //    await _unitOfWork.SaveChangesAsync();
        //    return true;
        //}

    }
}
