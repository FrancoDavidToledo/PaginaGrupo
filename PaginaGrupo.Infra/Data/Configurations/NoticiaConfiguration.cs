using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{
    public class NoticiaConfiguration : IEntityTypeConfiguration<Noticias>
    {
        public void Configure(EntityTypeBuilder<Noticias> entity)
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
                .IsUnicode(false)
                .HasColumnName("Cuerpo");
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
        }
    }
}
