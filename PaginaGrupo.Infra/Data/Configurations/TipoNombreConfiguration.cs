using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class TipoNombreConfiguration : IEntityTypeConfiguration<TipoNombre>
    {
        public void Configure(EntityTypeBuilder<TipoNombre> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Tipo)
                .HasMaxLength(25)
                .IsUnicode(false);
        }
    }

}

