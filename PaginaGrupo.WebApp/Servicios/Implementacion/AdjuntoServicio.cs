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
    public class AdjuntoServicio : IAdjuntoServicio
    {
        private readonly HttpClient _httpClient;
        public AdjuntoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<string>> InsertarAdjunto(Adjuntos modelo)
        {
            //var response = await _httpClient.PostAsJsonAsync($"api/Adjunto/InsertarAdjunto?Adjunto={modelo.Adjunto}&IdNoticia={modelo.IdNoticia}", modelo);
            //var result = await response.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            //return result!;

                var url = $"api/Adjunto/InsertarAdjunto";
                // Enviar la solicitud con los datos en el cuerpo
                var response = await _httpClient.PostAsJsonAsync(url, modelo);
                // Verificar si la solicitud fue exitosa
                response.EnsureSuccessStatusCode();  
                
                var result = await response.Content.ReadFromJsonAsync<ResponseDTO<string>>();
                return result!;
        }

    }
}
