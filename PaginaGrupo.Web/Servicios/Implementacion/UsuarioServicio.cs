using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.Services;
using PaginaGrupo.Core.DTOs;
using System.Net.Http.Json;
using System.Reflection;

namespace PaginaGrupo.Web.Servicios.Implementacion
{
    public class UsuarioServicio
    {
        private readonly HttpClient _httpClient;
        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<ResponseDTO<UsuarioSinClaveTokenDto>> GetLoginByCredentials(UserLogin userLogin)
        {
            var response = await _httpClient.PostAsJsonAsync("AutenticarLogin", userLogin);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioSinClaveTokenDto>>();
            return result!;
        }


        //public async Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("Usuario/Crear", modelo);
        //    var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();
        //    return result!;
        //}

        //public async Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo)
        //{
        //    var response = await _httpClient.PutAsJsonAsync("Usuario/Editar", modelo);
        //    var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
        //    return result!;
        //}

        //public async Task<ResponseDTO<bool>> Eliminar(int id)
        //{
        //    return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Usuario/Eliminar/{id}");
        //}

        //public async Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar)
        //{
        //    return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"Usuario/Lista/{rol}/{buscar}");
        //}

        //public async Task<ResponseDTO<UsuarioDTO>> Obtener(int id)
        //{
        //    return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"Usuario/Obtener/{id}");
        //}
    }
}
