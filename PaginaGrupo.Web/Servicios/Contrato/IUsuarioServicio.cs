using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;

namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface IUsuarioServicio
    {

        Task<ResponseDTO<UsuarioSinClaveTokenDto>> GetLoginByCredentials(UserLogin userLogin);
        //Task<ResponseDTO<UsuarioDTO>> Obtener(int id);
        //Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo);
        //Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo);
        //Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo);
        //Task<ResponseDTO<bool>> Eliminar(int id);

    }
}
