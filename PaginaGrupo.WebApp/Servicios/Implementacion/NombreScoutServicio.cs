using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.QueryFilters;
using PaginaGrupo.WebApp.Servicios.Contrato;
using System.Net;
using System.Net.Http.Json;

namespace PaginaGrupo.WebApp.Servicios.Implementacion
{
    public class NombreScoutServicio : INombreScoutServicio
    {
        private readonly HttpClient _httpClient;
        private NavigationManager _navigationManager;


        public NombreScoutServicio(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;

        }

        public async Task<ResponseDTO<NombreScoutDto>> ObtenerById(int id, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/NombreScout/GetNombreScout/{id}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<NombreScoutDto>>();
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
        public async Task<ResponseDTO<NombreScoutDto>> Crear(NombreScoutDto modelo, string token)
        { 
            var request = new HttpRequestMessage(HttpMethod.Post, $"api/NombreScout/InsertarNombreScout?IdTipo={modelo.IdTipo}&Nombre={modelo.Nombre}&CodigoUnidad={modelo.CodigoUnidad}&IdScout={modelo.IdScout}&Fecha={modelo.Fecha.ToString("MM/dd/yyyy")}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<NombreScoutDto>>();
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

        public async Task<ResponseDTO<bool>> Editar(NombreScoutDto modelo, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"api/NombreScout/ActualizarNombreScout?Id={modelo.Id}&IdTipo={modelo.IdTipo}&Nombre={modelo.Nombre}&CodigoUnidad={modelo.CodigoUnidad}&IdScout={modelo.IdScout}&Fecha={modelo.Fecha.ToString("MM/dd/yyyy")}");
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

        public async Task<ResponseDTO<IEnumerable<NombreScoutDto>>> ObtenerListadoNombres(int idScout, string token)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/NombreScout/GetNombresScouts/{idScout}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<IEnumerable<NombreScoutDto>>>();
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

        public async Task<ResponseDTO<bool>> Eliminar(int id, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/NombreScout/BorrarNombreScout/{id}");
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
