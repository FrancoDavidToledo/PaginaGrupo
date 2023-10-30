using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class AdjuntoConfiguration : IEntityTypeConfiguration<Adjuntos>
    {
        public void Configure(EntityTypeBuilder<Adjuntos> entity)
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
        }
    }

}


