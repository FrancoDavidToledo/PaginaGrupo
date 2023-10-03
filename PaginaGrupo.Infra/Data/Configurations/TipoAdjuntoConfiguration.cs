using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class TipoAdjuntoConfiguration : IEntityTypeConfiguration<TipoAdjunto>
    {
        public void Configure(EntityTypeBuilder<TipoAdjunto> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Tipo)
                .HasMaxLength(5)
                .IsUnicode(false);
        }
    }

}

