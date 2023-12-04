using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.WebApp.Servicios.Contrato;
using System.Net.Http.Json;
using System.Reflection;

namespace PaginaGrupo.WebApp.Servicios.Implementacion
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly HttpClient _httpClient;
        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
