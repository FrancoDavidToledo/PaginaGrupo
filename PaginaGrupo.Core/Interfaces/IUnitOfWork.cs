namespace PaginaGrupo.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        INoticiasRepository NoticiasRepository { get; }
        //IRepository<Usuario> UsuarioRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }

        IComentarioRepository ComentarioRepository { get; }

        IAdjuntosRepository AdjuntosRepository { get; }

        ILibroRepository LibroRepository { get; }
        IAutoresRepository AutoresRepository { get; }
        ICategoriasRepository CategoriasRepository { get; }

        IAvisoPagoRepository AvisoPagoRepository { get; }

        IScoutRepository ScoutRepository { get; }
        IFechaRepository FechaRepository { get; }
        IAsistenciaScoutRepository AsistenciaScoutRepository { get; }
        INombreScoutRepository NombreScoutRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();

    }

}
