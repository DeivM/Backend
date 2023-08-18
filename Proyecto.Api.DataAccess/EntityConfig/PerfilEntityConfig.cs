
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.EntityConfig
{
    public  class PerfilEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Perfil> entity)
        {
            entity.HasKey(e => e.PerId);

            entity.ToTable("perfil");

            entity.Property(e => e.PerId)
                .HasColumnName("per_id");

            entity.Property(e => e.EmpId).HasColumnName("emp_id");

            entity.Property(e => e.PerEstado).HasColumnName("per_estado");

            entity.Property(e => e.PerNombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("per_nombre");

            entity.HasOne(d => d.Emp)
                .WithMany(p => p.Perfils)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_perfil_empresa");
        }
    }
}
