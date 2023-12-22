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
    public class AsistenciaServicio : IAsistenciaServicio
    {
        private readonly HttpClient _httpClient;
        private NavigationManager _navigationManager;


        public AsistenciaServicio(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;

        }

        public async Task<ResponseDTO<char>> ObtenerAsistencia(int fecha,int idScout, string token)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/AsistenciaScout/GetFinal?Fecha={fecha}&IdScout={idScout}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<char>>();
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


        public async Task<ResponseDTO<IEnumerable<AsistenciaView>>> ObtenerAsistenciaFiltrada(string codigo, char estado, short anio, string token)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/AsistenciaScout/GetUnidadFechaOk?codigo={codigo}&estado={estado}&anio={anio}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<IEnumerable<AsistenciaView>>>();
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

        public async Task<ResponseDTO<IEnumerable<ScoutAsistenciaDto>>> ObtenerListadoScouts(string? codigo, char? estado,int idFecha, string token)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/AsistenciaScout/GetScouts?Codigo={codigo}&Estado={estado}&idFecha={idFecha}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<IEnumerable<ScoutAsistenciaDto>>>();
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
