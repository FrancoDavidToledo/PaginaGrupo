using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
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

        public async Task<ApiResponse<IEnumerable<NoticiaDto>>> ObtenerNoticiasActivas(NoticiasQueryFilter filters)
        {
   
                // Adjust the API endpoint based on your actual endpoint
                var response = await _httpClient.GetFromJsonAsync<ApiResponse<IEnumerable<NoticiaDto>>>(
                    $"api/Noticia/GetNoticiasActivas?PageSize={filters.PageSize}&PageNumber={filters.PageNumber}&Titulo={filters.Titulo}&IdUsuario={filters.IdUsuario}&FechaNoticia={filters.FechaNoticia}"
                );

                return response ?? new ApiResponse<IEnumerable<NoticiaDto>>(null);
           

        }

        public async Task<ResponseDTO<bool>> Eliminar(NoticiaDto modelo)
        {
            modelo.FechaBaja = DateTime.Today;
            modelo.Estado = Convert.ToInt16(EstadoNoticias.Eliminada);
            var response = await _httpClient.PutAsJsonAsync($"api/Noticia/ActualizarEstadoNoticia", modelo);

            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Publicar(NoticiaDto modelo)
        {
            modelo.Estado = Convert.ToInt16(EstadoNoticias.Pendiente_Autorizacion);
            var response = await _httpClient.PutAsJsonAsync($"api/Noticia/ActualizarEstadoNoticia", modelo);

            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Autorizar(NoticiaDto modelo)
        {
            modelo.Estado = Convert.ToInt16(EstadoNoticias.Autorizado);
            var response = await _httpClient.PutAsJsonAsync($"api/Noticia/ActualizarEstadoNoticia", modelo);

            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
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
