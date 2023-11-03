using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> entity)
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
            entity.Property(e => e.Nombre).HasColumnName("Nombre");
        }
    }

}

