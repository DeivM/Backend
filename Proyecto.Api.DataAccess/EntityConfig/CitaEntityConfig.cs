
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.EntityConfig
{
    public  class CitaEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Cita> entity)
        {
            entity.HasKey(e => e.CitId);

            entity.ToTable("citas");

            entity.Property(e => e.CitId)
               
                .HasColumnName("cit_id");

            entity.Property(e => e.CitEstado).HasColumnName("cit_estado");

            entity.Property(e => e.CitEstadoPaciente)
                .IsUnicode(false)
                .HasColumnName("cit_estado_paciente");

            entity.Property(e => e.CitFechaAtencion)
                .HasColumnType("date")
                .HasColumnName("cit_fecha_atencion");

            entity.Property(e => e.CitFinAtencion).HasColumnName("cit_fin_atencion");

            entity.Property(e => e.CitInicioAtencion).HasColumnName("cit_inicio_atencion");

            entity.Property(e => e.CitObservaciones)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cit_observaciones");

            entity.Property(e => e.MesId).HasColumnName("mes_id");

            entity.Property(e => e.UsuId).HasColumnName("usu_id");
            entity.Property(e => e.HorId).HasColumnName("hor_id");

            entity.HasOne(d => d.Mes)
                .WithMany(p => p.Cita)
                .HasForeignKey(d => d.MesId)
                ;

            entity.HasOne(d => d.Usu)
                .WithMany(p => p.Cita)
                .HasForeignKey(d => d.UsuId)
                .HasConstraintName("FK_citas_usuario");

            entity.HasOne(d => d.Hor)
               .WithMany(p => p.Cita)
               .HasForeignKey(d => d.HorId);
        }
    }
}
