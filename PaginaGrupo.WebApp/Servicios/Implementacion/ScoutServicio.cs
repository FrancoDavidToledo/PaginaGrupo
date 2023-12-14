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
    public class ScoutServicio : IScoutServicio
    {
        private readonly HttpClient _httpClient;
        private NavigationManager _navigationManager;


        public ScoutServicio(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;

        }

        public async Task<ResponseDTO<ScoutDto>> ObtenerById(int id, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Scout/GetScout/{id}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<ScoutDto>>();
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

        public async Task<ResponseDTO<ScoutNombreDto>> ObtenerScoutNombre(int id, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Scout/GetScout/{id}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<ScoutNombreDto>>();
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

        public async Task<ResponseDTO<ScoutDto>> Crear(ScoutDto modelo, string token)
        { 
            var request = new HttpRequestMessage(HttpMethod.Post, $"api/Scout/InsertarScout?Nombre={modelo.Nombre}&Apellido={modelo.Apellido}&Dni={modelo.Dni}&Sexo={modelo.Sexo}&Telefono={modelo.Telefono}&Correo={modelo.Correo}&Direccion={modelo.Direccion}&CodigoUnidad={modelo.CodigoUnidad}&FechaNacimiento={modelo.FechaNacimiento.ToString("MM/dd/yyyy")}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<ScoutDto>>();
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

        public async Task<ResponseDTO<bool>> Editar(ScoutDto modelo, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"api/Scout/ActualizarScout?Id={modelo.Id}&Nombre={modelo.Nombre}&Apellido={modelo.Apellido}&Dni={modelo.Dni}&Sexo={modelo.Sexo}&Telefono={modelo.Telefono}&Correo={modelo.Correo}&Direccion={modelo.Direccion}&FechaNacimiento={modelo.FechaNacimiento.ToString("MM/dd/yyyy")}");
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

        public async Task<ResponseDTO<IEnumerable<ScoutDto>>> ObtenerListadoScouts(string? codigo, char? estado, string token)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Scout/GetScouts?Codigo={codigo}&Estado={estado}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<IEnumerable<ScoutDto>>>();
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

        public async Task<ResponseDTO<bool>> Eliminar(int idScout, string token)
        {
            char estado = Convert.ToChar("B");
            var request = new HttpRequestMessage(HttpMethod.Put, $"api/Scout/ActualizarEstadoScout?Id={idScout}&Estado={estado}");
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

        public async Task<ResponseDTO<bool>> Rehabilitar(int idScout, string token)
        {
            char estado = Convert.ToChar("A");
            var request = new HttpRequestMessage(HttpMethod.Put, $"api/Scout/ActualizarEstadoScout?Id={idScout}&Estado={estado}");
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

        public async Task<ResponseDTO<bool>> Migrar(ScoutDto modelo, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"api/Scout/MigrarScout?Id={modelo.Id}&CodigoUnidad={modelo.CodigoUnidad}");
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
