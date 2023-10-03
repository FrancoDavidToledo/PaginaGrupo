using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class UnidadConfiguration : IEntityTypeConfiguration<Unidad>
    {
        public void Configure(EntityTypeBuilder<Unidad> entity)
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
        }
    }

}

