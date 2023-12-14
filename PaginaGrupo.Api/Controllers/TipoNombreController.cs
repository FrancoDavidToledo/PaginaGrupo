using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoNombreController : Controller
    {
        private readonly ITipoNombreRepository _tipoNombreRepository;
        private readonly IMapper _mapper;
        public TipoNombreController(ITipoNombreRepository tipoNombreRepository, IMapper mapper)
        {
            _tipoNombreRepository = tipoNombreRepository;
            _mapper = mapper;
        }
        [HttpGet("GetTiposNombres")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> GetTiposNombres()
        {
            var tipoNombre = await _tipoNombreRepository.GetTiposNombres();
            var tipoNombreDto = _mapper.Map<IEnumerable<TipoNombreDto>>(tipoNombre);
            var response = new ResponseDTO<IEnumerable<TipoNombreDto>>();

            if (tipoNombreDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = tipoNombreDto;
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al obtener los tipos de nombres scout";
            }

            return Ok(response);
        }

        //[HttpGet("GetTipoNombre/{id}")]
        //[Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        //public async Task<IActionResult> GetTipoNombre(int id)
        //{
        //    var tipoNombre = await _tipoNombreRepository.GetTipoNombre(id);
        //    var tipoNombreDto = _mapper.Map<TipoNombreDto>(tipoNombre);
        //    return Ok(tipoNombreDto);

        //}


    }
}
