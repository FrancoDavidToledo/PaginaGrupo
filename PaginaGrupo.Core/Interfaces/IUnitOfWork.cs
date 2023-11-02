namespace PaginaGrupo.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        INoticiasRepository NoticiasRepository { get; }
        //IRepository<Usuario> UsuarioRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }

        IComentarioRepository ComentarioRepository { get; }

        IAdjuntosRepository AdjuntosRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();

    }

}
