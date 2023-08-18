
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.EntityConfig
{
    public  class EspecialidadeEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Especialidade> entity)
        {
            entity.HasKey(e => e.EspId);

            entity.ToTable("especialidades");

            entity.Property(e => e.EspId)
               
                .HasColumnName("esp_id");

            entity.Property(e => e.EmpId).HasColumnName("emp_id");

            entity.Property(e => e.EspDescripcion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("esp_descripcion");

            entity.Property(e => e.EspEstado).HasColumnName("esp_estado");

            entity.Property(e => e.EspFechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("esp_fecha_registro");

            entity.Property(e => e.EspNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("esp_nombre");

            entity.HasOne(d => d.Emp)
                .WithMany(p => p.Especialidades)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_especialidades_empresa");
        }
    }
}
