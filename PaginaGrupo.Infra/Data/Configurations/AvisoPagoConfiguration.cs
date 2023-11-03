using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class AvisoPagoConfiguration : IEntityTypeConfiguration<AvisoPago>
    {
        public void Configure(EntityTypeBuilder<AvisoPago> entity)
        {
            entity.HasNoKey();

            entity.Property(e => e.Comentario)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Comprobante)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.IdUsuario).HasColumnType("IdUsuario");
            entity.HasOne(d => d.IdUsuarioNavigation).WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_AvisoPagos_Usuarios");

        }
    }

}

