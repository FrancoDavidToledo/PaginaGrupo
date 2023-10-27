using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Infra.Data.Configurations;

namespace PaginaGrupo.Infra.Data;

public partial class PaginaGrupoContext : DbContext
{
    public PaginaGrupoContext()
    {
    }

    public PaginaGrupoContext(DbContextOptions<PaginaGrupoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adjuntos> Adjuntos { get; set; }

    public virtual DbSet<AsistenciaScout> AsistenciaScouts { get; set; }

    public virtual DbSet<Autores> Autores { get; set; }

    public virtual DbSet<AvisoPago> AvisoPagos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Fecha> Fechas { get; set; }

    public virtual DbSet<HistoricoUsuario> HistoricoUsuarios { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<LibroAutor> LibrosAutores { get; set; }

    public virtual DbSet<LibroCategoria> LibroCategoria { get; set; }

    public virtual DbSet<NombreScout> NombreScouts { get; set; }

    public virtual DbSet<Noticias> Noticias { get; set; }

    public virtual DbSet<ProgresionScout> ProgresionScouts { get; set; }

    public virtual DbSet<Progresion> Progresiones { get; set; }

    public virtual DbSet<Rama> Ramas { get; set; }

    public virtual DbSet<Scout> Scouts { get; set; }

    public virtual DbSet<TipoAdjunto> TipoAdjuntos { get; set; }

    public virtual DbSet<TipoNombre> TipoNombres { get; set; }

    public virtual DbSet<Unidad> Unidades { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //se pasa el builder a externo
        modelBuilder.ApplyConfiguration(new AdjuntoConfiguration());
        modelBuilder.ApplyConfiguration(new AsistenciaScoutConfiguration());
        modelBuilder.ApplyConfiguration(new AutoresConfiguration());
        modelBuilder.ApplyConfiguration(new AvisoPagoConfiguration());
        modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
        modelBuilder.ApplyConfiguration(new ComentarioConfiguration());
        modelBuilder.ApplyConfiguration(new FechaConfiguration());
        modelBuilder.ApplyConfiguration(new HistoricoUsuarioConfiguration());
        modelBuilder.ApplyConfiguration(new LibroAutorConfiguration());
        modelBuilder.ApplyConfiguration(new LibroCategoriaConfiguration());
        modelBuilder.ApplyConfiguration(new LibroConfiguration());
        modelBuilder.ApplyConfiguration(new NombreScoutConfiguration());
        modelBuilder.ApplyConfiguration(new NoticiaConfiguration());
        modelBuilder.ApplyConfiguration(new ProgresionConfiguration());
        modelBuilder.ApplyConfiguration(new ProgresionScoutConfiguration());
        modelBuilder.ApplyConfiguration(new RamaConfiguration());
        modelBuilder.ApplyConfiguration(new ScoutConfiguration());
        modelBuilder.ApplyConfiguration(new TipoAdjuntoConfiguration());
        modelBuilder.ApplyConfiguration(new TipoNombreConfiguration());
        modelBuilder.ApplyConfiguration(new UnidadConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

    }
}
