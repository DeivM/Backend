
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.EntityConfig
{
    public  class MenuEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Menu> entity)
        {
            entity.HasKey(e => e.MenId);

            entity.ToTable("menu");

            entity.Property(e => e.MenId)
                .HasColumnName("men_id");

            entity.Property(e => e.MenCodigoUnico)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("men_codigo_unico");

            entity.Property(e => e.MenEstado).HasColumnName("men_estado");

            entity.Property(e => e.MenIcono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("men_icono");

            entity.Property(e => e.MenMenId).HasColumnName("men_men_id");

            entity.Property(e => e.MenNombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("men_nombre");

            entity.Property(e => e.MenOrden).HasColumnName("men_orden");

            entity.Property(e => e.MenTipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("men_tipo");

            entity.Property(e => e.MenUrl)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("men_url");

            entity.HasOne(d => d.MenMen)
                .WithMany(p => p.InverseMenMen)
                .HasForeignKey(d => d.MenMenId)
                .HasConstraintName("FK_menu_menu");
        }
    }
}
