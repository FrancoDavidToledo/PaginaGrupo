using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.BusinessData.MetadataModel;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.Services;

namespace PaginaGrupo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadController : Controller
    {
        private readonly IUnidadRepository _unidadRepository;
        private readonly IMapper _mapper;
        public UnidadController(IUnidadRepository unidadRepository, IMapper mapper)
        {
            _unidadRepository = unidadRepository;
            _mapper = mapper;
        }
        [HttpGet("GetUnidades")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> GetUnidades()
        {

            var unidad = await _unidadRepository.GetUnidades();
            var unidadDto = _mapper.Map<IEnumerable<UnidadDto>>(unidad);

            var response = new ResponseDTO<IEnumerable<UnidadDto>>();

            if (unidadDto != null)
            {
                response.EsCorrecto = true;
                response.Resultado = unidadDto;
            }
            else
            {
                response.EsCorrecto = false;
                response.Mensaje = "Error al buscar las unidades";
            }

            return Ok(response);
        }

        [HttpGet("GetUnidad/{codigo}")]
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente) + "," + nameof(RolType.Hormiga))]
        public async Task<IActionResult> GetUnidad(string codigo)
        {
            var unidad = await _unidadRepository.GetUnidad(codigo);
            var unidadDto = _mapper.Map<UnidadDto>(unidad);
            return Ok(unidadDto);

        }


    }
}
