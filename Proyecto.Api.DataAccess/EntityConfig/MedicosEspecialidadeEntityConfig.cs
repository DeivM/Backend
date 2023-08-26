
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.EntityConfig
{
    public  class MedicosEspecialidadeEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<MedicosEspecialidade> entity)
        {
            entity.HasKey(e => e.MesId);

            entity.ToTable("medicos_especialidades");

            entity.Property(e => e.MesId)
               
                .HasColumnName("mes_id");

            entity.Property(e => e.EspId).HasColumnName("esp_id");

            entity.Property(e => e.MedId).HasColumnName("med_id");

            entity.Property(e => e.MesEstado).HasColumnName("mes_estado");

            entity.HasOne(d => d.Esp)
                .WithMany(p => p.MedicosEspecialidades)
                .HasForeignKey(d => d.EspId)
                .HasConstraintName("FK_medicos_especialidades_especialidades");

            entity.HasOne(d => d.Usu)
                .WithMany(p => p.MedicosEspecialidades)
                .HasForeignKey(d => d.MedId)
                .HasConstraintName("FK_medicos_especialidades_medicos");
        }
    }
}
