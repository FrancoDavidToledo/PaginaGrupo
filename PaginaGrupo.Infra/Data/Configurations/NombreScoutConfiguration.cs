using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class NombreScoutConfiguration : IEntityTypeConfiguration<NombreScout>
    {
        public void Configure(EntityTypeBuilder<NombreScout> entity)
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
        }
    }

}

