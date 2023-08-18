
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.EntityConfig
{
    public  class CatalogoSeguimientoEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CatalogoSeguimiento> entity)
        {
            entity.HasKey(e => e.CasId);

            entity.ToTable("catalogo_seguimiento");

            entity.Property(e => e.CasId)
               
                .HasColumnName("cas_id");

            entity.Property(e => e.CasEstado).HasColumnName("cas_estado");

            entity.Property(e => e.CasNombre)
                .IsUnicode(false)
                .HasColumnName("cas_nombre");

            entity.Property(e => e.EspId).HasColumnName("esp_id");

            entity.HasOne(d => d.Esp)
                .WithMany(p => p.CatalogoSeguimientos)
                .HasForeignKey(d => d.EspId)
                .HasConstraintName("FK_catalogo_seguimiento_especialidades");
        }
    }
}
