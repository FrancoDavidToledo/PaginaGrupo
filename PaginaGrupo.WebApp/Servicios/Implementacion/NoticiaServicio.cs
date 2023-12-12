using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
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

        //listo
        public async Task<ResponseDTO<NoticiaAltaDto>> ObtenerById(int id, string token)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Noticia/GetNoticia/{id}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
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

        //listo
        public async Task<ResponseDTO<NoticiaAltaDto>> Obtener(int id)
        {
            //no hace falta porque es un servicio publico
            return await _httpClient.GetFromJsonAsync<ResponseDTO<NoticiaAltaDto>>($"api/Noticia/GetNoticiaActiva/{id}");
        }

        //listo
        public async Task<ResponseDTO<IEnumerable<NoticiaDto>>> ObtenerListadoNoticias(int estado, string token)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Noticia/GetNoticiasEstado/{estado}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<IEnumerable<NoticiaDto>>>();
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

        public async Task<ResponseDTO<IEnumerable<NoticiaDto>>> GetNoticiasEstadoFiltrado(int estado,string filtro, string token)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Noticia/GetNoticiasEstadoFiltrado?Estado={estado}&Filtro={filtro}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<IEnumerable<NoticiaDto>>>();
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

        //listo
        public async Task<ResponseDTO<NoticiaAltaDto>> Crear(NoticiaAltaDto modelo, string token)
        {

            //var response = await _httpClient.PostAsJsonAsync("api/Noticia/InsertarNoticia", modelo);
            //var result = await response.Content.ReadFromJsonAsync<ResponseDTO<NoticiaAltaDto>>();
            //return result!;

            var request = new HttpRequestMessage(HttpMethod.Post, $"api/Noticia/InsertarNoticia?Titulo={modelo.Titulo}&Autor={modelo.Autor}&Copete={modelo.Copete}&Cuerpo={modelo.Cuerpo.Replace("\n", "<br/>")}&FechaNoticia={modelo.FechaNoticia.ToString("MM/dd/yyyy")}&IdUsuario={modelo.IdUsuario}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
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

        //listo
        public async Task<ResponseDTO<bool>> Editar(NoticiaAltaDto modelo, string token)
        {
            //var response = await _httpClient.PutAsJsonAsync("api/Noticia/ActualizarNoticia", modelo);
            //var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            //return result!;

            var request = new HttpRequestMessage(HttpMethod.Put, $"api/Noticia/ActualizarNoticia?Id={modelo.Id}&Titulo={modelo.Titulo}&Autor={modelo.Autor}&Copete={modelo.Copete}&Cuerpo={modelo.Cuerpo}&FechaNoticia={modelo.FechaNoticia.ToString("MM/dd/yyyy")}&IdUsuario={modelo.IdUsuario}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
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

        //listo
        public async Task<ApiResponse<IEnumerable<NoticiaActivaImagenDto>>> ObtenerNoticiasActivas(NoticiasQueryFilter filters)
        {
            //no hace falta porque es un servicio publico
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<IEnumerable<NoticiaActivaImagenDto>>>(
                    $"api/Noticia/GetNoticiasActivasImagen?PageSize={filters.PageSize}&PageNumber={filters.PageNumber}&Titulo={filters.Titulo}&IdUsuario={filters.IdUsuario}&FechaNoticia={filters.FechaNoticia}"
                );

                return response ?? new ApiResponse<IEnumerable<NoticiaActivaImagenDto>>(null);
           

        }

        //listo
        public async Task<ResponseDTO<bool>> Eliminar(NoticiaDto modelo, string token)
        {
            modelo.FechaBaja = DateTime.Today;
            modelo.Estado = Convert.ToInt16(EstadoNoticias.Eliminada);


            //var response = await _httpClient.PutAsJsonAsync($"api/Noticia/ActualizarEstadoNoticia", modelo);
            //var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            //return result!;

            var request = new HttpRequestMessage(HttpMethod.Put, $"api/Noticia/ActualizarEstadoNoticia?Id={modelo.Id}&Estado={modelo.Estado}&FechaBaja={modelo.FechaNoticia.ToString("MM/dd/yyyy")}&IdUsuarioBaja={modelo.IdUsuarioBaja}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
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

        //listo
        public async Task<ResponseDTO<bool>> Publicar(NoticiaDto modelo, string token)
        {
            modelo.Estado = Convert.ToInt16(EstadoNoticias.Pendiente_Autorizacion);

            //var response = await _httpClient.PutAsJsonAsync($"api/Noticia/ActualizarEstadoNoticia", modelo);
            //var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            //return result!;
            var request = new HttpRequestMessage(HttpMethod.Put, $"api/Noticia/ActualizarEstadoNoticia?Id={modelo.Id}&Estado={modelo.Estado}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
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
        //listo
        public async Task<ResponseDTO<bool>> Autorizar(NoticiaDto modelo, string token)
        {
            modelo.Estado = Convert.ToInt16(EstadoNoticias.Autorizado);

            //var response = await _httpClient.PutAsJsonAsync($"api/Noticia/ActualizarEstadoNoticia", modelo);
            //var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            //return result!;
            var request = new HttpRequestMessage(HttpMethod.Put, $"api/Noticia/ActualizarEstadoNoticia?Id={modelo.Id}&Estado={modelo.Estado}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
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
    }
}
