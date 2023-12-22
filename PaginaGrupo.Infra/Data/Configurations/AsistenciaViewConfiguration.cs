using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class AsistenciaViewConfiguration : IEntityTypeConfiguration<AsistenciaView>
    {
        public void Configure(EntityTypeBuilder<AsistenciaView> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Asistencia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CodigoUnidad)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdScout).HasColumnName("IdScout");
            entity.Property(e => e.IdFecha).HasColumnName("IdFecha");
            entity.Property(e => e.Asistencia).HasColumnName("Asistencia");
            entity.Property(e => e.CodigoUnidad).HasColumnName("CodigoUnidad");
            entity.Property(e => e.CodigoUnidadScout).HasColumnName("CodigoUnidadScout");
            entity.Property(e => e.EstadoScout).HasColumnName("EstadoScout");
            entity.Property(e => e.AnioScout).HasColumnName("AnioScout");
        }
    }

}

