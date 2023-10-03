using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class ProgresionScoutConfiguration : IEntityTypeConfiguration<ProgresionScout>
    {
        public void Configure(EntityTypeBuilder<ProgresionScout> entity)
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
        }
    }

}

