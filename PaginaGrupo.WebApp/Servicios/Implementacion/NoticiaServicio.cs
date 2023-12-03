using Microsoft.AspNetCore.Components;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.QueryFilters;
using PaginaGrupo.WebApp.Servicios.Contrato;
using System.Net;
using System.Net.Http.Json;

namespace PaginaGrupo.WebApp.Servicios.Implementacion
{
    public class NoticiaServicio : INoticiaServicio
    {
        private readonly HttpClient _httpClient;
        private NavigationManager _navigationManager;


        public NoticiaServicio(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;

        }

        //public async Task<ResponseDTO<NoticiaAltaDto>> ObtenerById(int id)
        //{
        //    return await _httpClient.GetFromJsonAsync<ResponseDTO<NoticiaAltaDto>>($"api/Noticia/GetNoticia/{id}");
        //}


        public async Task<ResponseDTO<NoticiaAltaDto>> ObtenerById(int id, string token)
        {
                
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Noticia/GetNoticia/{id}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            //request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluaXN0cmFkb3IiLCJuYmYiOjE3MDA4ODAwMjksImV4cCI6MTcwMDg4MDYyOSwiaXNzIjoiQUJDWFlaIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0NDM1NiJ9.3fm5oVLEEa1Y7gdSyCuoAx-qJEAwilak9VDzw5yob0U");
            // request.Headers.Add("Authorization", "Bearer" + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluaXN0cmFkb3IiLCJuYmYiOjE3MDA4ODAwMjksImV4cCI6MTcwMDg4MDYyOSwiaXNzIjoiQUJDWFlaIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0NDM1NiJ9.3fm5oVLEEa1Y7gdSyCuoAx-qJEAwilak9VDzw5yob0U");
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<NoticiaAltaDto>>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
             {
              _navigationManager.NavigateTo("/logout");
                return null;
             }
            else
            {
                return null;
            }
            

        }

        public async Task<ResponseDTO<NoticiaAltaDto>> Obtener(int id)
        {
            //no hace falta porque es un servicio publico
            return await _httpClient.GetFromJsonAsync<ResponseDTO<NoticiaAltaDto>>($"api/Noticia/GetNoticiaActiva/{id}");
        }

        public async Task<ResponseDTO<IEnumerable<NoticiaDto>>> ObtenerListadoNoticias(int estado, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Noticia/GetNoticiasEstado/{estado}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);

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

        public async Task<ApiResponse<IEnumerable<NoticiaActivaImagenDto>>> ObtenerNoticiasActivas(NoticiasQueryFilter filters)
        {
            //no hace falta porque es un servicio publico
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<IEnumerable<NoticiaActivaImagenDto>>>(
                    $"api/Noticia/GetNoticiasActivasImagen?PageSize={filters.PageSize}&PageNumber={filters.PageNumber}&Titulo={filters.Titulo}&IdUsuario={filters.IdUsuario}&FechaNoticia={filters.FechaNoticia}"
                );

                return response ?? new ApiResponse<IEnumerable<NoticiaActivaImagenDto>>(null);
           

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
    }
}
