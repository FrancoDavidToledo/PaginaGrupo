using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Enumerations;
using PaginaGrupo.Core.Interfaces;

namespace PaginaGrupo.Core.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Usuario> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unitOfWork.UsuarioRepository.GetLoginByCredentials(userLogin);
        }
        public async Task RegisterUser(Usuario usuario)
        {
            await _unitOfWork.UsuarioRepository.Add(usuario);
            await _unitOfWork.SaveChangesAsync();
        }

        public  IEnumerable<Usuario> GetUsuarios()
        {
            var usuarios = _unitOfWork.UsuarioRepository.GetAll();

            return usuarios;
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetById(id);


            return usuarios;
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosRol(RolType rol)
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetUsuariosRol(rol);

            return usuarios;
        }

        public async Task<bool> ActualizarUsuario(Usuario usuario)
        {
            _unitOfWork.UsuarioRepository.Update(usuario);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
