using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class HistoricoUsuarioConfiguration : IEntityTypeConfiguration<HistoricoUsuario>
    {
        public void Configure(EntityTypeBuilder<HistoricoUsuario> entity)
        {
            entity.Property(e => e.Id)
                          .HasMaxLength(10)
                          .IsFixedLength()
                          .HasColumnName("ID");
            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistoricoUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistoricoUsuarios_Usuarios");
        }
    }

}

