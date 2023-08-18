
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.EntityConfig
{
    public  class SeguimientoPacienteEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<SeguimientoPaciente> entity)
        {
            entity.HasKey(e => e.SepId);

            entity.ToTable("seguimiento_paciente");

            entity.Property(e => e.SepId)
               
                .HasColumnName("sep_id");

            entity.Property(e => e.CasId).HasColumnName("cas_id");

            entity.Property(e => e.SepFinalizar)
                .HasColumnName("sep_finalizar");

            entity.Property(e => e.SepObservacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sep_observacion");

            entity.Property(e => e.UsuId).HasColumnName("usu_id");

            entity.Property(e => e.CitId).HasColumnName("cit_id");

            entity.HasOne(d => d.Cas)
                .WithMany(p => p.SeguimientoPacientes)
                .HasForeignKey(d => d.CasId)
                .HasConstraintName("FK_seguimiento_paciente_catalogo_seguimiento");

            entity.HasOne(d => d.Usu)
                .WithMany(p => p.SeguimientoPacientes)
                .HasForeignKey(d => d.UsuId)
                .HasConstraintName("FK_seguimiento_paciente_usuario");

            entity.HasOne(d => d.Cit)
                .WithMany(p => p.SeguimientoPacientes)
                .HasForeignKey(d => d.CitId);
               


        }
    }
}
