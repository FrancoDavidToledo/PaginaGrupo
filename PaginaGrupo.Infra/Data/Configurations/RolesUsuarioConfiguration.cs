using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Data.Configurations
{

    public class RolesUsuarioConfiguration : IEntityTypeConfiguration<RolesUsuario>
    {
        public void Configure(EntityTypeBuilder<RolesUsuario> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolesUsuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesUsuarios_Roles");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RolesUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesUsuarios_Usuarios");
        }
    }

}

