using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.Services;
using System.Collections.Generic;
using System.Net;

namespace PaginaGrupo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoutController : Controller
    {
        private readonly IScoutService _scoutService;
        private readonly IMapper _mapper;
        public ScoutController(IScoutService scoutService, IMapper mapper)
        {
            _scoutService = scoutService;
            _mapper = mapper;
        }

        //lo siguiente es para documentar
        /// <summary>
        /// Muestra todos los scouts, requiere rol Dirigente, Admin u Hormiga
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDTO<IEnumerable<ScoutDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo anterior era para documentar

        //lo siguiente es el nombre del servicio
        [HttpGet("GetScouts")]

        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public IActionResult GetScouts([FromQuery] string? codigo, char? estado)
        {

            var scout = _scoutService.GetScouts(codigo, estado);
            var scoutDto = _mapper.Map<IEnumerable<ScoutDto>>(scout);

            var response = new ResponseDTO<IEnumerable<ScoutDto>>();

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

        //lo siguiente es para documentar
        /// <summary>
        /// Muestra a un scout, requiere rol Dirigente, Admin u Hormiga
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDTO<ScoutDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo anterior era para documentar

        //lo siguiente es el nombre del servicio
        [HttpGet("GetScout/{id}")]

        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> GetScout(int id)
        {
            var scout = await _scoutService.GetScout(id);
            var scoutDto = _mapper.Map<ScoutDto>(scout);
            var response = new ResponseDTO<ScoutDto>();

            if (scoutDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = scoutDto;
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al obtener al scout";
            }

            return Ok(response);
        }

        //lo siguiente es el nombre del servicio
        [HttpGet("GetScoutNombre/{id}")]

        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> GetScoutNombre(int id)
        {
            var scout = await _scoutService.GetScout(id);
            var scoutDto = _mapper.Map<ScoutNombreDto>(scout);
            var response = new ResponseDTO<ScoutNombreDto>();

            if (scoutDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = scoutDto;
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al obtener al scout";
            }

            return Ok(response);
        }


        //lo siguiente es para documentar
        /// <summary>
        /// Inserta un scout, requiere rol Dirigente, Admin u Hormiga
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDTO<ScoutDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo anterior era para documentar

        //lo siguiente es el nombre del servicio
        [HttpPost("InsertarScout")]

        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> InsertarScout([FromQuery] ScoutDto scoutDto)
        {


            var scout = _mapper.Map<Scout>(scoutDto);
            scout = await _scoutService.InsertarScout(scout);
            scoutDto = _mapper.Map<ScoutDto>(scout);

            var response = new ResponseDTO<ScoutDto>();

            if (scoutDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = scoutDto;
                response.Mensaje = "Scout Cargado con exito";
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al cargar al scout";
            }

            return Ok(response);

        }

        [HttpPut("ActualizarScout")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> ActualizarScout([FromQuery] ScoutDto scoutDto)
        {

            var scout = await _scoutService.GetScout(scoutDto.Id);
            //aca actualizar todo lo que quieras
            scout.Nombre = scoutDto.Nombre;
            scout.Apellido = scoutDto.Apellido;
            scout.Dni = scoutDto.Dni;
            scout.Correo = scoutDto.Correo;
            scout.FechaNacimiento = scoutDto.FechaNacimiento;
            scout.Telefono = scoutDto.Telefono;
            scout.Sexo = scoutDto.Sexo;
            scout.Direccion = scoutDto.Direccion;

            var result = await _scoutService.ActualizarScout(scout);
            var response = new ResponseDTO<string>();

            if (result)
            {
                response.EsCorrecto = true;
                response.Mensaje = "Scout editado con exito";
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al editar al Scout";
            }

            return Ok(response);

        }

        [HttpPut("ActualizarEstadoScout")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> ActualizarEstadoScout([FromQuery] ScoutEstadoDto scoutEstadoDto)
        {
            var scout = await _scoutService.GetScout(scoutEstadoDto.Id);
            //aca actualizar todo lo que quieras
            scout.Estado = scoutEstadoDto.Estado;
            var result = await _scoutService.ActualizarScout(scout);
            var response = new ResponseDTO<string>();

            if (result)
            {
                response.EsCorrecto = true;
                response.Mensaje = "Scout actualizado con exito";
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al actualizar al Scout";
            }

            return Ok(response);

        }

        [HttpPut("MigrarScout")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> MigrarScout([FromQuery] ScoutUnidadDto scoutUnidadDto)
        {
            var scout = await _scoutService.GetScout(scoutUnidadDto.Id);
            //aca actualizar todo lo que quieras
            scout.CodigoUnidad = scoutUnidadDto.CodigoUnidad;
            var result = await _scoutService.ActualizarScout(scout);
            var response = new ResponseDTO<string>();

            if (result)
            {
                response.EsCorrecto = true;
                response.Mensaje = "Scout migrado con exito";
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al migrar al Scout";
            }

            return Ok(response);

        }
    }
}
