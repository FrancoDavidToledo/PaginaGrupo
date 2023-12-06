using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.WebApp.Servicios.Contrato
{
    public interface IUsuarioServicio
    {

        Task<ResponseDTO<UsuarioSinClaveTokenDto>> Autorizacion(UserLogin userLogin);
        Task<ResponseDTO<IEnumerable<UsuarioDtoSinClave>>> ObtenerListadoUsuarios(int rol, string token);
        Task<ResponseDTO<UsuarioDtoSinClave>> ObtenerUsuario(int id, string token);
        Task<ResponseDTO<string>> Crear(UsuarioDto modelo);
        Task<ResponseDTO<bool>> Editar(UsuarioDtoSinClave modelo, string token);

    }
}
