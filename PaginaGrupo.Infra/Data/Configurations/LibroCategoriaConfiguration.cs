using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class LibroCategoriaConfiguration : IEntityTypeConfiguration<LibroCategoria>
    {
        public void Configure(EntityTypeBuilder<LibroCategoria> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.LibroCategoria)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_LibroCategoria_Categorias");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.LibroCategoria)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK_LibroCategoria_Libros");
        }
    }

}

