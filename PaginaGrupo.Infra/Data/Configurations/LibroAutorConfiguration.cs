using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class LibroAutorConfiguration : IEntityTypeConfiguration<LibroAutor>
    {
        public void Configure(EntityTypeBuilder<LibroAutor> entity)
        {
            entity.ToTable("LibroAutor");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.LibroAutor)
                .HasForeignKey(d => d.IdAutor)
                .HasConstraintName("FK_LibroAutor_Autores");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.LibroAutor)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK_LibroAutor_Libros");
        }
    }

}

