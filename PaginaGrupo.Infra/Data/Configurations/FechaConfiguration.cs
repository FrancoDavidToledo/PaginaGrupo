using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class FechaConfiguration : IEntityTypeConfiguration<Fecha>
    {
        public void Configure(EntityTypeBuilder<Fecha> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha1)
                .HasColumnType("date")
                .HasColumnName("Fecha");
        }
    }

}

