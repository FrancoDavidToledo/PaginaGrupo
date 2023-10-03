using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Entities;

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

    public virtual DbSet<LibroAutor> LibroAutors { get; set; }

    public virtual DbSet<LibroCategorium> LibroCategoria { get; set; }

    public virtual DbSet<NombreScout> NombreScouts { get; set; }

    public virtual DbSet<Noticias> Noticias { get; set; }

    public virtual DbSet<ProgresionScout> ProgresionScouts { get; set; }

    public virtual DbSet<Progresione> Progresiones { get; set; }

    public virtual DbSet<Rama> Ramas { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<RolesUsuario> RolesUsuarios { get; set; }

    public virtual DbSet<Scout> Scouts { get; set; }

    public virtual DbSet<TipoAdjunto> TipoAdjuntos { get; set; }

    public virtual DbSet<TipoNombre> TipoNombres { get; set; }

    public virtual DbSet<Unidade> Unidades { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adjuntos>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adjunto)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("Adjunto");

            entity.HasOne(d => d.IdNoticiaNavigation).WithMany(p => p.Adjuntos)
                .HasForeignKey(d => d.IdNoticia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Adjuntos_Noticias");
        });

        modelBuilder.Entity<AsistenciaScout>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Asistencia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CodigoUnidad)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoUnidadNavigation).WithMany(p => p.AsistenciaScouts)
                .HasForeignKey(d => d.CodigoUnidad)
                .HasConstraintName("FK_AsistenciaScouts_Unidades");

            entity.HasOne(d => d.IdFechaNavigation).WithMany(p => p.AsistenciaScouts)
                .HasForeignKey(d => d.IdFecha)
                .HasConstraintName("FK_AsistenciaScouts_Fechas");

            entity.HasOne(d => d.IdScoutNavigation).WithMany(p => p.AsistenciaScouts)
                .HasForeignKey(d => d.IdScout)
                .HasConstraintName("FK_AsistenciaScouts_Scouts");
        });

        modelBuilder.Entity<Autores>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AvisoPago>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Comentario)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Comprobante)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_AvisoPagos_Usuarios");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contenido)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");

            entity.HasOne(d => d.IdNoticiaNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdNoticia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentarios_Noticias");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentarios_Usuarios");
        });

        modelBuilder.Entity<Fecha>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha1)
                .HasColumnType("date")
                .HasColumnName("Fecha");
        });

        modelBuilder.Entity<HistoricoUsuario>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistoricoUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistoricoUsuarios_Usuarios");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Formato)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Idioma)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.UrlPortada)
                .HasMaxLength(400)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LibroAutor>(entity =>
        {
            entity.ToTable("LibroAutor");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.LibroAutors)
                .HasForeignKey(d => d.IdAutor)
                .HasConstraintName("FK_LibroAutor_Autores");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.LibroAutors)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK_LibroAutor_Libros");
        });

        modelBuilder.Entity<LibroCategorium>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.LibroCategoria)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_LibroCategoria_Categorias");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.LibroCategoria)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK_LibroCategoria_Libros");
        });

        modelBuilder.Entity<NombreScout>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodigoUnidad)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoUnidadNavigation).WithMany(p => p.NombreScouts)
                .HasForeignKey(d => d.CodigoUnidad)
                .HasConstraintName("FK_NombreScouts_Unidades");

            entity.HasOne(d => d.IdScoutNavigation).WithMany(p => p.NombreScouts)
                .HasForeignKey(d => d.IdScout)
                .HasConstraintName("FK_NombreScouts_Scouts");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.NombreScouts)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK_NombreScouts_TipoNombres");
        });

        modelBuilder.Entity<Noticias>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Autor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Copete)
                .HasMaxLength(155)
                .IsUnicode(false);
            entity.Property(e => e.Cuerpo)
                .HasMaxLength(3000)
                .IsUnicode(false);
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.FechaNoticia).HasColumnType("date");
            entity.Property(e => e.Titulo)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.NoticiaIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Noticias_Usuarios1");

            entity.HasOne(d => d.IdUsuarioBajaNavigation).WithMany(p => p.NoticiaIdUsuarioBajaNavigations)
                .HasForeignKey(d => d.IdUsuarioBaja)
                .HasConstraintName("FK_Noticias_Usuarios2");
        });

        modelBuilder.Entity<ProgresionScout>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha).HasColumnType("date");

            entity.HasOne(d => d.IdProgresionNavigation).WithMany(p => p.ProgresionScouts)
                .HasForeignKey(d => d.IdProgresion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProgresionScouts_Progresiones");

            entity.HasOne(d => d.IdScoutNavigation).WithMany(p => p.ProgresionScouts)
                .HasForeignKey(d => d.IdScout)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProgresionScouts_Scouts");
        });

        modelBuilder.Entity<Progresione>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodigoRama)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoRamaNavigation).WithMany(p => p.Progresiones)
                .HasForeignKey(d => d.CodigoRama)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Progresiones_Ramas");
        });

        modelBuilder.Entity<Rama>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.Property(e => e.Codigo)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasIndex(e => e.Codigo, "UK_Roles").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RolesUsuario>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolesUsuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesUsuarios_Roles");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RolesUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesUsuarios_Usuarios");
        });

        modelBuilder.Entity<Scout>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CodigoUnidad)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dni).HasColumnName("DNI");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoUnidadNavigation).WithMany(p => p.Scouts)
                .HasForeignKey(d => d.CodigoUnidad)
                .HasConstraintName("FK_Scouts_Unidades");
        });

        modelBuilder.Entity<TipoAdjunto>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Tipo)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoNombre>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Tipo)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Unidade>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodigoRama)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoRamaNavigation).WithMany(p => p.Unidades)
                .HasForeignKey(d => d.CodigoRama)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Unidades_Ramas");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasIndex(e => e.Correo, "UK_Usuarios").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Clave)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimoIngreso).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

    }
    }
