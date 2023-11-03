using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using System.Net;

namespace PaginaGrupo.Api.Controllers
{
    public class AvisoPagoController : Controller
    {
        private readonly IAvisoPagoService _avisoPagoService;
        private readonly IMapper _mapper;
        public AvisoPagoController(IAvisoPagoService avisoPagoService, IMapper mapper)
        {
            _avisoPagoService = avisoPagoService;
            _mapper = mapper;
        }
        //lo siguiente es para documentar
        /// <summary>
        /// Muestra los avisos de pagos de un usuario, requiere rol Dirigente o Admin
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<AvisoPagoDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //lo siguiente es el nombre del servicio
        [HttpGet("GetAvisosPagosUsuario/{idUsuario}")]
        //lo siguiente es para ver que roles pueden ejecutar la accion
        [Authorize(Roles = nameof(RolType.Administrador) + "," + nameof(RolType.Dirigente))]
        public async Task<IActionResult> GetAvisosPagosUsuario(int idUsuario)
        {
            var avisoPago = await _avisoPagoService.GetAvisosPagosUsuario(idUsuario);
            var avisoPagoDto = _mapper.Map<IEnumerable<AvisoPagoDto>>(avisoPago);
            return Ok(avisoPagoDto);
        }
    }
}
