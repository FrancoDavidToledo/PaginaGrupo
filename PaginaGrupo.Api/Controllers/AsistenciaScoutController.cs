using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.Services;
using PaginaGrupo.Infra.Repositories;
using System.Threading;

namespace PaginaGrupo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciaScoutController : Controller
    {
        private readonly IAsistenciaScoutService _asistenciaScoutService;
        private readonly IAsistenciaViewRepository _asistenciaViewRepository;
        private readonly IScoutService _scoutService;
        private readonly IFechasService _fechasService;
        private readonly IMapper _mapper;
        public AsistenciaScoutController(IAsistenciaScoutService asistenciaScoutService, IMapper mapper, IScoutService scoutService, IFechasService fechasService, IAsistenciaViewRepository asistenciaViewRepository)
        {
            _asistenciaScoutService = asistenciaScoutService;
            _mapper = mapper;
            _scoutService = scoutService;
            _fechasService = fechasService;
            _asistenciaViewRepository = asistenciaViewRepository;
        }
        [HttpGet("GetAsistenciasScouts/{idFecha}")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]

        public async Task<IActionResult> GetAsistenciasScouts(int idFecha)
        {

            var asistenciaScout = _asistenciaScoutService.GetAsistenciasScouts(idFecha);
            var asistenciaScoutDto = _mapper.Map<IEnumerable<AsistenciaScoutDto>>(asistenciaScout);

            var response = new ResponseDTO<IEnumerable<AsistenciaScoutDto>>();

            if (asistenciaScoutDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = asistenciaScoutDto;
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al obtener las asistencias";
            }

            return Ok(response);
        }

        [HttpGet("GetAsistenciaScout/{id}")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]

        public async Task<IActionResult> GetAsistenciaScout(int id)
        {
            var asistenciaScout = await _asistenciaScoutService.GetAsistenciaScout(id);
            var asistenciaScoutDto = _mapper.Map<AsistenciaScoutDto>(asistenciaScout);
            return Ok(asistenciaScoutDto);

        }

        [HttpPost("InsertarAsistenciaScout")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]

        public async Task<IActionResult> InsertarAsistenciaScout(AsistenciaScoutDto asistenciaScoutDto)
        {


            var asistenciaScout = _mapper.Map<AsistenciaScout>(asistenciaScoutDto);
            await _asistenciaScoutService.InsertarAsistenciaScout(asistenciaScout);

            return Ok(asistenciaScout);

        }



       [HttpGet("GetFinal")]
       //[Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]

       public async Task<IActionResult> GetFinal([FromQuery] int fecha, int idScout)
       {

           var asistenciaScout =  _asistenciaScoutService.GetAsistenciaScoutFecha(fecha, idScout);
           var asistenciaScoutDto = _mapper.Map<AsistenciaScoutDto>(asistenciaScout);

           var response = new ResponseDTO<char>();

           if (asistenciaScoutDto != null)
           {
               response.EsCorrecto = true;
               response.Resultado = (char)asistenciaScoutDto.Asistencia;
           }
           else
           {
               response.EsCorrecto = false;
               response.Mensaje = "Error al obtener las asistencias";
           }

           return Ok(response);

        }


        //[HttpGet("GetUnidadFecha")]
        ////[Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]

        //public async Task<IActionResult> GetUnidadFecha([FromQuery] string? codigo, char? estado, int anio)
        //{

        //    List<AsistenciaScoutDto> listaAsistencia = new List<AsistenciaScoutDto>();
        //    var scout = _scoutService.GetScouts(codigo, estado);
        //    var scoutDto = _mapper.Map<IEnumerable<ScoutDto>>(scout);

        //    var fecha = _fechasService.GetFechas(anio);
        //    var fechaDto = _mapper.Map<IEnumerable<FechaDto>>(fecha);


        //    foreach (var row in scoutDto)
        //    {

        //        foreach (var rowFecha in fechaDto)
        //        {
        //            var asistenciaScout = await _asistenciaScoutService.GetAsistenciaScoutFecha(rowFecha.Id, row.Id);
        //            var asistenciaScoutDto = _mapper.Map<AsistenciaScoutDto>(asistenciaScout);
        //            if (asistenciaScout != null) { 
        //            listaAsistencia.Add(new AsistenciaScoutDto()
        //            {
        //                Id = asistenciaScoutDto.Id,
        //                IdScout = asistenciaScoutDto.IdScout,
        //                IdFecha = asistenciaScoutDto.IdFecha,
        //                Asistencia = asistenciaScoutDto.Asistencia,
        //                CodigoUnidad = asistenciaScoutDto.CodigoUnidad
        //            });
        //            }
        //            else
        //            {
        //                listaAsistencia.Add(new AsistenciaScoutDto()
        //                {
        //                    IdScout = row.Id,
        //                    IdFecha = rowFecha.Id,
        //                    Asistencia = null,
        //                    CodigoUnidad = null
        //                });
        //            }
        //        }
        //    }


        //    var response = new ResponseDTO<IEnumerable<AsistenciaScoutDto>>();

        //    if (listaAsistencia != null)
        //    {
        //        response.EsCorrecto = true;
        //        response.Resultado = listaAsistencia;
        //    }
        //    else
        //    {
        //        response.EsCorrecto = false;
        //        response.Mensaje = "Error al obtener las asistencias";
        //    }

        //    return Ok(response);

        //}


        [HttpGet("GetUnidadFechaOk")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]

        public async Task<IActionResult> GetUnidadFechaOk([FromQuery] string codigo, char estado, short anio)
        {

            var asistenciaScout =  _asistenciaViewRepository.GetAsistenciasUnidad(codigo, estado, anio);
  

            var response = new ResponseDTO<IEnumerable<AsistenciaView>>();
            
            if (asistenciaScout != null)
            {
                response.EsCorrecto = true;
                response.Resultado = asistenciaScout;
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al obtener las asistencias";
            }
            
            return Ok(response);

        }

        //lo siguiente es el nombre del servicio
        [HttpGet("GetScouts")]

        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> GetScouts([FromQuery] string? codigo, char? estado, int idFecha)
        {

            var scout = _scoutService.GetScouts(codigo, estado);
            var scoutDto = _mapper.Map<IEnumerable<ScoutAsistenciaDto>>(scout);

            foreach (var i in scoutDto)
            {
                var asistenciaIndividual = await _asistenciaScoutService.GetAsistenciaScoutFecha(idFecha, i.Id);

                if (asistenciaIndividual != null)
                {
                    i.Asistencia = asistenciaIndividual.Asistencia;
                }

            }
            var response = new ResponseDTO<IEnumerable<ScoutAsistenciaDto>>();

            if (scoutDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = scoutDto;
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al obtener a los scouts";
            }

            return Ok(response);
        }
    }
}
