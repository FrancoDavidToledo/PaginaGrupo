using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.QueryFilters;
using PaginaGrupo.WebApp.Servicios.Contrato;
using System.Net.Http.Json;
using System.Reflection;
using System.Security.Claims;

namespace PaginaGrupo.WebApp.Servicios.Implementacion
{
    public class NoticiaServicio : INoticiaServicio
    {
        private readonly HttpClient _httpClient;
        public NoticiaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<NoticiaAltaDto>> ObtenerById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<NoticiaAltaDto>>($"api/Noticia/GetNoticia/{id}");
        }

        public async Task<ResponseDTO<NoticiaAltaDto>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<NoticiaAltaDto>>($"api/Noticia/GetNoticiaActiva/{id}");
        }

        public async Task<ResponseDTO<IEnumerable<NoticiaDto>>> ObtenerListadoNoticias(int estado)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<IEnumerable<NoticiaDto>>>($"api/Noticia/GetNoticiasEstado/{estado}");
        }

        public async Task<ResponseDTO<NoticiaAltaDto>> Crear(NoticiaAltaDto modelo)
        {
       
            var response = await _httpClient.PostAsJsonAsync("api/Noticia/InsertarNoticia", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<NoticiaAltaDto>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(NoticiaAltaDto modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Noticia/ActualizarNoticia", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<List<NoticiaAltaDto>>> ObtenerNoticiasActivas(NoticiasQueryFilter filter)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<NoticiaAltaDto>>>($"api/Noticia/GetNoticiasActivas/{filter}");

        }
        
        //public async Task<ResponseDTO<bool>> Eliminar(int id)
        //{
        //    return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Noticia/Eliminar/{id}");
        //}

        //public async Task<ResponseDTO<List<NoticiaDTO>>> Lista(string rol, string buscar)
        //{
        //    return await _httpClient.GetFromJsonAsync<ResponseDTO<List<NoticiaDTO>>>($"Noticia/Lista/{rol}/{buscar}");
        //}

    }
}
