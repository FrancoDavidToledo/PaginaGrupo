using Microsoft.AspNetCore.Components;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.WebApp.Servicios.Contrato;
using System.Net;
using System.Net.Http.Json;
using System.Reflection;

namespace PaginaGrupo.WebApp.Servicios.Implementacion
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly HttpClient _httpClient;
        private NavigationManager _navigationManager;
        public UsuarioServicio(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        //listo
        public async Task<ResponseDTO<UsuarioSinClaveTokenDto>> Autorizacion(UserLogin userLogin)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Token/AutenticarLogin", userLogin);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioSinClaveTokenDto>>();
            return result!;
        }

        //listo
        public async Task<ResponseDTO<string>> Crear(UsuarioDto modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Usuario/InsertarUsuario", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return result!;
        }

        public async Task<ResponseDTO<IEnumerable<UsuarioDtoSinClave>>> ObtenerListadoUsuarios(int rol, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Usuario/GetUsuariosRol?rol={rol}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<IEnumerable<UsuarioDtoSinClave>>>();
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

        public async Task<ResponseDTO<UsuarioDtoSinClave>> ObtenerUsuario(int id, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Usuario/GetUsuario/{id}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDtoSinClave>>();
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
        public async Task<ResponseDTO<bool>> Editar(UsuarioDtoSinClave modelo, string token)
        {
            //var response = await _httpClient.PutAsJsonAsync("api/Noticia/ActualizarNoticia", modelo);
            //var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            //return result!;

            var request = new HttpRequestMessage(HttpMethod.Put, $"api/Usuario/ActualizarUsuario?Id={modelo.Id}&Nombre={modelo.Nombre}&Correo={modelo.Correo}&Rol={modelo.Rol}");
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
