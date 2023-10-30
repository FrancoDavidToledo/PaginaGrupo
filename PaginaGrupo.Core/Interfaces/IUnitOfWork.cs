namespace PaginaGrupo.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        INoticiasRepository NoticiasRepository { get; }
        //IRepository<Usuario> UsuarioRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();

    }

}
