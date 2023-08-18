
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.EntityConfig
{
    public  class IndiceSeguimientoEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<IndiceSeguimiento> entity)
        {
            entity.HasKey(e => e.IseId);

            entity.ToTable("indice_seguimiento");

            entity.Property(e => e.IseId)
               
                .HasColumnName("ise_id");

            entity.Property(e => e.EspId).HasColumnName("esp_id");

            entity.Property(e => e.IseNumero).HasColumnName("ise_numero");

            entity.Property(e => e.UsuId).HasColumnName("usu_id");

            entity.HasOne(d => d.Esp)
                .WithMany(p => p.IndiceSeguimientos)
                .HasForeignKey(d => d.EspId)
                .HasConstraintName("FK_indice_seguimiento_especialidades");

            entity.HasOne(d => d.Usu)
                .WithMany(p => p.IndiceSeguimientos)
                .HasForeignKey(d => d.UsuId)
                .HasConstraintName("FK_indice_seguimiento_usuario");
        }
    }
}
