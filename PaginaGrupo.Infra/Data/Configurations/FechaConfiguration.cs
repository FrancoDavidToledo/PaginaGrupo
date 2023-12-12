using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class FechaConfiguration : IEntityTypeConfiguration<Fechas>
    {
        public void Configure(EntityTypeBuilder<Fechas> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("Fecha");
        }
    }

}

