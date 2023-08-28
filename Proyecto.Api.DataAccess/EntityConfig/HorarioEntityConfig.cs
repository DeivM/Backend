
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.EntityConfig
{
    public  class HorarioEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Horario> entity)
        {
            entity.HasKey(e => e.HorId);

            entity.ToTable("horarios");

            entity.Property(e => e.HorId)
               
                .HasColumnName("hor_id");

            entity.Property(e => e.HorEstado).HasColumnName("hor_estado");

            entity.Property(e => e.HorFechaAtencion)
                .HasColumnType("date")
                .HasColumnName("hor_fecha_atencion");

            entity.Property(e => e.HorFinAtencion).HasColumnName("hor_fin_atencion");

            entity.Property(e => e.HorInicioAtencion).HasColumnName("hor_inicio_atencion");

            entity.Property(e => e.UsuId).HasColumnName("usu_id");

            entity.HasOne(d => d.Usu)
                .WithMany(p => p.Horarios)
                .HasForeignKey(d => d.UsuId)
                .HasConstraintName("FK_horarios_medicos");
        }
    }
}
