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
    public class FechaServicio : IFechaServicio
    {
        private readonly HttpClient _httpClient;
        private NavigationManager _navigationManager;


        public FechaServicio(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;

        }

        public async Task<ResponseDTO<IEnumerable<FechaDto>>> ObtenerListadoFechas(int anio, string token)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Fecha/GetFechas/{anio}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<IEnumerable<FechaDto>>>();
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
