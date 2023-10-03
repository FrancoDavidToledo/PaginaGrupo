using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class AsistenciaScoutConfiguration : IEntityTypeConfiguration<AsistenciaScout>
    {
        public void Configure(EntityTypeBuilder<AsistenciaScout> entity)
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
        }
    }

}

