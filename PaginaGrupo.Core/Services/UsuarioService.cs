using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Core.Exceptions;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.QueryFilters;

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
    }
}
