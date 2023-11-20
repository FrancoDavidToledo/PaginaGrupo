using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.WebApp.Servicios.Contrato
{
    public interface IUsuarioServicio
    {

        Task<ResponseDTO<UsuarioSinClaveTokenDto>> Autorizacion(UserLogin userLogin);
        //Task<ResponseDTO<UsuarioDTO>> Obtener(int id);
        //Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo);
        //Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo);
        //Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo);
        //Task<ResponseDTO<bool>> Eliminar(int id);

    }
}
