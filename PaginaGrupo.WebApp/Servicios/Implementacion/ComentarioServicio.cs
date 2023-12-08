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
    public class ComentarioServicio : IComentarioServicio
    {
        private readonly HttpClient _httpClient;
        private NavigationManager _navigationManager;


        public ComentarioServicio(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;

        }

        //listo - falta test
        public async Task<ResponseDTO<IEnumerable<ComentarioDto>>> ObtenerListadoComentarios(int estado, int? idNoticia, string token)
        {
            string url;

            if (idNoticia == null)
                url =$"api/Comentario/GetComentariosEstado?Estado={estado}";
            else
                url = $"api/Comentario/GetComentariosEstado?Estado={estado}&idNoticia={idNoticia}";

            var request = new HttpRequestMessage(HttpMethod.Get,url);

            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<IEnumerable<ComentarioDto>>>();
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

        //listo - falta test
        public async Task<ApiResponse<IEnumerable<ComentarioPublicoDto>>> ObtenerComentariosActivos(int idNoticia)
        {
            //no hace falta porque es un servicio public

            var response = await _httpClient.GetFromJsonAsync<ApiResponse<IEnumerable<ComentarioPublicoDto>>>(
                    $"api/Comentario/GetComentarioPublicacionActivo/{idNoticia}");

                return response ?? new ApiResponse<IEnumerable<ComentarioPublicoDto>>(null);
           

        }


        //listo - falta test
        public async Task<ResponseDTO<ComentarioDto>> Crear(ComentarioDto modelo, string token)
        {
        var request = new HttpRequestMessage(HttpMethod.Post, $"api/Comentario/InsertarComentario?Fecha={modelo.Fecha.ToString("MM/dd/yyyy")}&Contenido={modelo.Contenido.Replace("\n", "<br/>")}&IdUsuario={modelo.IdUsuario}&IdNoticia={modelo.IdNoticia}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<ComentarioDto>>();
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


        //listo - falta test
        public async Task<ResponseDTO<bool>> Eliminar(ComentarioDto modelo, string token)
        {

            var request = new HttpRequestMessage(HttpMethod.Put, $"api/Comentario/ActualizarEstadoComentario?Id={modelo.Id}&Estado={(int)EstadoComentarios.Rechazado}");
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

        //listo - falta test
        public async Task<ResponseDTO<bool>> Autorizar(ComentarioDto modelo, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"api/Comentario/ActualizarEstadoComentario?Id={modelo.Id}&Estado={(int)EstadoComentarios.Aceptado}");
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
