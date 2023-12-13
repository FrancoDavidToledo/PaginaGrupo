using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using PaginaGrupo.Api.Responses;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.QueryFilters;
using PaginaGrupo.WebApp.Servicios.Contrato;
using System.Net;
using System.Net.Http.Json;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Net.Http;
using Newtonsoft.Json;


namespace PaginaGrupo.WebApp.Servicios.Implementacion
{
    public class AdjuntoServicio : IAdjuntoServicio
    {
        private readonly HttpClient _httpClient;
        private NavigationManager _navigationManager;
        public AdjuntoServicio(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        //listo
        public async Task<ResponseDTO<string>> InsertarAdjunto(Adjuntos modelo, string token)
        {
            string url;

             url = $"api/Adjunto/InsertarAdjunto?Adjunto={modelo.Adjunto}&IdNoticia={modelo.IdNoticia}";
      
           
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<string>>();
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
        public async Task<ApiResponse<IEnumerable<AdjuntosDto>>> GetAdjuntosNoticia(int idNoticia)
        {
          var result= await _httpClient.GetFromJsonAsync<ApiResponse<IEnumerable<AdjuntosDto>>>($"api/Adjunto/GetAdjuntos/{idNoticia}");

            return result;

        }

        public async Task<bool> EliminarAdjuntos(int idAdjunto, string token)
        {
            //return await _httpClient.GetFromJsonAsync<>($"api/Adjunto/EliminarAdjunto/{idAdjunto}");

            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/Adjunto/EliminarAdjunto/{idAdjunto}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<bool>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("/logout");
                return false;
            }
            else
            {
                return false;
            }

        }

    }
}
