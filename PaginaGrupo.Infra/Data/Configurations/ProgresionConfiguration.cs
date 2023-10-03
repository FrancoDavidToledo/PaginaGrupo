using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class ProgresionConfiguration : IEntityTypeConfiguration<Progresion>
    {
        public void Configure(EntityTypeBuilder<Progresion> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodigoRama)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoRamaNavigation).WithMany(p => p.Progresiones)
                .HasForeignKey(d => d.CodigoRama)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Progresiones_Ramas");
        }
    }

}

